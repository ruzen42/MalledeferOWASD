using Godot;
using System;

public partial class EndGame : Node2D
{
	private void ChangeScene(string scenePath) {
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);
			
		sceneTree.ChangeSceneToPacked(newScene);
	}
	
	private void _on_timer_timeout() {
		ChangeScene("res://Scenes/main_menu.tscn");
	}
}
