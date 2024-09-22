using Godot;

// суть этого класса чтобы создать эффект появления из мрака при запуске игры
public partial class ColorRect : Godot.ColorRect
{
	// Переменные для удобства эффекта
	private byte modulate = 255;
	private bool increasing = false;
	private bool hasCompleted = false;

	// Придание стандартных свойств
	public override void _Ready()
	{
		Modulate = new Color(1, 1, 1, modulate / 255f);
	}

	// Сам эффект
	public override void _Process(double delta)
	{
		if (hasCompleted) return; // return значит конец функции 

		if (increasing)
		{   // Снижение непрозрачности у ноды
			modulate = (byte)(modulate + 1);
			if (modulate >= 255)
			{
				modulate = 255;
				increasing = false;
			}
		}
		else
		{ // Обратный эффект
			modulate = (byte)(modulate - 1);
			if (modulate <= 0)
			{
				modulate = 0;
				increasing = true;
				hasCompleted = true;
			}
		}
		// Само измение и обращение к Modulate 
		Modulate = new Color(1, 1, 1, modulate / 255f);
	}
}
