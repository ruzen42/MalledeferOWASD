using Godot;

public partial class UI : Control
{
	private AnimatedSprite2D laptop;
	private Sprite2D cameraOutput;
	private CanvasItem changeCameraButton;
	private AudioStreamPlayer soundPlayer;

	public override void _Ready()
	{
		laptop = GetNode<AnimatedSprite2D>("LaptopAnimation");
		cameraOutput = GetNode<Sprite2D>("Camera_Output");
		changeCameraButton = GetNode<CanvasItem>("Change_Camera_Button");
		soundPlayer = GetNode<AudioStreamPlayer>("Laptop_up");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("laptop"))
		{
			_on_cameras_button_mouse_entered();
		}
	}

	private void _on_cameras_button_mouse_entered()
	{
		// Функция для открытия планшета
		if (cameraOutput.Visible == true)
		{
			cameraOutput.Visible = false;
			changeCameraButton.Visible = false;
			laptop.Play("down");
		}
		else
		{
			laptop.Play("up");
		}
		soundPlayer.Play();
	}

	private void _on_laptop_animation_finished()
	{
		if (laptop.Animation == "down")
		{
			GD.Print("Animation == Down");
		}
		else
		{
			GD.Print("Laptop up alt");
			cameraOutput.Visible = true;
			changeCameraButton.Visible = true;
		}
	}
}
