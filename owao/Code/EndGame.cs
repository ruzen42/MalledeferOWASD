using Godot;

public partial class EndGame : Node2D
{
	// Функция загружает сцену
	private void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);
		sceneTree.ChangeSceneToPacked(newScene);
	}
	// Kы выходим в главное меню 
	private void _on_timer_timeout()
	{
		ChangeScene("res://Scenes/main_menu.tscn");
	}

	public override void _Process(double delta)
	{
		// При нажатии на Esc вас выкинет из игры 
		if (Input.IsActionPressed("exit"))
		{
			ChangeScene("res://Scenes/main_menu.tscn");
		}
	}
}
