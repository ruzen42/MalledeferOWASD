using Godot;
using System;

public partial class GameLoad : Control {
	
	private void ChangeScene(string scenePath) {
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);
			
		sceneTree.ChangeSceneToPacked(newScene);
	}
	
	private void _on_timer_timeout() {
		ChangeScene("res://Scenes/main_menu.tscn");
	}
	
	public override void _Process(double delta) {
		if (Input.IsActionPressed("exit")) {
			ChangeScene("res://Scenes/main_menu.tscn");
		}
	}
}
