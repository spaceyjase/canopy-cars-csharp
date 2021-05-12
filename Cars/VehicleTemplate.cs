using Godot;
using System;

public class VehicleTemplate : VehicleBody
{
    [Export] private int playerId;
    [Export] private string carName;
    [Export] private int maxSpeed = 20;
    [Export] private int throttle = 210000;
    [Export] private int maxSteer = 15;
    [Export] private int maxHealth = 100;
}
