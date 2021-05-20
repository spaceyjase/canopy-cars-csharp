using Godot;
using System;

public class Track : Spatial
{
  public override void _Ready()
  {
    base._Ready();

    foreach (var file in FileGrabber.GetFiles("res://Cars/CarScenes/"))
    {
      GD.Print(file);
    }
  }
}
