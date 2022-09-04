using Godot;
using System;

public class List_Items
{
	private string itemName{set; get;}
	private string itemDir{set; get;}

	public string ItemName   // property
	{
		get { return itemName; }   // get method
		set { itemName = value; }  // set method
	}

	public string ItemDir   // property
	{
		get { return itemDir; }   // get method
		set { itemDir = value; }  // set method
	}
}

public class Import : Button
{

	public override void _Ready()
	{
		String destination = ProjectSettings.GlobalizePath("res://Imported/");
		ItemList n = GetNode<ItemList>("../Items");
		
		foreach(string fileName in System.IO.Directory.GetFiles(destination))
		{
			List_Items item = new List_Items();
			item.ItemName = System.IO.Path.GetFileName(fileName);
			item.ItemDir = destination + System.IO.Path.GetFileName(fileName);
			if(!item.ItemName.Contains("import"))
			{
				n.AddItem(item.ItemName);
				//GD.Print(item.ItemName);
			}
		}
	}

	private void _on_Import_button_up()
	{
		var global = GetNode<Singletons>("/root/Singletons");

		FileDialog n = GetNode<FileDialog>("FileDialog");
		//GD.Print("Pressed");
		n.PopupCentered();
		global.pivot_cam_script.candrag = false;
		
		Input.SetMouseMode(Input.MouseModeEnum.Visible);
		//GD.Print("visible");

	}
	
	private void _on_FileDialog_popup_hide()
	{
		var global = GetNode<Singletons>("/root/Singletons");
		global.pivot_cam_script.candrag = true;
	}

	private void _on_FileDialog_file_selected(String path)
	{
		//GD.Print(path);
		String destination = ProjectSettings.GlobalizePath("res://Imported/");
		//GD.Print(destination + System.IO.Path.GetFileName(path));
		
		List_Items item = new List_Items();
		item.ItemName = System.IO.Path.GetFileName(path);
		item.ItemDir = destination + System.IO.Path.GetFileName(path);

		System.IO.File.Copy(path,destination + System.IO.Path.GetFileName(path),true);
		
		ItemList n = GetNode<ItemList>("../Items");
		n.AddItem(item.ItemName);
	}

}





