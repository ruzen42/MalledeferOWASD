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

		TaserSound = GetNode<AudioStreamPlayer>($"../Taser_Button/Taser_Sound");
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

		Textures[0] = (Texture2D)ResourceLoader.Load("res://Sprites/br/BR3500_1.png");
		Textures[1] = (Texture2D)ResourceLoader.Load("res://Sprites/br/br3500_2.png");
		Textures[2] = (Texture2D)ResourceLoader.Load("res://Sprites/br/br3500_3.png");
	}

	public override void _Process(double delta)
	{
		Camera();
		if (Input.IsActionJustPressed("taser")) _on_taser_used();
		if (isWaiting) return;
		else NextPhase();
	}

	private void OnTimerTimeout()
	{
		isWaiting = false;
	}

	private void OnTaserTimerTimeout()
	{
		isTaserEnable = true;
	}

	private void Camera()
	{
		if (saves.SelectedCamera == 0) 
		{
			Visible = true;
		}
		else 
		{
			Visible = false;
		}
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
		timer.Start();
	}

	private void GeneratorOff()
	{
		if (Door.Animation == "Close")
		{
			Door.Animation = "Fuck";
		}
		else if (Door.Animation == "Open")
		{
			Door.Animation = "Null";
		}
		saves.Power = false;
		UI.Visible = false;
		FanSound.Playing = false;
		GenOff.Playing = true;
		GD.Print("generator off");
	}

	private void ChangeTexture(byte index)
	{
		if (index >= 3) return;

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
			default:
				min = 29;
				max = 32;
				break;
			case 1:
				min = 30;
				max = 33;
				break;
			case 2:
				min = 28;
				max = 32;
				break;
			case 3:
				min = 27;
				max = 30;
				break;
			case 4:
				min = 26;
				max = 29;
				break;
			case 5:
				min = 25;
				max = 28;
				break;
			case 6:
				min = 23;
				max = 26;
				break;
			case 7:
				min = 22;
				max = 25;
				break;
		}
		max/=(byte)2;
		min/=(byte)2;
		WaitTaser = (short)(max * 2.5);
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
		{
			Sounds.Playing = true;
		}
	}
}
