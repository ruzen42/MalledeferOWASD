using Godot;

public partial class Camera_Output : Sprite2D
{
	// Массив из текстур, позже будет заполнен в функции _Ready 
	private Texture2D[] cameraTextures = new Texture2D[7];
	// Через этот AudioStreamPlayer идет весь звук с камер
	private AudioStreamPlayer soundPlayer;
	private Button TaserButton;

	// Переменная для обозначения какую камеру выбрал игрок, не сбрасывается закрытии планшета
	public byte cameraSelected = 5;

	public override void _Ready()
	{
		TaserButton = GetNode<Button>("TaserButton");
		// Заполнение массива cameraTextures для их смены при нажатии кнопок
		for (int i = 1; i <= 7; ++i) 
			cameraTextures[i-1] = (Texture2D)ResourceLoader.Load($"res://Sprites/CameraTextures/camera_{i}.jpg");
		// Получаем ноду Camera и ложим её в soundPlayer 
		soundPlayer = GetNode<AudioStreamPlayer>("Camera");
		// Текстура Camera_Output меняется на 4 камеру (cameraSelected)
		ChangeCameraTexture(cameraSelected, false);
	}

	public override void _Process(double delta)
	{	
		if (cameraSelected == 0) 
			TaserButton.Visible = true;
		else
			TaserButton.Visible = false;
		
		if (Visible)
		{
			// Ввод с клавиатуры для смены камер (настройка в godot)
			for (byte i = 0; i < 7; i++)
			{
				if (Input.IsActionJustPressed($"cam{i + 1}"))
				{
					cameraSelected = i;
					ChangeCameraTexture(cameraSelected);
					break;
				}
			}
		}
	}
	// Каждая функция привязана в Godot и просто меняет камеру и вызывает функцию ChangeCameraTexture();
	private void _on_first_camera_button_button_down()
	{
		cameraSelected = 0;
		ChangeCameraTexture(cameraSelected);
	}

	private void _on_second_camera_button_button_down()
	{
		cameraSelected = 1;
		ChangeCameraTexture(cameraSelected);
	}

	private void _on_three_camera_button_button_down()
	{
		cameraSelected = 2;
		ChangeCameraTexture(cameraSelected);
	}

	private void _on_fourth_camera_button_button_down()
	{
		cameraSelected = 3;
		ChangeCameraTexture(cameraSelected);
	}

	private void _on_fifth_camera_button_button_down()
	{
		cameraSelected = 4;
		ChangeCameraTexture(cameraSelected);
	}

	private void _on_sixth_camera_button_button_down()
	{
		cameraSelected = 5;
		ChangeCameraTexture(cameraSelected);
	}

	private void _on_seventh_camera_button_button_down()
	{
		cameraSelected = 6;
		ChangeCameraTexture(cameraSelected);
	}

	private void ChangeCameraTexture(int cameraIndex)
	{
		// Звук от кнопки
		soundPlayer.Play();
		saves.SelectedCamera = cameraIndex;
		if (cameraIndex >= 0 && cameraIndex < cameraTextures.Length && cameraTextures[cameraIndex] != null)
		{
			// Смена текстуры по cameraIndex
			Texture = cameraTextures[cameraIndex];
		}
	}

	private void ChangeCameraTexture(int cameraIndex, bool Sound)
	{
		// Чтобы при старте сцены звука не было, я создал отдельную функцию, если вам кажется это
		// не правильным подходом измените это
		if (Sound) 
			soundPlayer.Play();
		saves.SelectedCamera = cameraIndex;
		
		if (cameraIndex >= 0 && cameraIndex < cameraTextures.Length && cameraTextures[cameraIndex] != null)
		{
			Texture = cameraTextures[cameraIndex];
		}
	}
}
