using Godot;
using System;

public partial class DeadScreen : Control
{
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("exit"))
			ChangeScene("res://Scenes/main_menu.tscn");
	}

	private void ChangeScene(string scenePath)
	{
		saves.Deaths++;
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);

		sceneTree.ChangeSceneToPacked(newScene);
	}
}
