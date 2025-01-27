using Godot;
using System;

public partial class Guide : BoxContainer
{
	private void OnGuide()
	{
		Visible = true;
	}
	
	private void HideObj()
	{
		Visible = false; 
	}
}
