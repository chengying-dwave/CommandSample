﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;

namespace CommandSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string? _RobotName;

    /// <summary>
    /// The name of a robot. If the name is null or empty, there is no other robot present.
    /// </summary>
    public string? RobotName
    {
        get => _RobotName;
        set => this.RaiseAndSetIfChanged(ref _RobotName, value);
    }

    /// <summary>
    /// This command will ask HAL-9000 to open the pod bay doors
    /// </summary>
    public ICommand OpenThePodBayDoorsDirectCommand { get; }

    /// <summary>
    /// This command will ask HAL to open the pod bay doors, but this time we
    /// check that the command is issued by a fellow robot (really any non-null name)
    /// </summary>
    public ICommand OpenThePodBayDoorsFellowRobotCommand { get; }

    /// <summary>
    ///  This collection will store what the computer said
    /// </summary>
    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    public MainWindowViewModel()
    {
        // Init OpenThePodBayDoorsDirectCommand
        OpenThePodBayDoorsDirectCommand = ReactiveCommand.Create(OpenThePodBayDoors);

        // The IObservable<bool> is needed to enable or disable the command depending on valid parameters
        // The Observable listens to RobotName and will enable the Command if the name is not empty.
        IObservable<bool> canExecuteFellowRobotCommand =
            this.WhenAnyValue(vm => vm.RobotName, (name) => !string.IsNullOrEmpty(name));

        OpenThePodBayDoorsFellowRobotCommand =
            ReactiveCommand.Create<string?>(name => OpenThePodBayDoorsFellowRobot(name), canExecuteFellowRobotCommand);
    }

    // The method that will be executed when the command is invoked
    private void OpenThePodBayDoors()
    {
        ConversationLog.Clear();
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
    }

    private void OpenThePodBayDoorsFellowRobot(string? robotName)
    {
        ConversationLog.Clear();
        AddToConvo($"Hello {robotName}, the Pod Bay is open :-)");
    }

    // Just a helper to add content to ConversationLog
    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
}
