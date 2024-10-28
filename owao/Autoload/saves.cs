using Godot;
using System;

public partial class saves : Node 
{
	static ConfigFile Config;
	static string PathToSaveFile = "user://OwASD_Save.cfg";
	static string SectionName = "OWASD_GameSaves";
	static string OptionsName = "OWASD_Options";

	public static byte NightSelected = 1;
	public static int SelectedCamera;
	public static bool Power = true;

	public static byte NightsCompleted ;

	public static bool FullScreen;
	public static Vector2I Resolution;

	public static float MasterVolume, MusicVolume, SoundVolume;

	public override void _Ready()
	{
		Config = new ConfigFile();

		try 
		{
			Config.Load(PathToSaveFile);
			LoadSave();
			GD.Print("saves.cs загружен");
		}
		catch
		{
			GD.PrintErr("Ошибка при загрузке игры");
		}

		if (FullScreen)
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen); 
		}
		else
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		}
	}

	public static void LoadSave()
	{
		NightsCompleted = (byte)Config.GetValue(SectionName, "NightsCompleted");
		FullScreen = (bool)Config.GetValue(OptionsName, "FullScreen", false);
		GD.Print($"FullScreen Load {FullScreen}");
		Resolution = (Vector2I)Config.GetValue(OptionsName, "Resolution", new Vector2I(1920, 1080));
		MasterVolume = (float)Config.GetValue(OptionsName, "MasterVolume", 0.0f);
		MusicVolume = (float)Config.GetValue(OptionsName, "MusicVolume", 0.0f);
		SoundVolume = (float)Config.GetValue(OptionsName, "SoundVolume", 0.0f);
	}

	public static void SaveGame()
	{
		Config.SetValue(SectionName, "NightsCompleted", NightsCompleted);
		Config.SetValue(OptionsName, "FullScreen", FullScreen);
		GD.Print($"FullScreen save {FullScreen}");
		Config.SetValue(OptionsName, "Resolution", Resolution);
		Config.SetValue(OptionsName, "MasterVolume", MasterVolume);
		Config.SetValue(OptionsName, "MusicVolume", MusicVolume);
		Config.SetValue(OptionsName, "SoundVolume", SoundVolume);

		Config.Save(PathToSaveFile);
		GD.Print("Игра Сохранена");
	}
}
