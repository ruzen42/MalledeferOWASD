using Godot;
using System;

public partial class Game_rules : Node2D
{
	Timer Temp;
	byte max;
	Random Rand = new Random();

	public void OnTempTimerTimeout()
	{
		if (saves.Temp > 32) 
			return;
		
		saves.Temp += (float)Rand.NextDouble() * max;
		Temp.WaitTime = Rand.Next(0, max*7)+0.1;
		Temp.Start();
	}

	public override void _Ready()
	{
		GetNode<AudioStreamPlayer>("Fan_Sound").Play();
		max = 2;
		Temp = new Timer
		{
			Autostart = true,
			WaitTime = Rand.Next(0, max*7)+0.1,
			OneShot = false
		};
		
		Temp.Connect("timeout", new Callable(this, nameof(OnTempTimerTimeout)));
		AddChild(Temp);
	}

	public override void _Process(double delta)
	{
		// При нажатии на Esc вас выкинет из игры 
		if (Input.IsActionPressed("exit"))
			GetTree().Quit();

		if (Input.IsActionPressed("win"))
			_on_timer_timeout();
	}

	// Победный таймер 
	private void _on_timer_timeout()
	{	
		// Прибавляется 1 если ты победил (Нужно переделать)
		switch (saves.NightsCompleted)
		 {
			case 0:
				++saves.NightsCompleted;
				break;
			case 1:
				if (saves.NightSelected == 2)
					++saves.NightsCompleted;
				break;
			case 2:
				if (saves.NightSelected == 3)
					++saves.NightsCompleted;
				break;
			case 3:
				if (saves.NightSelected == 4)
					++saves.NightsCompleted;
				break;
			case 4:
				if (saves.NightSelected == 5)
					++saves.NightsCompleted;
				break;
			case 5:
				if (saves.NightSelected == 6)
					++saves.NightsCompleted;
				break;
			case 6:
				if (saves.NightSelected == 7) 
					++saves.NightsCompleted;
				break;
			default:
				// Optional: handle the case when all 7 nights are completed
				GD.Print("Game Win");
				break;
		}
		saves.SaveGame();
		ChangeScene("res://Scenes/end_game.tscn");
	}

	private void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);

		sceneTree.ChangeSceneToPacked(newScene);
	}
}
