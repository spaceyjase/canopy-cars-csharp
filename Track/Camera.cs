using Godot;
using System;

public class Camera : Godot.Camera
{
  [Export] private int cameraId; // to allow different cameras -> player
  [Export] private NodePath followThisPath;
  [Export] private float targetDistanceInMeters = 10f;
  [Export] private float targetHeightInMeters = 1f;

  private Spatial followThis;
  private Vector3 lastLookAt;

  public override void _Ready()
  {
    base._Ready();

    SetAsToplevel(true); // ignore parent transforms

    if (followThisPath != null)
    {
      followThis = GetNode<Spatial>(followThisPath);
      lastLookAt = followThis.GlobalTransform.origin;
    }
  }

  public override void _PhysicsProcess(float delta)
  {
    base._PhysicsProcess(delta);

    if (followThis == null) return;

    var deltaV = GlobalTransform.origin - followThis.GlobalTransform.origin;
    var targetPosition = GlobalTransform.origin;

    deltaV.y = 0; // no up and down movement
    if (deltaV.Length() > targetDistanceInMeters)
    {
      deltaV = deltaV.Normalized() * targetDistanceInMeters;
      deltaV.y = targetHeightInMeters;
      targetPosition = followThis.GlobalTransform.origin + deltaV;
    }
    else
    {
      targetPosition.y = followThis.GlobalTransform.origin.y + targetHeightInMeters;
    }

    var newPosition = GlobalTransform.origin.LinearInterpolate(targetPosition, 1f);
    GlobalTransform = new Transform(Basis.Identity,  newPosition);
    lastLookAt = lastLookAt.LinearInterpolate(followThis.GlobalTransform.origin, 1f);
    LookAt(lastLookAt + new Vector3(0f, 2f, 0f), Vector3.Up);
  }
}
