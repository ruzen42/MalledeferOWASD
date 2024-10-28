using Godot;
// Не отключать либу System она нужна для Random
using System;

public partial class zhumaysynba : Sprite2D
{
	// Создаю объекты класса Random
	private Random _rand = new Random();
	// Этот рандом используйте для камер
	private Random _randc = new Random();
	private Texture2D[] _zhumaysynbaTextures = new Texture2D[4];
	private Timer _delayTimer;
	private AnimatedSprite2D Door;
	private int min;
	private int max;
	private bool _isWaiting = true;
	// Выбраная камера игроком относительно zhumaysynba, используется для получения
	private byte SelectedShampoo;

	public int ZhumaysynbaCamera = 0;
	//public ColorRect Door;

	public override void _Ready()
	{
		WaitTimeMath();
		Door = GetNode<AnimatedSprite2D>("../../../Door");
		_delayTimer = new Timer();
		_delayTimer.Autostart = true;
		_delayTimer.WaitTime = _rand.Next(min, max);
		_delayTimer.OneShot = false;
		_delayTimer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
		//Door = GetNode<ColorRect>("../../../Door");
		// Для теста работаспособности я отключаю функцию WaitTimeMath(); и использую следуещие дле строки

		// Создаю таймер
		AddChild(_delayTimer);
		// Начинаю отсчет
		_isWaiting = true;
		_delayTimer.Start();

		LoadTextures();
		PositionMath();
		Texture = _zhumaysynbaTextures[0];
	}

	private void PositionMath()
	{
		switch (ZhumaysynbaCamera)
		{
			case 0:
				Position = new Vector2(-85, 93);
				break;

			case 1:
				Position = new Vector2(-369, 125);
				break;

			case 2:
				Position = new Vector2(-66, 130);
				break;

			case 3:
				Position = new Vector2(117, 41);
				break;
		}
	}

	private void WaitTimeMath()
	{
		// Зависимо от ночи скорость zhumaysynba изменяется
		switch (saves.NightSelected)
		{
			default:
				min = 17;
				max = 27;
				break;
			case 1:
				min = 17;
				max = 27;
				break;
			case 2:
				min = 12;
				max = 23;
				break;
			case 3:
				min = 11;
				max = 20;
				break;
			case 4:
				min = 11;
				max = 22;
				break;
			case 5:
				min = 8;
				max = 20;
				break;
			case 6:
				min = 3;
				max = 15;
				break;
			case 7:
				min = 5;
				max = 13;
				break;
		}
	}

	private void LoadTextures()
	{
		_zhumaysynbaTextures[0] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/Zhumaysynba3.png");
		_zhumaysynbaTextures[1] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/Zhumaysynba2.png");
		_zhumaysynbaTextures[2] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/3.png");
		_zhumaysynbaTextures[3] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/Zhumaysynba1.png");
	}

	public void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);
		sceneTree.ChangeSceneToPacked(newScene);
	}

	private void TryToKill()
	{
		if (Door.Animation == "Open" || Door.Animation == "Fuck" || Door.Animation == "Null")
		{
			RemoveChild(_delayTimer);
			_delayTimer.QueueFree();
			ChangeScene("res://Scenes/dead_screen.tscn");
		}
		else
		{
			GetNode<AudioStreamPlayer>("Reload").Play();
			GD.Print("Zhumaysynba been reload");
		}
	}

	private void Misible()
	{
		switch (saves.SelectedCamera)
		{
			case 1:
				SelectedShampoo = 0;
				break;
			case 2:
				SelectedShampoo = 1;
				break;
			case 4:
				SelectedShampoo = 2;
				break;
			case 3:
				SelectedShampoo = 3;
				break;
			default:
				SelectedShampoo = 4;
				break;
		}

		if (ZhumaysynbaCamera == SelectedShampoo)
		{
			Visible = true;
		}
		else
		{
			Visible = false;
		}
	}

	private void Move()
	{
		// Это функция описывает движение zhumaysynba по камерам
		PositionMath();
		switch (ZhumaysynbaCamera)
		{
			case 0:
				ZhumaysynbaCamera = _randc.Next(1, 3);
				break;
			case 1:
				ZhumaysynbaCamera = _randc.Next(2, 4);
				break;
			case 2:
				ZhumaysynbaCamera = 3;
				break;
			case 3:
				TryToKill();
				ZhumaysynbaCamera = 0;
				break;
		}
		// Изменение Position чтобы он отображался правильно 
		PositionMath();
		Texture = _zhumaysynbaTextures[ZhumaysynbaCamera];
		_isWaiting = true;
		_delayTimer.Start();
		_delayTimer.WaitTime = _rand.Next(min, max);
	}

	// Эти функции для таймера
	public override void _Process(double delta)
	{
		Misible();
		if (_isWaiting)
		{
			Misible();
			return;
		}
		Move();
		Misible();
	}

	private void OnTimerTimeout()
	{
		_isWaiting = false;
	}
}
