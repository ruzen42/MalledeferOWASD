using Godot;

public partial class NightLabel : Label
{
	Timer RealTimer; 
	
	public override void _Ready() 
	{
		RealTimer = new Timer
		{
			Autostart = true,
			WaitTime = 60,
			OneShot = false
		};
		
		AddChild(RealTimer);
		RealTimer.Connect("timeout", new Callable(this, nameof(OnRealTimerTimeout)));
		
		Text = saves.NightSelected + " ночь\n" + saves.Time + " AM";
	}
	
	private void OnRealTimerTimeout()
	{
		saves.Time+=1;
		RealTimer.Start();
	}
}
