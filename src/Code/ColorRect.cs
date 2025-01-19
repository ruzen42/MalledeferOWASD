using Godot;


public partial class ColorRect : Godot.ColorRect
{
	private float alpha = 255;
	private bool hasCompleted = false;
	
	public override void _Process(double delta) 
	{
		Color = new Color(0, 0, 0, alpha / 255f);
		alpha--;
	}
}
