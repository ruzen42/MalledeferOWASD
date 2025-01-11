using Godot;
using System;

public partial class saves : Node 
{
	static ConfigFile Config;
	static string PathToSaveFile = "user://Saves.cfg";
	static string SectionName = "Saves";
	static string OptionsName = "Options";
	private static string pass = "cheatcode"; // Читирите

	public static byte NightSelected = 1;
	public static int SelectedCamera;
	public static bool Power = true;
	public static float Noise = 20.0f;
	public static float Temp = 16.0f;

	public static long GameOpen, Deaths, Saves;
	public static byte NightsCompleted;

	public static bool FullScreen;
	public static Vector2I Resolution;

	public static float MasterVolume, MusicVolume, SoundVolume;

	public override void _Ready()
	{
		Config = new ConfigFile();

		try 
		{
			LoadSave();
			GD.Print("Game successfully loaded");
		}
		catch
		{
			GD.PrintErr("Error with load");
			return;
		}
		
		++GameOpen;
		SaveGame();
		GD.Print($"Game opened: {GameOpen}");
		
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
		GameOpen = (long)Config.GetValue(SectionName, "GameOpen");
		Saves = (long)Config.GetValue(SectionName, "Saves");
		Deaths = (long)Config.GetValue(SectionName, "Deaths");

		FullScreen = (bool)Config.GetValue(OptionsName, "FullScreen", false); //GD.Print($"FullScreen Load {FullScreen}");
		Resolution = (Vector2I)Config.GetValue(OptionsName, "Resolution"); //GD.Print($"Load Resolution{Resolution}");
		
		MasterVolume = (float)Config.GetValue(OptionsName, "MasterVolume", 0.0f);
		MusicVolume = (float)Config.GetValue(OptionsName, "MusicVolume", 0.0f);
		SoundVolume = (float)Config.GetValue(OptionsName, "SoundVolume", 0.0f);
	}

	public static void SaveGame()
	{
		Config.SetValue(SectionName, "NightsCompleted", NightsCompleted);
		Config.SetValue(SectionName, "Deaths", Deaths);
		Config.SetValue(SectionName, "Saves", Saves);
		Config.SetValue(SectionName, "GameOpen", GameOpen);
		GD.Print($"Statistic values save: \n\tNightsCompleted {NightsCompleted}, \n\tDeaths {Deaths}, \n\tSaves {Saves}");

		Config.SetValue(OptionsName, "FullScreen", FullScreen);
		GD.Print($"Fullscreen value save: {FullScreen}");
		Config.SetValue(OptionsName, "Resolution", Resolution);
		GD.Print($"Resolution value save: {Resolution}");
		
		Config.SetValue(OptionsName, "MasterVolume", MasterVolume);
		Config.SetValue(OptionsName, "MusicVolume", MusicVolume);
		Config.SetValue(OptionsName, "SoundVolume", SoundVolume);
		GD.Print($"Sound settings values save: \n\tMaster {MasterVolume}, \n\tMusic {MusicVolume}, \n\tSound {SoundVolume}");

		Config.SaveEncryptedPass(PathToSaveFile, pass);
		GD.Print("Game saved successfully");
		++Saves;
	}
}
