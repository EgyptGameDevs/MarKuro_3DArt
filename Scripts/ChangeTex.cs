using Godot;
using System;

public class ChangeTex : ItemList
{
	private void _on_Items_item_activated(int index)
	{
		var global = GetNode<Singletons>("/root/Singletons");
		String destination = ProjectSettings.GlobalizePath("res://Imported/");
		global.Mesh_Node.MaterialOverride = new SpatialMaterial();
		var texture = ResourceLoader.Load(destination + GetItemText(index));
		global.Mesh_Node.MaterialOverride.Set("albedo_texture", texture);
		//
	}

}



