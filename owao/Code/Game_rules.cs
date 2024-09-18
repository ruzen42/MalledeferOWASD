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
		if (saves.NightsCompleted == 0)
		{
			saves.NightsCompleted += 1;
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
