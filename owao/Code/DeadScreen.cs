using Godot;
using System;

public partial class DeadScreen : Control
{
	public override void _Process(double delta)
	{
		// При нажатии на Esc вас вернет в меню
		if (Input.IsActionPressed("exit"))
		{
			ChangeScene("res://Scenes/main_menu.tscn");
		}
	}

	private void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);

		sceneTree.ChangeSceneToPacked(newScene);
	}
}
