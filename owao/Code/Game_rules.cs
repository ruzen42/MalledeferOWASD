using Godot;

public partial class Game_rules : Node2D
{
	public override void _Process(double delta)
	{
		// При нажатии на Esc вас выкинет из игры 
		if (Input.IsActionPressed("exit"))
		{
			GetTree().Quit();
		}
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
				{
					++saves.NightsCompleted;
				}
				break;
			case 2:
				if (saves.NightSelected == 3)
				{
					++saves.NightsCompleted;
				}
				break;
			case 3:
				if (saves.NightSelected == 4)
				{
					++saves.NightsCompleted;
				}
				break;
			case 4:
				if (saves.NightSelected == 5)
				{
					++saves.NightsCompleted;
				}
				break;
			case 5:
				if (saves.NightSelected == 6)
				{
					++saves.NightsCompleted;
				}
				break;
			case 6:
				if (saves.NightSelected == 7) 
				{
					++saves.NightsCompleted;
				}
				break;
			default:
				// Optional: handle the case when all 7 nights are completed
				GD.Print("Game Win");
				break;
		}
		ChangeScene("res://Scenes/end_game.tscn");
	}
	
	private void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);

		sceneTree.ChangeSceneToPacked(newScene);
	}
}
