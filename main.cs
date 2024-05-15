using Godot;
using System;
using System.Collections.Generic;

public partial class main : Node2D
{
  private PackedScene _ballScene;
  private PackedScene _rampScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.fetchScenes();
    
    this.SetupStartButton();

    this.AddBall();

    PhysicsServer2D.SetActive(false);
	}

  void fetchScenes() {
    _ballScene = GD.Load<PackedScene>("res://ball.tscn");
    _rampScene = GD.Load<PackedScene>("res://ramp.tscn");
  }

  void SetupStartButton() {
    var startButton = this.GetNode<Button>("StartButton");

    startButton.ButtonDown += () => {
      PhysicsServer2D.SetActive(true);
    };
  }

  void AddBall() {
    var ball = _ballScene.Instantiate() as Node2D;
    ball.Position = new Vector2(200, 100);
    AddChild(ball);
  }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

  public override void _Input(InputEvent @event)
  {
	  if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ShiftPressed) {
      var ramp = _rampScene.Instantiate() as Node2D;
      ramp.Position = eventMouseButton.Position;
      AddChild(ramp);
	  }
  }
}
