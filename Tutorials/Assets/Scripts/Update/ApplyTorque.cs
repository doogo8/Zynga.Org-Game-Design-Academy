using UnityEngine;
using System.Collections;

/// <summary>
/// Applies a torque on update.
/// 
/// Author rhagan
/// </summary>
public class ApplyTorque : MonoBehaviour {

	public Vector3 torque = new Vector3(0, 0, 100);

	private Rigidbody body;

	private void Awake() {
		body = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update() {
		body.AddTorque(torque);
	}
}
