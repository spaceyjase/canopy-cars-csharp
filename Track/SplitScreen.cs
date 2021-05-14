using Godot;
using System;

public class SplitScreen : CanvasLayer
{
  private GridContainer GridContainer => GetNode<GridContainer>(nameof(GridContainer));

  private ViewportContainer[] viewports;

  public override void _Ready()
  {
    base._Ready();
    viewports = new[]
    {
      GetNode<ViewportContainer>("GridContainer/ViewportContainer"),
      GetNode<ViewportContainer>("GridContainer/ViewportContainer2"),
      GetNode<ViewportContainer>("GridContainer/ViewportContainer3"),
      GetNode<ViewportContainer>("GridContainer/ViewportContainer4"),
    };
  }

  public override void _Input(InputEvent @event)
  {
    base._Input(@event);
    
    // TODO: testing...
    if (Input.IsActionPressed("1Player"))
    {
      viewports[1].Hide();
      viewports[2].Hide();
      viewports[3].Hide();
      
      GridContainer.Columns = 1;
    }
    if (Input.IsActionPressed("2Player"))
    {
      viewports[1].Show();
      viewports[2].Hide();
      viewports[3].Hide();
      
      GridContainer.Columns = 2;
    }
    if (Input.IsActionPressed("3Player"))
    {
      viewports[1].Show();
      viewports[2].Show();
      viewports[3].Hide();
      
      GridContainer.Columns = 2;
    }
    if (Input.IsActionPressed("4Player"))
    {
      viewports[1].Show();
      viewports[2].Show();
      viewports[3].Show();
      
      GridContainer.Columns = 2;
    }
  }
}
