using UnityEngine;
using System.Collections;

public class FPSDemo : MonoBehaviour {

	private HotCursorManager cursorManager;
	private bool showMenu = false;

	void Start () 
	{
		cursorManager = GameObject.FindObjectOfType<HotCursorManager>();
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			showMenu = !showMenu;
			Screen.lockCursor = !Screen.lockCursor;
			cursorManager.Toggle(); //Toggle the raycasting.
		}
	}

	void OnGUI()
	{
		if(showMenu)
		{
			GUILayout.BeginArea(new Rect((Screen.width - 250) * 0.5f, (Screen.height - 200) * 0.5f, 250, 200), "Menu", "box");

			GUILayout.Space(30);

			if(GUILayout.Button("Close"))
			{
				showMenu = false;
				Screen.lockCursor = true;
				cursorManager.Enable();
			}

			GUILayout.EndArea();
		}
	}

}
