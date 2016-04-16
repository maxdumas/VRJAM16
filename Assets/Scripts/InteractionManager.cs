using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour {
	
	public GameObject[] gos;
	
	public GameObject closest;
	
	//public Button closestScript;
	
	void Start () {
		//closest = null;
		//Selection.objects = FindObjectsOfType<MeshCollider>().Where(mc => mc.isTrigger && !mc.convex).Select(mc => mc.gameObject).ToArray();
	}
	
	void Update () {
		rebuildArray();
	}
	
	public void rebuildArray () {
		gos = GameObject.FindGameObjectsWithTag("Interactive");
		
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
			//closestScript = closest.activeInHierarchy
		}
		//closest.GetComponent<Button>().theBest = true;
		
		//closestScript = closest.GetComponent<Button>;
		//closestScript.theBest = true;
		//Debug.Log (closest);
	} 
}
