using Godot;
using System;

public partial class ColorRect : Godot.ColorRect {
	private byte modulate = 255;
	private bool increasing = false; 
	private bool hasCompleted = false; 

	public override void _Ready() {
		Modulate = new Color(1, 1, 1, modulate / 255f);
	}

	public override void _Process(double delta) {
		if (hasCompleted) return; 

		if (increasing) {	
			modulate = (byte)(modulate + 1);
			if (modulate >= 255) {
				modulate = 255; 
				increasing = false; 
			}
		} else {
			modulate = (byte)(modulate - 1);
			if (modulate <= 0) {
				modulate = 0; 
				increasing = true; 
				hasCompleted = true; 
			}
		}
		
		Modulate = new Color(1, 1, 1, modulate / 255f);
	}
}
