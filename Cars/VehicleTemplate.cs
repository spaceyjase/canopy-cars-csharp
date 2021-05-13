using Godot;

public class VehicleTemplate : VehicleBody
{
    [Export] private int playerId;
    [Export] private string carName;
    [Export] private int maxSpeed = 20;
    [Export] private int throttle = 210000;
    [Export] private int maxSteer = 15;
    [Export] private int maxHealth = 100;

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        EngineForce = 0;// add this amount of force forward or backwards and calculate physics;
                        // not the same as 'how much have I moved';

        if (Input.IsActionPressed($"Player_{playerId}_Forward"))
        {
          if (LinearVelocity.Length() < maxSpeed)
          {
            EngineForce = throttle * delta;
          }
        }
        else if (Input.IsActionPressed($"Player_{playerId}_Back"))
        {
          if (LinearVelocity.Length() < maxSpeed)
          {
            EngineForce = -throttle * delta;
          }
        }

        Steering += (Input.GetActionStrength($"Player_{playerId}_Left") -
                     Input.GetActionStrength($"Player_{playerId}_Right")) * delta;
        Steering = Mathf.Clamp(Steering, -maxSteer, maxSteer);
        Steering = Mathf.Lerp(Steering, 0f, 0.1f); // TODO: recenter speed
    }
}
