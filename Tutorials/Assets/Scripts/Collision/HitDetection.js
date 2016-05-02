#pragma strict

import UnityEngine.Physics2D;

/// <summary>
/// Detects mouse clicks on a collider in a 2D scene 
/// Outputs the name of the collider to the console
/// Author: wilcoats
/// </summary>
public class HitDetection extends MonoBehaviour {

	function Update () {
		if(Input.GetMouseButtonDown(0))
		{
			// Cast a ray towards infinity from the mouse click location
		    var ray: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		    // Detect if the ray intersected a collider
	    	var hit: RaycastHit2D = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

			// Check if the collider is this one		           
		    if(hit.collider != null && hit.collider.transform == this.transform)
		    {
				Debug.LogFormat("Hit Detected on {0}.", hit.collider.transform.gameObject.name);
			}
		}	
	}
}