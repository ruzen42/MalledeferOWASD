using Godot;

public partial class Night_Menu_selector : VBoxContainer
{
	public SceneTree sceneTree;
	public PackedScene newScene;
	private Button[] nights = new Button[6];

	public override void _Ready()
	{
		sceneTree = GetTree();
		newScene = GD.Load<PackedScene>("res://Scenes/game.tscn");
		for (byte i = 2 ; i <= 7 ; ++i) nights[i-2] = GetNode<Button>($"NightContainer/Night_{i}_Button");
	}

	public override void _Process(double delta)
	{
		for (byte i = 2 ; i <= 7 ; ++i) 
		{
			switch (saves.NightsCompleted)
			{
				case 6:
					nights[5].SetDisabled(true);
					goto case 5;  // Переход к следующему case
				case 5:
					nights[4].SetDisabled(true);
					goto case 4;
				case 4:
					nights[3].SetDisabled(true);
					goto case 3;
				case 3:
					nights[2].SetDisabled(false);
					goto case 2;
				case 2:
					nights[1].SetDisabled(false);
					goto case 1;
				case 1:
					nights[0].SetDisabled(false);
					break;
			}
		} 
	}

	void _on_play_button_button_up()
	{
		// Показывает меню ночей при нажатии
		ShowNightMenuButtons();
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}

	void _on_back_button_button_up()
	{
		// Делает обратное
		HideNightMenuButtons();
		GetNode<AudioStreamPlayer>($"../Buttons_Sound").Play();
	}

	public void HideNightMenuButtons() { Visible = false; }
	public void ShowNightMenuButtons() { Visible = true; }

	private void ChangeScene(string scenePath)
	{
		if (newScene != null)
		{
			sceneTree.ChangeSceneToPacked(newScene);
		}
		else
		{
			GD.PrintErr("Failed to load scene: " + scenePath);
		}
	}

	// Эти функции загружают игру с выбранной ночью
	private void _on_night_1_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 1;
	}

	private void _on_night_2_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 2;
	}

	private void _on_night_3_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 3;
	}

	private void _on_night_4_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 4;
	}

	private void _on_night_5_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 5;
	}

	private void _on_night_6_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 6;
	}

	private void _on_night_7_button_button_down()
	{
		ChangeScene("res://Scenes/game.tscn");
		saves.NightSelected = 7;
	}
}
