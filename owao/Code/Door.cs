using Godot;

// Не меняйте public на private это вызывает ошибку 
public partial class Door : ColorRect
{

    // Если нажать на кнопку (настраевается в Godot) то вызовется функция _on_door_button_pressed();
    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("door"))
        {
            _on_door_button_pressed();
        }
    }

    public void _on_door_button_pressed()
    {
        // Просто меняет видимость на простивоположную, если вы хотите узнать открыта дверь или нет изпользуюте Visible
        Visible = !Visible;
    }
}
