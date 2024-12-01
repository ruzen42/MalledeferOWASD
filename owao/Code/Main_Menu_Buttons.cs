using Godot;

public partial class Main_Menu_Buttons : VBoxContainer
{
	// Этот класс по моему объективно понятен и не трубуется в объяснении
	public void _on_play_button_button_up() { GoOutScene(); bbbbbb}

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
		Visible = false;
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
	
	private void GoInScene()
	{
		Visible = true;
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
}
