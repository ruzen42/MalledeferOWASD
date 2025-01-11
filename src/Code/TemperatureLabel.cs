using Godot;
using System;

public partial class TemperatureLabel : Label
{
	double LocalTemp;
	bool flag;
	
	public override void _Process(double delta)
	{
		LocalTemp = Math.Round(saves.Temp, 1);
		Text = LocalTemp.ToString() + "°C";
		
		if (LocalTemp >= 30.0f )
		{
			Modulate = new Color(255, 50, 50, 255);
			flag = true;
		}
			
		if (flag && !(LocalTemp >= 30.0f))
			Modulate = new Color(255, 255, 255, 255);
			
	}
}
