using Godot;

public partial class Main_Menu_Buttons : VBoxContainer
{
    // Этот класс по моему объективно понятен и не трубуется в объяснении
    public void _on_play_button_button_up()
    {
        HideMainMenuButtons();
        GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
    }

    public void _on_options_button_button_up()
    {
        HideMainMenuButtons();
        GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
    }

    public void _on_quit_button_button_up()
    {
        GetTree().Quit();
        GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
    }

    public void _on_back_button_button_up()
    {
        ShowMainMenuButtons();
        GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
    }

    private void _on_back_button_up()
    {
        ShowMainMenuButtons();
        GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
    }

    public void HideMainMenuButtons() { Visible = false; }
    public void ShowMainMenuButtons() { Visible = true; }
}








