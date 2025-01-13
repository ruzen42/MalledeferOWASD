using Godot;

public partial class EndGame : Node2D
{
	string scenePath = "res://Scenes/main_menu.tscn";
	SceneTree sceneTree;
	PackedScene newScene;
	// Функция загружает сцену
	private void ChangeScene()
	{
		sceneTree.ChangeSceneToPacked(newScene);
	}
	// Kы выходим в главное меню 
	private void _on_timer_timeout()
	{
		ChangeScene();
	}
	
	private void OnSkipButtonPressed()
	{
		_on_timer_timeout();
	}

	public override void _Process(double delta)
	{
		// При нажатии на Esc вас выкинет из игры 
		if (Input.IsActionPressed("exit"))
		{
			ChangeScene();
		}
	}

	public override void _Ready()
	{
		sceneTree = GetTree();
		newScene = GD.Load<PackedScene>(scenePath);
	}
}
