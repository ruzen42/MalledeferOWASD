using Godot;
using System;

public partial class Br3500 : Sprite2D
{
	private Texture2D[] Textures = new Texture2D[3];
	private byte phase = 0;
	private Timer timer;
	private byte min;
	private byte max;
	private Random rand = new Random();
	private bool isWaiting = true;

	private AudioStreamPlayer TaserSound;
	private AudioStreamPlayer GenOff;
	private AudioStreamPlayer FanSound;
	private AudioStreamPlayer Sounds;

	private Sprite2D background; 
	private AnimatedSprite2D Door;

	private Control UI; 
	private Timer TaserTimer;
	private bool isTaserEnable = true;
	private short WaitTaser = 1;

	public override void _Ready()
	{
		UI = GetNode<Control>("../..");

		TaserSound = GetNode<AudioStreamPlayer>($"../TaserButton/TaserSound");
		FanSound = GetNode<AudioStreamPlayer>("../../../Fan_Sound");
		GenOff = GetNode<AudioStreamPlayer>("../../../Generator_Off");
		Sounds = GetNode<AudioStreamPlayer>("../../Sounds");
		
		Door = GetNode<AnimatedSprite2D>("../../../Door");
		background = GetNode<Sprite2D>("../../../Real_background");

		WaitTimeMath();
		timer = new Timer();
		timer.Autostart = true;
		timer.WaitTime = rand.Next(min, max);
		timer.OneShot = false;
		AddChild(timer);
		timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));

		TaserTimer = new Timer();
		TaserTimer.Autostart = false;
		TaserTimer.WaitTime = WaitTaser;
		TaserTimer.OneShot = false;
		AddChild(TaserTimer);
		TaserTimer.Connect("timeout", new Callable(this, nameof(OnTaserTimerTimeout)));

		for (int i = 1; i <=3; ++i) 
		Textures[i-1] = (Texture2D)ResourceLoader.Load($"res://Sprites/BR3500Textures/BR3500_{i}.png");

	}

	public override void _Process(double delta)
	{
		Camera();
		if (Input.IsActionJustPressed("taser")) _on_taser_used();
		if (isWaiting) return;
		else NextPhase();
	}

	private void OnTimerTimeout() { isWaiting = false; }

	private void OnTaserTimerTimeout() { isTaserEnable = true; }

	private void Camera()
	{
		if (saves.SelectedCamera == 0) 
			Visible = true;
		else 
			Visible = false;
	}

	private void NextPhase()
	{
		if (phase == 3) 
		{
			GeneratorOff();
			phase = 0;
		}
		phase += 1; 
		ChangeTexture(phase);
		isWaiting = true;
		timer.WaitTime = rand.Next(min, max);
		timer.Start();
	}

	private void GeneratorOff()
	{
		if (Door.Animation == "Close")
			Door.Animation = "Fuck";
		else if (Door.Animation == "Open")
			Door.Animation = "Null";
		
		saves.Power = false;
		UI.Visible = false;
		FanSound.Playing = false;
		GenOff.Playing = true;
		GD.Print("Generator off");
		timer.QueueFree();
	}

	private void ChangeTexture(byte index)
	{
		if (index >= 3) 
			return;

		try 
		{
			Texture = Textures[index];
		}
		catch
		{
			GD.PrintErr("Error change texture on br3500");
		}
	} 

	private void WaitTimeMath()
	{
		// Зависимо от ночи скорость BR3500 изменяется
		switch (saves.NightSelected)
		{
			case 1:
				min = 35;
				max = 25;
				break;
			case 2:
				min = 31;
				max = 24;
				break;
			case 3:
				min = 27;
				max = 23;
				break;
			case 4:
				min = 23;
				max = 22;
				break;
			case 5:
				min = 19;
				max = 21;
				break;
			case 6:
				min = 15;
				max = 20;
				break;
			case 7:
				min = 10;
				max = 18;
				break;
		}
		min/=2;
		WaitTaser = (short)max;
	}

	private void _on_taser_used()
	{
		if (isTaserEnable)
		{
			TaserSound.Playing = true;
			phase = 0;
			ChangeTexture(phase);
			isTaserEnable = false;
			TaserTimer.Start();
			isWaiting = true;
			timer.Start();
		}
		else
			Sounds.Playing = true;
	}
}
