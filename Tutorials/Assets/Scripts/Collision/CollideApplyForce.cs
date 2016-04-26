using UnityEngine;
using System.Collections;

/// <summary>
/// Applies a force to the object in the direction it's facing on collision (ie a boost).
/// 
/// Author: rhagan
/// </summary>
public class CollideApplyForce : MonoBehaviour {

	public float force = 100;

	private void OnTriggerEnter(Collider collider) {
		HandleCollision(collider.attachedRigidbody);
	}

	private void OnCollisionEnter(Collision collision) {
		HandleCollision(collision.rigidbody);
	}

	private void HandleCollision(Rigidbody body) {
		if (body != null) {
			body.AddForce(body.velocity.normalized * force);
		}
	}
}
