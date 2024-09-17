using Godot;
using System;

public partial class Camera_Output : Sprite2D {
	public Texture2D[] cameraTextures = new Texture2D[7];
	public AudioStreamPlayer soundPlayer;
	
	[Export]
	byte cameraSelected = 5; 
	
	public override void _Ready() {		
		cameraTextures[0] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 1.jpg");
		cameraTextures[1] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 2.jpg");
		cameraTextures[2] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 3.jpg");
		cameraTextures[3] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 4.jpg");
		cameraTextures[4] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 5.jpg");
		cameraTextures[5] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera_remastered_6.jpg");
		cameraTextures[6] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 7.jpg");
		soundPlayer = GetNode<AudioStreamPlayer>("Camera");
		ChangeCameraTextureNoSound(cameraSelected);
	}
	
	public override void _Process(double delta) {
		if (Visible) {
			if (Input.IsActionPressed("cam1")) {
				ChangeCameraTexture(0);
			}
			if (Input.IsActionPressed("cam2")) {
				ChangeCameraTexture(1);
			}
			if (Input.IsActionPressed("cam3")) {
				ChangeCameraTexture(2);
			}
			if (Input.IsActionPressed("cam4")) {
				ChangeCameraTexture(3);
			}
			if (Input.IsActionPressed("cam5")) {
				ChangeCameraTexture(4);
			}
			if (Input.IsActionPressed("cam6")) {
				ChangeCameraTexture(5);
			}
			if (Input.IsActionPressed("cam7")) {
				ChangeCameraTexture(6);
			}
			
		}
	}
	
		private void _on_first_camera_button_button_down() {
			cameraSelected = 0; 
			ChangeCameraTexture(cameraSelected);
		}
		
		private void _on_second_camera_button_button_down() {
			cameraSelected = 1;
			ChangeCameraTexture(cameraSelected);
		}
		
		private void _on_three_camera_button_button_down() {
			cameraSelected = 2;
			ChangeCameraTexture(cameraSelected);
		}
		
		private void _on_fourth_camera_button_button_down() {
			cameraSelected = 3;
			ChangeCameraTexture(cameraSelected);
		}
		private void _on_fifth_camera_button_button_down() {
			cameraSelected = 4;
			ChangeCameraTexture(cameraSelected);
		}
		
		private void _on_sixth_camera_button_button_down() {
			cameraSelected = 5;
			ChangeCameraTexture(cameraSelected);
		}
		
		private void _on_seventh_camera_button_button_down() {
			
			cameraSelected = 6;
			ChangeCameraTexture(cameraSelected);
		}
		
	private void ChangeCameraTexture(int cameraIndex) {
		soundPlayer.Play(); 
		saves.SelectedCamera = cameraIndex;
		if (cameraIndex >= 0 && cameraIndex < cameraTextures.Length && cameraTextures[cameraIndex] != null) {
			Texture = cameraTextures[cameraIndex];
		}
	}
	
	private void ChangeCameraTextureNoSound(int cameraIndex) { 
		if (cameraIndex >= 0 && cameraIndex < cameraTextures.Length && cameraTextures[cameraIndex] != null) {
			Texture = cameraTextures[cameraIndex];
		}
	}
}
