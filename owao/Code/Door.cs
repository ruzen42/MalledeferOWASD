using Godot;
using System;

public partial class Door : ColorRect {
	
	public override void _Process(double delta) {
		if (Input.IsActionPressed("door")) {
			_on_door_button_pressed();
		}
	}
	
	public void _on_door_button_pressed() {
		Visible = !Visible;
	}
}
