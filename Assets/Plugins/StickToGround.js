#pragma strict

function Start () {

}

function Update () { 
var hit : RaycastHit; 
if (Physics.Raycast (transform.position, -Vector3.up, hit)) { 
var distanceToGround = hit.distance;

//use below code if your pivot point is in the middle

//transform.position.y = hit.distance - transform.collider.bounds.extents;

//use below code if your pivot point is at the bottom 
transform.position.y = hit.distance; 
   }
}