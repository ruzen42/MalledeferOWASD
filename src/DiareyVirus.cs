using Godot;
using System;

public partial class DiareyVirus : Sprite2D
{
	public override void _Ready()
	{
		if (saves.SelectedNight < 5)
			QueueFree();
	}

	public override void _Process(double delta)
	{
		i
	}
}
