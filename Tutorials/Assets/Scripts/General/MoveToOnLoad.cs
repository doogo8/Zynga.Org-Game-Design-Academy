using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Moves the object to the given position on scene load.
/// </summary>
public class MoveToOnLoad : MonoBehaviour {	

	/// <summary>
	/// The position to move to on awake.
	/// </summary>
	public Vector3 position;

	private void Awake() {
		transform.position = position;
	}
}
