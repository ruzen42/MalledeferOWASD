using Godot;
// Не отключать либу System она нужна Random
using System;

public partial class zhumaysynba : Sprite2D
{
	// Создаю объекты класса Random чтобы 
	private Random _rand = new Random();
	// Этот рандом используйте для камер
	private Random _randc = new Random();
	private Texture2D[] _zhumaysynbaTextures = new Texture2D[4];
	private Timer _delayTimer;
	private int min;
	private int max;
	private bool _isWaiting = true;
	// Выбраная камера игроком относительно zhumaysynba, используется для получения
	private byte SelectedShampoo;

	public int ZhumaysynbaCamera = 0;
	public ColorRect Door;

		
	public override void _Ready()
	{
		//WaitTimeMath();
		min = 1;
		max = 2;
		_delayTimer = new Timer();
		_delayTimer.Autostart = true;
		_delayTimer.WaitTime = _rand.Next(min, max);
		_delayTimer.OneShot = false;
		_delayTimer.Connect("timeout", new Callable(this, nameof(OnTimerTimeout)));
		Door = GetNode<ColorRect>("../../../Door");
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
				Position = new Vector2(357, 130);
				break;

			case 2:
				Position = new Vector2(177, -224);
				break;

			case 3:
				Position = new Vector2(473, 204);
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
		_zhumaysynbaTextures[0] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/1.png");
		_zhumaysynbaTextures[1] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/2.png");
		_zhumaysynbaTextures[2] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/3.png");
		_zhumaysynbaTextures[3] = (Texture2D)ResourceLoader.Load("res://Sprites/zhumaysynba/4.png");
	}

	public void ChangeScene(string scenePath)
	{
		var sceneTree = GetTree();
		var newScene = GD.Load<PackedScene>(scenePath);
		sceneTree.ChangeSceneToPacked(newScene);
	}

	private void TryToKill()
	{
		if (!Door.Visible)
		{
			RemoveChild(_delayTimer);
			_delayTimer.QueueFree();
			ChangeScene("res://Scenes/main_menu.tscn");
		}
		else
		{
			GD.Print("стук стук");
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
