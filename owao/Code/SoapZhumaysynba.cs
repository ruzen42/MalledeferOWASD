using Godot;
using System;

public partial class SoapZhumaysynba : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//if (saves.NightSelected < 3) QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Camera();
	}
	
	private void Camera()
	{
		if (saves.SelectedCamera == 6) 
		{
			Visible = true;
		}
		else 
		{
			Visible = false;
		}
	}
}
