using UnityEngine;
using System.Collections;

public class hc_SwitchScenes : MonoBehaviour {

	void OnGUI()
	{
		if(GUILayout.Button("First Person Demo", GUILayout.Width(200), GUILayout.Height(50)))
		{
			Application.LoadLevel("FPSDemo");
		}

		if(GUILayout.Button("Third Person Demo", GUILayout.Width(200), GUILayout.Height(50)))
		{
			Application.LoadLevel("TPDemo");
		}

		if(GUILayout.Button("2D Demo", GUILayout.Width(200), GUILayout.Height(50)))
		{
			Application.LoadLevel("2DDemo");
		}

	}
}
