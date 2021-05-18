using Godot;
using System;
using System.Collections.Generic;

public class WheelSpawner : Spatial
{
  public void Die()
  {
    foreach (RigidBody deadWheel in GetChildren())
    {
      deadWheel.Visible = true;
      deadWheel.GetNode<CollisionShape>(nameof(CollisionShape)).Disabled = false;
      deadWheel.SetAsToplevel(true);
    }
  }
}
