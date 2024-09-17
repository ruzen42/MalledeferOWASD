using Godot;
using System;

public partial class UI : Control {
	
	private AnimatedSprite2D laptop;
	private Sprite2D cameraOutput;
	private CanvasItem changeCameraButton;
	private AudioStreamPlayer soundPlayer;

	public override void _Ready() {
		laptop = GetNode<AnimatedSprite2D>("LaptopAnimation");
		cameraOutput = GetNode<Sprite2D>("Camera_Output");
		changeCameraButton = GetNode<CanvasItem>("Change_Camera_Button");
		soundPlayer = GetNode<AudioStreamPlayer>("Laptop_up");
	}
		
	private void _on_cameras_button_mouse_entered() {
		
		if (cameraOutput.Visible == true) {
			cameraOutput.Visible = false;
			changeCameraButton.Visible = false;
			laptop.Play("down");
		} else {
			laptop.Play("up");
		}
		soundPlayer.Play();
	}
	
	private void _on_laptop_animation_finished() {
		if (laptop.Animation == "down") {
		} else {
			GD.Print("Laptop up alt");
			cameraOutput.Visible = true;
			changeCameraButton.Visible = true;
		}
	}
}
