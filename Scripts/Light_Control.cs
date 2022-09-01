using Godot;
using System;

public class Light_Control : PathFollow2D
{

	[Export] PivotCam pivotScript;

	DirectionalLight light_obj;
	PathFollow pathobj;
	float offset_x_axis = 0;
	bool flag;
	float  val = 0;


	public override void _Ready()
	{
		light_obj = GetNode<DirectionalLight>("../../../../Spatial/CamPivot/Camera/Path/PathFollow/DirectionalLight");
		pathobj = GetNode<PathFollow>("../../../../Spatial/CamPivot/Camera/Path/PathFollow");

		pivotScript = GetNode<PivotCam>("../../../../Spatial");

	}

	public override void _Process(float delta)
	{
		base._Process(delta);
		if(Input.IsActionJustReleased ("Mouse_click"))
		{
			flag = false;
			pivotScript.candrag = true;
			Input.SetMouseMode(Input.MouseModeEnum.Visible);

		}

	
		GD.Print(Offset);
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventMouseMotion eventMouseMotion)
		{
			if(flag)
			{
				UnitOffset += 0.001f*eventMouseMotion.Relative.x;
				pathobj.UnitOffset = UnitOffset;
			}
		}
	}
	
	private void _on_Icon_mouse_entered()
	{
		
	}
	
	private void _on_Icon_button_down()
	{
		if(Input.IsActionPressed("Mouse_click"))
		{
			pivotScript.candrag = false;
			flag = true;
			Input.SetMouseMode(Input.MouseModeEnum.Captured);
		}
	}
}



