using Godot;
using System;

public partial class Options_Menu : VBoxContainer {
	
	private const string InviteTG = "https://t.me/OWASDMalledefer";
	private const string InviteDS = "https://discord.gg/Sk4n9hJCBK";
	
	private void _on_options_button_button_up() {
		ShowOptionsMenuButtons();
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
	
	private void _on_back_button_up() {
		HideOptionsMenuButtons();
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
	
	private void _on_option_button_item_selected(long index) {	
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
		switch(index) {
			case 1:
				GD.Print("1920x1080 set");
				DisplayServer.WindowSetSize(new Vector2I(1920, 1080));
				break;
			case 2:
				GD.Print("1152x648 set");
				DisplayServer.WindowSetSize(new Vector2I(1152, 648));
				break;
			case 5:
				GD.Print("800x600 set");
				DisplayServer.WindowSetSize(new Vector2I(800, 600));
				break;
			case 6:
				GD.Print("1440x1080 set");
				DisplayServer.WindowSetSize(new Vector2I(1440, 1080));
				break;	
		}
	}
	
	private void _on_fullscreen_button_button_up() {
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}
	
	private void _on_fullscreen_button_button_down() {
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
	}
	
	private void _on_help_us_pressed() {
		OS.ShellOpen(InviteTG);
	}
	
	private void _on_help_us_2_pressed() {
		OS.ShellOpen(InviteDS);
	}
	
	void HideOptionsMenuButtons() { Visible = false; }
	void ShowOptionsMenuButtons() { Visible = true; }
}
