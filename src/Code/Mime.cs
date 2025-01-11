using Godot;
using System;

public partial class Mime : Sprite2D
{
	SceneTree sceneTree;
	PackedScene newScene;
	Sprite2D MimeSprite1;
	bool killflag = true;
	
	public override void _Ready()
	{
		MimeSprite1 = GetNode<Sprite2D>($"../MimeSprite1");
		if (saves.NightSelected < 3)
		{ 
			MimeSprite1.QueueFree();
			QueueFree();
		}
	}
	
	public override void _Process(double delta)
	{
		if (saves.SelectedCamera == 5 && killflag)
		{
			MimeSprite1.Visible = true;
			Visible = true;
		}
		else if (saves.SelectedCamera == 5)
		{
			MimeSprite1.Visible = true;
		}
		else 
		{ 
			MimeSprite1.Visible = false;
			Visible = false;
		}
		
		if (saves.Noise > 60)
			Kill();
	}

	private void Kill()
	{
		killflag = false;
		Visible = false;
		GetNode<AudioStreamPlayer>("../SoundForKill").Play();
	}
	
	private void DIE()
	{
		var SceneTree = GetTree();
		var Scene = GD.Load<PackedScene>("res://Scenes/dead_screen.tscn");
		SceneTree.ChangeSceneToPacked(Scene);
	}
}
