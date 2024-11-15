using Godot;

public partial class Options_Menu : VBoxContainer
{
	private const string InviteTG = "https://t.me/OWASDMalledefer";
	private const string InviteDS = "https://discord.gg/Sk4n9hJCBK";
	private const string InviteYT = "https://www.youtube.com/@denyruzen42";

	private void _on_options_button_button_up()
	{
		Visible = true;
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}

	private void _on_back_button_up()
	{
		Visible = false;
		try
		{
			saves.SaveGame();
		}
		catch
		{
			GD.PrintErr("Ошибка при сохраненииs");
		}
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}

	private void _on_option_button_item_selected(long index)
	{
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
		switch (index)
		{
			case 1:
				GD.Print("1920x1080 set");
				DisplayServer.WindowSetSize(new Vector2I(1920, 1080));
				break;
			case 2:
				GD.Print("1600x900 set");
				DisplayServer.WindowSetSize(new Vector2I(1600, 900));
				break;
			case 5:
				GD.Print("800x600 set");
				DisplayServer.WindowSetSize(new Vector2I(800, 600));
				break;
			case 6:
				GD.Print("1366x786 set");
				DisplayServer.WindowSetSize(new Vector2I(1366, 786));
				break;
			case 8:
				GD.Print("800x600 set");
				DisplayServer.WindowSetSize(new Vector2I(800, 600));
				break;
			case 7:
				GD.Print("1440sх1080 set");
				DisplayServer.WindowSetSize(new Vector2I(1440, 1080));
				break;
		}
		saves.Resolution = DisplayServer.WindowGetSize();
	}

	private void _on_fullscreen_button_button_up()
	{
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen); 
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
		saves.FullScreen = true;
	}

	private void _on_fullscreen_button_button_down()
	{
		DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		saves.FullScreen = false;
	}

	private void _on_help_us_pressed()
	{
		OS.ShellOpen(InviteTG);
	}

	private void _on_help_us_2_pressed()
	{
		OS.ShellOpen(InviteDS);
	}

	private void _on_help_us_3_pressed()
	{
		OS.ShellOpen(InviteYT);
	}
}
