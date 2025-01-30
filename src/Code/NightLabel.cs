using Godot;

public partial class NightLabel : Label
{
	Timer RealTimer; 
	
	public override void _Ready() 
	{
		RealTimer = new Timer
		{
			Autostart = false,
			WaitTime = 60,
			OneShot = false
		};
		
		AddChild(RealTimer);
		RealTimer.Connect("timeout", new Callable(this, nameof(OnRealTimerTimeout)));
		
		Text = saves.NightSelected + " ночь\n" + saves.Time + " AM";
		RealTimer.Start();
	}
	
	private void OnRealTimerTimeout()
	{
		saves.Time+=1;
		Text = saves.NightSelected + " ночь\n" + saves.Time + " AM";
		RealTimer.Start();
	}
}
