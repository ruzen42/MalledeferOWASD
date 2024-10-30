using Godot;
using System;

public partial class NoiseTabel : ProgressBar
{
	public override void _Process(double delta)
	{
		Value = saves.Noise;
	}
}
