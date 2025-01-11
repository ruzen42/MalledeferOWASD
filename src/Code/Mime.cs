using Godot;
using System;

public partial class Mime : Sprite2D
{
	SceneTree sceneTree;
	PackedScene newScene;
	Texture2D Petlu;

	public override void _Ready()
	{
		if (saves.NightSelected < 3) 
			QueueFree();
		Petlu = (Texture2D)ResourceLoader.Load("res://Sprites/Mime/MimeSprite1.png");
	}
	
	public override void _Process(double delta)
	{
		if (saves.SelectedCamera == 5)
			Visible = true;
		else 
			Visible = false;
		if (saves.Noise > 60)
			Kill();
	}

	private void Kill()
	{
		Texture = Petlu;
		GetNode<AudioStreamPlayer>("../SoundForKill").Play();
	}
	
	private void DIE()
	{
		var SceneTree = GetTree();
		var Scene = GD.Load<PackedScene>("res://Scenes/dead_screen.tscn");
		SceneTree.ChangeSceneToPacked(Scene);
	}
}
