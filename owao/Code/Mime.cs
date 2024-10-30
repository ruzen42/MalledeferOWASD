using Godot;
using System;

public partial class Mime : Sprite2D
{
	SceneTree sceneTree;
	PackedScene newScene;

	public override void _Ready()
	{
		sceneTree = GetTree();
		newScene = GD.Load<PackedScene>("res://Scenes/dead_screen.tscn");
		if (saves.NightSelected < 3) QueueFree();
	}
	
	public void dump()
	{
		GetNode<AudioStreamPlayer>("../SoundForKill").Playing = true;
	}

	private void DIE()
	{
		sceneTree.ChangeSceneToPacked(newScene);
	}
}
