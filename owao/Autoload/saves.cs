using Godot;
using System;

public partial class saves : Node 
{
	static ConfigFile Config;
	static string PathToSaveFile = "user://Save.cfg";
	static string SectionName = "OWASD_Saves";
	static string OptionsName = "OWASD_Options";
	private static string pass = "cheatcode"; // Читиритеu

	public static byte NightSelected = 1;
	public static int SelectedCamera;
	public static bool Power = true;
	public static float Noise = 20.0f;

	public static byte NightsCompleted ;

	public static bool FullScreen;
	public static Vector2I Resolution;

	public static float MasterVolume, MusicVolume, SoundVolume;

	public override void _Ready()
	{
		Config = new ConfigFile();

		try 
		{
			LoadSave();
			GD.Print("saves.cs загружен");
		}
		catch
		{
			GD.PrintErr("Ошибка при загрузке игры");
			return;
		}
		
		DisplayServer.WindowSetSize(saves.Resolution);

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
		Config.LoadEncryptedPass(PathToSaveFile, pass);
		NightsCompleted = (byte)Config.GetValue(SectionName, "NightsCompleted");
		FullScreen = (bool)Config.GetValue(OptionsName, "FullScreen", false);
		GD.Print($"FullScreen Load {FullScreen}");
		Resolution = (Vector2I)Config.GetValue(OptionsName, "Resolution");
		GD.Print($"Load Resolution{Resolution}");
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

		Config.SaveEncryptedPass(PathToSaveFile, pass);
		GD.Print("Игра Сохранена");
	}
}
