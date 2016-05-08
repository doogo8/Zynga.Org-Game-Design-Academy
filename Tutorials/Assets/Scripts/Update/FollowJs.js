 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Makes an object follow another object by an offset and orient.
/// </summary>
class FollowOrientJs extends MonoBehaviour {

	/// The offset to follow at
	 var offset : Vector3;

	/// The target to follow
	 var target : GameObject;
	
	/// Update is called once per frame
	function Update () : void {
		transform.position = target.transform.position + offset;
		transform.rotation = target.transform.rotation;
	}
}
