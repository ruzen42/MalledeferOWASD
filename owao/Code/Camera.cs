using Godot;

public partial class Camera : Camera2D
{
	public override void _Process(double delta)
	{
		// Тут каждый кадр отслеживается положение мышь и передается в Position Camera2d 
		// Можно сказать что камера следует за мышкой, но у камеры есть границы 
		Position = GetViewport().GetMousePosition();
	}
}
