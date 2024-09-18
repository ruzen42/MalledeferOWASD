using Godot;

public partial class Camera_Output : Sprite2D
{

    // Массив из текстур, позже будет заполнен в функции _Ready 
    public Texture2D[] cameraTextures = new Texture2D[7];
    // Через этот AudioStreamPlayer идет весь звук с камер
    public AudioStreamPlayer soundPlayer;

    // Переменная для обозначения какую камеру выбрал игрок, не сбрасывается закрытии планшета
    byte cameraSelected = 5;

    public override void _Ready()
    {
        // Заполнение массива cameraTextures для их смены при нажатии кнопок
        cameraTextures[0] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 1.jpg");
        cameraTextures[1] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 2.jpg");
        cameraTextures[2] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 3.jpg");
        cameraTextures[3] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 4.jpg");
        cameraTextures[4] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 5.jpg");
        cameraTextures[5] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera_remastered_6.jpg");
        cameraTextures[6] = (Texture2D)ResourceLoader.Load("res://Sprites/Камеры/camera 7.jpg");
        // Получаем ноду Camera и ложим её в soundPlayer 
        soundPlayer = GetNode<AudioStreamPlayer>("Camera");
        // Текстура Camera_Output меняется на 4 камеру (cameraSelected)
        ChangeCameraTexture(cameraSelected, false);
    }

    public override void _Process(double delta)
    {
        if (Visible)
        {
            // Ввод с клавиатуры для смены камер (настройка в godot)
            if (Input.IsActionPressed("cam1"))
            {
                ChangeCameraTexture(0);
            }
            if (Input.IsActionPressed("cam2"))
            {
                ChangeCameraTexture(1);
            }
            if (Input.IsActionPressed("cam3"))
            {
                ChangeCameraTexture(2);
            }
            if (Input.IsActionPressed("cam4"))
            {
                ChangeCameraTexture(3);
            }
            if (Input.IsActionPressed("cam5"))
            {
                ChangeCameraTexture(4);
            }
            if (Input.IsActionPressed("cam6"))
            {
                ChangeCameraTexture(5);
            }
            if (Input.IsActionPressed("cam7"))
            {
                ChangeCameraTexture(6);
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
        // Чтобы при старте сцены звука не было, я создал отдельную функцию, если вам кажется это не правельным подходом измените это
        if (Sound) soundPlayer.Play();
        saves.SelectedCamera = cameraIndex;
        if (cameraIndex >= 0 && cameraIndex < cameraTextures.Length && cameraTextures[cameraIndex] != null)
        {
            Texture = cameraTextures[cameraIndex];
        }
    }
}
