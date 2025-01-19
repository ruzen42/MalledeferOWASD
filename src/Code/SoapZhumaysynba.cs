using Godot;
using System;

public partial class SoapZhumaysynba : Sprite2D
{
	Button VentPower;
	Label Oxygen;
	Timer timer, simer;
	AudioStreamPlayer PleaseVent, VentSound;
	float og; // Кислород
	byte min, max;
	Random Rand;
	bool vent, IsSoapActive;
	float mod;
	
	private void Kill()
	{
		timer.QueueFree();
		simer.QueueFree();
		ChangeScene("res://Scenes/dead_screen.tscn");
	}
	
	public override void _Ready()
	{
		if (saves.NightSelected == 1 || saves.NightSelected == 5) 
			QueueFree();
		OxygenMath();
		WaitTimeMath();
		
		Rand = new Random();
		timer = new Timer
		{
			Autostart = true,
			WaitTime = 1,
			OneShot = false
		};

		simer = new Timer
		{
			Autostart = true,
			WaitTime = Rand.Next(min, max),
			OneShot = false
		};

		AddChild(timer);
		timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));

		AddChild(simer);
		simer.Connect("timeout", new Callable(this, nameof(OnSimerTimeout)));

		Oxygen = GetNode<Label>("Phone/Oxygen");
		VentPower = GetNode<Button>("VentPower");
		PleaseVent = GetNode<AudioStreamPlayer>("PleaseVent");
		VentSound = GetNode<AudioStreamPlayer>("VentSound");
	}

	private void OnSimerTimeout()
	{
		// GetNode<AudioStreamPlayer>("VentilSound").Play();
	}

	private void OnTimerTimeout()
	{
		if (IsSoapActive)	
			og -= 0.35f;

		if (vent) 
			og +=0.15f;

		if (og > 20.98f)
		{
			VentSound.Playing = false;
			og = 20.98f;
			vent = false;
		} 

		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("vent"))	Onvent_powerpressed();
		Camera();
		og = (float)Math.Round(og, 3);
		Oxygen.Text = $"{og}%";
		if (og < 13.35) 
		{
			Kill();
		}
		else if (og < 16.4)
		{
			if (PleaseVent.Playing == false)	PleaseVent.Play();
		}
		else
		{
			PleaseVent.Playing = false;
		}
	}

	private void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);

		sceneTree.ChangeSceneToPacked(newScene);
	}

	private void Camera()
	{
		if (saves.SelectedCamera == 6) 
		{
			Visible = true;
		}
		else 
		{
			Visible = false;
		}
	}

	private void WaitTimeMath()
	{
		// Зависимо от ночи скорость Soap изменяется
		switch (saves.NightSelected)
		{
			default:
				min = 50;
				max = 100;
				break;
			case 1:
				min = 50;
				max = 100;
				break;
			case 2:
				min = 45;
				max = 90;
				break;
			case 3:
				min = 40;
				max = 80;
				break;
			case 4:
				min = 35;
				max = 70;
				break;
			case 6:
				min = 27;
				max = 55;
				break;
			case 7:
				min = 25;
				max = 50;
				break;
		}
	}

	private void Onvent_powerpressed()
	{
		VentSound.Play();
		IsSoapActive = false;
		vent = true;
		simer.WaitTime = Rand.Next(min, max);
		simer.Start();
	}

	private void OnVentilSoundFinished()
	{
		if (!VentSound.Playing)	IsSoapActive = true;
		simer.WaitTime = Rand.Next(min, max);
		simer.Start();
	}

	private void OxygenMath()
	{
		switch (saves.NightSelected)
		{
			default:
				og = 20.0f; // default value if none of the cases match
				break;
			case 1:
				og = 20.56f;
				break;
			case 2:
				og = 20.3f;
				break;
			case 3:
				og = 20.0f;
				break;
			case 4:
				og = 19.5f;
				break;
			case 6:
				og = 19.0f;
				break;
			case 7:
				og = 18.8f;
				break;
		}
	}
}
