using Godot;
using System;

public class Export : Button
{
	private void _on_Export_button_up()
	{
		var global = GetNode<Singletons>("/root/Singletons");
		var animationNode = global.Mesh_Node.GetNode<AnimationPlayer>("AnimationPlayer");
		animationNode.Play("360Rot");
	}
}



