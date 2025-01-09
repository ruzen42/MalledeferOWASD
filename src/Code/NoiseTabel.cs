using Godot;
using System;

public partial class NoiseTabel : ProgressBar
{
	AudioStreamPlayer DoorSound;
	AudioStreamPlayer TaserSound;
	AudioStreamPlayer VentSound;
	
	bool door;
	bool taser;
	bool vent;
	double DeltaFlag;
	
	public override void _Ready()
	{
		if (saves.NightSelected <= 2) 
			QueueFree();
		DoorSound = GetNode<AudioStreamPlayer>("../../Door/OpenCloseSound");
		TaserSound = GetNode<AudioStreamPlayer>("../CameraOutput/TaserButton/TaserSound");
		if (!(saves.NightSelected == 1 || saves.NightSelected == 5)) 
			VentSound = GetNode<AudioStreamPlayer>($"../CameraOutput/SoapZhumaysynba/VentSound");
	}
	
	public override void _Process(double delta)
	{
		Value = saves.Noise;
		if (DoorSound.Playing && !door )
		{
			DeltaFlag = delta; 
			saves.Noise += 20;
			door = true;
		}
		else if (!DoorSound.Playing && door)
		{
			door = false;
			saves.Noise -= 20;
		}
		
		if (TaserSound.Playing && !taser )
		{
			DeltaFlag = delta; 
			saves.Noise += 30;
			taser = true;
		}
		else if (!TaserSound.Playing && taser)
		{
			door = false;
			saves.Noise -= 30;
		}
		
		if (VentSound.Playing && !vent )
		{
			DeltaFlag = delta; 
			saves.Noise += 30;
			vent = true;
		}
		else if (!VentSound.Playing && vent)
		{
			vent = false;
			saves.Noise -= 30;
		}
	}
}
