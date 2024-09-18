using Godot;

public partial class Night_Menu_selector : VBoxContainer
{

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
        var sceneTree = GetTree();
        var newScene = GD.Load<PackedScene>(scenePath);

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
