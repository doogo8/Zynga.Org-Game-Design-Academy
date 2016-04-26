using UnityEngine;
using System.Collections;

/// <summary>
/// Makes an object face another object.
/// </summary>
public class OrientTo : MonoBehaviour {

	/// The target to follow
	public GameObject target;
	
	/// Update is called once per frame
	void Update() {
		transform.rotation = target.transform.rotation;
	}
}
