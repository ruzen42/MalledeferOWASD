using Godot;
using System;

public partial class Statistics : VBoxContainer
{
	private Label Text;
	private long Deaths, GameOpen, Saves;
	
	public override void _Ready()
	{
		Text = GetNode<Label>("Label");
		Text.Text = $"Статистика: \n\tИгра открывалась: {GameOpen}\n\tСмертей: {Deaths}\n\tСохранений: {Saves}";
	}
}
