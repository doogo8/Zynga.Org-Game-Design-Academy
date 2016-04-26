using UnityEngine;
using System.Collections;

/// <summary>
/// Makes an object follow another object by an offset.
/// </summary>
public class Follow : MonoBehaviour {

	/// The offset to follow at
	public Vector3 offset;

	/// The target to follow
	public GameObject target;
	
	/// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = target.transform.position + offset;
		}
	}
}
