using Godot;

public partial class GameLoad : Control
{
	SceneTree sceneTree;
	PackedScene newScene;

	private void _on_timer_timeout()
	{
		ChangeScene();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("exit"))
		{
			ChangeScene();
		}
	}

	private void ChangeScene()
	{
		sceneTree.ChangeSceneToPacked(newScene);
	}

	public override void _Ready()
	{
		newScene = GD.Load<PackedScene>("res://Scenes/main_menu.tscn");
		sceneTree = GetTree();
	}
	
	private void OnSkipButtonPressed() 
	{
		_on_timer_timeout();
	}
}
