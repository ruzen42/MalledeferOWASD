using Godot;
using System;

public partial class NoiseTabel : ProgressBar
{
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Value = saves.Noise;
	}
}
