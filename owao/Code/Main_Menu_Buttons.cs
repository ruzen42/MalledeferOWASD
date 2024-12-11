using Godot;

public partial class Main_Menu_Buttons : VBoxContainer
{
	private Vector2 OutPosition = new Vector2(-489.0f, 304.0f);
	private Vector2 StartPosition; // x: 414, y: 296
	private Vector2 TargetPosition;
	
	private const float Speed = 3.0f;
	private float progress;

	private bool Moving;
	
	// Этот функции по моему объективно понятены и не трубуется в объяснении
	public void _on_play_button_button_up() { GoOutScene(); }

	public void _on_options_button_button_up() { GoOutScene(); }

	public void _on_quit_button_button_up()
	{
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
		GetTree().Quit();
	}

	public void _on_back_button_button_up() { GoInScene(); }

	private void _on_back_button_up() {	GoInScene(); }

	private void GoOutScene()
	{
		TargetPosition = OutPosition;
		Visible = false;
		Moving = true;
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
	
	private void GoInScene()
	{
		TargetPosition = StartPosition;
		Moving = true;
		Visible = true;
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
	
	public override void _Ready()
	{
		StartPosition = Position;
		TargetPosition = StartPosition;
	}

	public override void _Process(double delta)
	{
		if (progress < 1.0f && Moving)
		{
			progress += Speed * (float)delta;
			progress = Mathf.Clamp(progress, 0.0f, 1.0f);
			
			Position = Position.Lerp(TargetPosition, progress);
		}
		else if (progress > 1.0f)
		{
			Moving = false;
		}
	}
}
