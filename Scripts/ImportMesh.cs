using Godot;
using System;

public class ImportMesh : Button
{

	public override void _Ready()
	{
		var global = GetNode<Singletons>("/root/Singletons");
		String destination = ProjectSettings.GlobalizePath("res://Imported_Meshes/");

		foreach(string fileName in System.IO.Directory.GetFiles(destination))
		{
			if(!fileName.Contains(".obj.import"))
			{
				GD.Print(fileName);
				Mesh newmesh = ResourceLoader.Load(fileName) as Mesh;
				global.Mesh_Node.Mesh= newmesh;
			}
		}
	}

	private void _on_ImportMesh_button_up()
	{
		var global = GetNode<Singletons>("/root/Singletons");
		FileDialog n = GetNode<FileDialog>("FileDialog");
		GD.Print("Pressed");
		n.PopupCentered();
		global.pivot_cam_script.candrag = false;
		
		Input.SetMouseMode(Input.MouseModeEnum.Visible);
		GD.Print("visible");
	}
	
	private void _on_FileDialog_popup_hide()
	{
		var global = GetNode<Singletons>("/root/Singletons");
		global.pivot_cam_script.candrag = true;		

		String destination = ProjectSettings.GlobalizePath("res://Imported_Meshes/");

		foreach(string fileName in System.IO.Directory.GetFiles(destination))
		{
			if(!fileName.Contains(".obj.import"))
			{
				GD.Print(fileName);
				Mesh newmesh = ResourceLoader.Load(fileName) as Mesh;
				global.Mesh_Node.Mesh= newmesh;
			}
		}
	}
	
	private void _on_FileDialog_file_selected(String path)
	{
		//GD.Print(path);
		String destination = ProjectSettings.GlobalizePath("res://Imported_Meshes/");

		System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@destination);
		System.IO.FileInfo[] files = di.GetFiles();
		
		foreach (System.IO.FileInfo file in files)
		{
			file.Delete();
		}

		System.IO.File.Copy(path,destination + System.IO.Path.GetFileName(path),true);
		
	}
}
