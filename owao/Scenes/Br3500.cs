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
	
	private Control UI; 
	private Sprite2D background; 
	
	public override void _Ready()
	{
		UI = GetNode<Control>("../..");
		background = GetNode<Sprite2D>("../../../Real_background");
		
		WaitTimeMath();
		timer = new Timer();
		timer.Autostart = true;
		timer.WaitTime = rand.Next(min, max);
		timer.OneShot = false;
		AddChild(timer);
		timer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
		
		Textures[0] = (Texture2D)ResourceLoader.Load("res://Sprites/br/бр1.png");
		Textures[1] = (Texture2D)ResourceLoader.Load("res://Sprites/br/бр2.png");
		Textures[2] = (Texture2D)ResourceLoader.Load("res://Sprites/br/бр3.png");
	}

	public override void _Process(double delta)
	{
		Camera();
		if (isWaiting) return;
		else NextPhase();
	}
	
	private void OnTimerTimeout()
	{
		isWaiting = false;
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
		phase += 1;
		if (phase == 2) GeneratorOff(); 
		ChangeTexture(phase);
		isWaiting = true;
		timer.Start();
	}
	
	private void GeneratorOff()
	{
		GD.Print("generator off");
	}
	
	private void ChangeTexture(byte index)
	{
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
				min = 87;
				max = 97;
				break;
			case 1:
				min = 90;
				max = 100;
				break;
			case 2:
				min = 86;
				max = 96;
				break;
			case 3:
				min = 82;
				max = 92;
				break;
			case 4:
				min = 78;
				max = 88;
				break;
			case 5:
				min = 74;
				max = 84;
				break;
			case 6:
				min = 70;
				max = 80;
				break;
			case 7:
				min = 66;
				max = 76;
				break;
		}
	}
}
