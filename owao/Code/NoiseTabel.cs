using Godot;
using System;

public partial class NoiseTabel : ProgressBar
{
	AudioStreamPlayer DoorSound;
	bool door;
	
	public override void _Ready()
	{
			DoorSound = GetNode<AudioStreamPlayer>("../../Door/OpenCloseSound");
	}
	
	public override void _Process(double delta)
	{
		Value = saves.Noise;
		if (DoorSound.Playing == true && door == false)
		{
			saves.Noise += 20;
			door = true;
		}
		else if (door)
		{
			door = false;
		}
		else
		{
			saves.Noise -= 20; 
		}
	}
}
