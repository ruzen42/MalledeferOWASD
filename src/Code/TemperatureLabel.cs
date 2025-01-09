using Godot;
using System;

public partial class TemperatureLabel : Label
{
	float LocalTemp;
	bool flag;
	public override void _Process(double delta)
	{
		LocalTemp = saves.Temp;
		Text = LocalTemp.ToString() + "°C";
		
		if (LocalTemp >= 30.0f )
			Modulate = new Color(255, 50, 50, 255);
			flag = true;
			
		if (flag && !(LocalTemp >= 30.0f))
			Modulate = new Color(255, 255, 255, 255);
			
	}
}
