using Godot;
using System;

public partial class Camera2d : Camera2D {
	public override void _Process(double delta) {
		Position = GetViewport().GetMousePosition();
	}
}
