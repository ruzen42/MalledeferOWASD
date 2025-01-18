using Godot;
using System;

public partial class DiareyVirus : Sprite2D
{
	Random Rand = new Random();
	Timer Time;
	byte max, min;
	
	SceneTree SceneTree;
	PackedScene Scene;
	
	public override void _Ready()
	{
		Visible = false;
		if (saves.NightSelected < 5)
			QueueFree();
			
		SceneTree = GetTree();
		Scene = GD.Load<PackedScene>("res://Scenes/dead_screen.tscn");
		WaitTimeMath();		
		
		Time = new Timer 
		{
			Autostart = true,
			WaitTime = Rand.Next(min, max),
			OneShot = false
		};
		
		Time.Connect("timeout", new Callable(this, nameof(OnTimeTimeout)));
		AddChild(Time);
	}
	
	private void OnTimeTimeout() 
	{
		Time.WaitTime = Rand.Next(min, max);
		Time.Start();
		if (saves.Temp > 30)
			Kill();
	}
	
	private void Kill() { SceneTree.ChangeSceneToPacked(Scene); }

	private void WaitTimeMath()
	{
		switch (saves.NightSelected)
		{
			default:
				min = 50;
				max = 100;
				break;
			case 1:
				min = 50;
				max = 100;
				break;
			case 2:
				min = 45;
				max = 90;
				break;
			case 3:
				min = 40;
				max = 80;
				break;
			case 4:
				min = 35;
				max = 70;
				break;
			case 6:
				min = 27;
				max = 55;
				break;
			case 7:
				min = 25;
				max = 50;
				break;
		}

		min /= 3; 
		max /= 3;
	}
}
