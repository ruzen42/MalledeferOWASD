using Godot;
using System;

public partial class Mime : Sprite2D
{
	SceneTree sceneTree;
	PackedScene newScene;

	public override void _Ready()
	{
		if (saves.NightSelected < 3) 
			QueueFree();
	}
	
	public override void _Process(double delta)
	{
		if (saves.Noise > 60)
			Kill();
	}

	private void Kill()
	{
		GetNode<AudioStreamPlayer>("../SoundForKill").Play();
	}
	
	private void DIE()
	{
		var SceneTree = GetTree();
		var Scene = GD.Load<PackedScene>("res://Scenes/dead_screen.tscn");
		SceneTree.ChangeSceneToPacked(Scene);
	}
}
