using Godot;
using System;

public class PivotCam : Godot.Spatial
{
	[Export] float sensitivity = 1;
	Vector3 rotation;
	MeshInstance rot;
	Spatial pivotCam;
	
	[Export] public bool candrag = true;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//rot = GetNode<MeshInstance>("MeshInstance");
		pivotCam = GetNode<Spatial>("CamPivot");
		
	}
	
	public override void _Input(InputEvent inputEvent)
	{
		base._Input(@inputEvent);
		if(candrag)
		{
			if (inputEvent is InputEventMouseMotion eventMouseButton)
			{
				if(Input.IsActionPressed("Mouse_click"))
				{
					Vector3 rotDeg = pivotCam.RotationDegrees;
					
					rotDeg.y -= eventMouseButton.Relative.x * sensitivity;
					rotDeg.x -= eventMouseButton.Relative.y * sensitivity;
					pivotCam.RotationDegrees = rotDeg;


					
					Input.SetMouseMode(Input.MouseModeEnum.Captured);

					// GD.Print(eventMouseButton.Relative.x);
				}
				else
				{
					Input.SetMouseMode(Input.MouseModeEnum.Visible);

				}
			}
		}
	}
}
