using UnityEngine;
using System.Collections;

public class Boundaries : MonoBehaviour {
 private GameObject _bndBottom;
 private GameObject _bndTop;

	// Use this for initialization
	void Start () {
		FindBoundaryObjects();
		SetupBoundaries();
	}
	
	private void SetupBoundaries(){
		_bndTop.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f , 1.25f, 10.0f));
		_bndTop.transform.localScale = new Vector3(25, .25f, 10);
		
		_bndBottom.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f , -.25f, 10.0f));
		_bndBottom.transform.localScale = new Vector3(25, .25f, 10);
	}
	
	private void FindBoundaryObjects(){
		_bndBottom = GameObject.Find("bndBottom");
		_bndTop = GameObject.Find ("bndTop");
	}
	
}
