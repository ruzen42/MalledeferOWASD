using Godot;
using System;

public partial class DeadScreen : Control
{
	SceneTree sceneTree;
	PackedScene newScene;
	
	public override void _Process(double delta)
	{
		sceneTree = GetTree();
		newScene = GD.Load<PackedScene>("res://Scenes/main_menu.tscn");
		// При нажатии на Esc вас вернет в меню
		if (Input.IsActionPressed("exit"))
			sceneTree.ChangeSceneToPacked(newScene);
	}
	
	private void OnSkipButtonPressed() 
	{
					sceneTree.ChangeSceneToPacked(newScene);

	}
}
