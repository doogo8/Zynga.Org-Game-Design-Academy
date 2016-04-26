using UnityEngine;
using System.Collections;

/// <summary>
/// Continues to apply a force every frame.
/// 
/// Author: rhagan
/// </summary>
public class ForceUpdate : MonoBehaviour {

	public Vector3 force = new Vector3(100, 0, 0);

	private Rigidbody _body;

	private void Awake() {
		_body = GetComponent<Rigidbody>();
	}

	private void Update() {
		_body.AddForce(force);
	}
}
