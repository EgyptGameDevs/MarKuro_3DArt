using Godot;
using System;

public class Singletons : Node
{
	public PivotCam pivot_cam_script { get; set; }
	public Import import_script { get; set; }
	public MeshInstance Mesh { get; set; }

	public override void _Ready()
	{
		pivot_cam_script = GetNode<PivotCam>("../Spatial");
		Mesh = GetNode<MeshInstance>("../Spatial/MeshInstance");
		import_script = GetNode<Import>("../Spatial/CanvasLayer/Import");
	}
}
