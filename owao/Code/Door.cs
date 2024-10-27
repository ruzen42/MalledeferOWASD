using Godot;
using System;

public partial class Door : AnimatedSprite2D
{
	private byte waittime;
	private Timer limer;
	private Timer dimer;
	private bool DoorIsBlocked;
	private AudioStreamPlayer DieSound;

	public override void _Ready()
	{
		WaitTimeMath();
		DieSound = GetNode<AudioStreamPlayer>("DieSound");
		// Initialize and configure the timers
		limer = new Timer
		{
			Autostart = false,
			WaitTime = waittime,
			OneShot = false
		};

		dimer = new Timer
		{
			Autostart = false,
			WaitTime = 88,
			OneShot = false
		};

		// Add timers to the node tree so they function correctly
		AddChild(limer);
		limer.Connect("timeout", new Callable(this, nameof(OnLimerTimeout)));
		AddChild(dimer);
		dimer.Connect("timeout", new Callable(this, nameof(OnDimerTimeout)));
	}

	private void WaitTimeMath()
	{
		switch (saves.NightSelected)
		{
			default:
				waittime = 27;
				break;
			case 1:
				waittime = 27;
				break;
			case 2:
				waittime = 23;
				break;
			case 3:
				waittime = 20;
				break;
			case 4:
				waittime = 22;
				break;
			case 5:
				waittime = 20;
				break;
			case 6:
				waittime = 15;
				break;
			case 7:
				waittime = 13;
				break;
		}

		waittime*=2;
	}

	private void DoorBor()
	{
		if (Animation == "Open")
		{
			if (DoorIsBlocked)
			{
				GD.Print("Door is blocked");
			}
			else
			{
				GD.Print("Door Closed");
				Animation = "Close";
				Play();
				limer.Start();
			}
		}
		else
		{
			GD.Print("Door Open");
			Animation = "Open";
			Play();
			limer.Stop();
		}
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("door"))
		{
			DoorBor();
		}
	}

	private void OnLimerTimeout()
	{
		DieSound.Play();
		Animation = "Open";
		Play();
		DoorIsBlocked = true;
		dimer.Start();
		limer.Stop();
	}

	private void OnDimerTimeout()
	{
		DoorIsBlocked = false;
	}
	
	private void OnDoorReload()
	{
		DoorBor();
	}
}
