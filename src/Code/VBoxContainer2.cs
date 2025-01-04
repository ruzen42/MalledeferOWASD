using Godot;
using System;

public partial class VBoxContainer2 : VBoxContainer
{
	int Master, Sounds, Music; 

	public override void _Ready()
	{
		Master = AudioServer.GetBusIndex("Master");
		Sounds = AudioServer.GetBusIndex("Sound");
		Music = AudioServer.GetBusIndex("Music");

		AudioServer.SetBusVolumeDb(Master, saves.MasterVolume); 
		AudioServer.SetBusVolumeDb(Music, saves.MusicVolume); 
		AudioServer.SetBusVolumeDb(Sounds, saves.SoundVolume); 
	}

	private void OnMasterValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(Master, value); 
		GD.Print($"Master bus volume set {value} Db");
		saves.MasterVolume = value;
	}

	private void OnSoundsValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(Sounds, value); 
		GD.Print($"Sound bus volume set {value} Db");
		saves.SoundVolume = value;
	}

	private void OnMusicValueChanged(float value)
	{
		AudioServer.SetBusVolumeDb(Music, value);
		GD.Print($"Music bus volume set {value} Db");
		saves.MusicVolume = value;
	}
}
