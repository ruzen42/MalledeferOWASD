using Godot;

// суть этого класса чтобы создать эффект появления из мрака при запуске игры
public partial class ColorRect : Godot.ColorRect
{
	// Переменные для удобства эффекта
	private byte modulate = 255;
	private bool hasCompleted = false;

	// Придание стандартных свойств
	public override void _Ready()
	{
		Visible = false;
		Modulate = new Color(1, 1, 1, 255);
	}
	// Сам эффект
	public override void _Process(double delta)
	{
		if (hasCompleted) return; // return значит конец функции 

		modulate = (byte)(modulate - 1);
		if (modulate <= 0)
		{
			modulate = 0;
			hasCompleted = true;
			Visible = false;
		}
		// Само измение и обращение к Modulate 
		Modulate = new Color(1, 1, 1, modulate / 255f);
	}
}
