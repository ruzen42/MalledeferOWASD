using Godot;

// суть этого класса чтобы создать эффект появления из мрака при запуске игры
public partial class ColorRect : Godot.ColorRect
{
  // Переменные для удобства эффекта
	private float modulate = 255;
	private bool hasCompleted = false;

  // Придание стандартных свойств
	  public override void _Ready()
	  {
		Visible = true;
	  }
  // Сам эффект
  public override void _Process(double delta)
  {
	if (modulate <= 0)
	 Visible = false;
	else
	{
	  modulate = 0;
	  Color = new Color(0, 0, 0, modulate);
	}
  }
}
