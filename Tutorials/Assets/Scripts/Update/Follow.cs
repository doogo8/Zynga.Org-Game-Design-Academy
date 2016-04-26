using UnityEngine;
using System.Collections;

/// <summary>
/// Makes an object follow another object by an offset and orient.
/// </summary>
public class FollowOrient : MonoBehaviour {

	/// The offset to follow at
	public Vector3 offset;

	/// The target to follow
	public GameObject target;
	
	/// Update is called once per frame
	void Update() {
		transform.position = target.transform.position + offset;
		transform.rotation = target.transform.rotation;
	}
}
