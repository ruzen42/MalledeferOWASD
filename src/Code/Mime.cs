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
		//if (saves.Noise > 60)
			//Kill();
	}
	
	private void dump()
	{
		GetNode<AudioStreamPlayer>("../SoundForKill").Playing = true;
	}

	private void Kill()
	{
		sceneTree = GetTree();
		newScene = GD.Load<PackedScene>("res://Scenes/dead_screen.tscn");
		sceneTree.ChangeSceneToPacked(newScene);
	}
}
