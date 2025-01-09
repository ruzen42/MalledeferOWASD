using Godot;

// суть этого класса чтобы создать эффект появления из мрака при запуске игры
public partial class ColorRect : Godot.ColorRect
{
	// Переменные для удобства эффекта
	private int modulate = 255;
	private bool hasCompleted = false;

	// Придание стандартных свойств
	public override void _Ready()
	{
		Visible = true;
		Modulate = new Color(1, 1, 1, 255);
	}
	// Сам эффект
	public override void _Process(double delta)
	{
		modulate = modulate - 1;
		if (modulate < 0)
			Visible = false;
		else
			Modulate = new Color(1, 1, 1, modulate / 255f);
	}
}
