using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Triggers collisions by OnTriggerEnter
/// 
/// @author rhagan
/// </summary>
public class TriggerCollide : BaseCollide {

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="collider">Collider.</param>
	private void OnTriggerEnter(Collider collider) {
		base.Collide(collider.gameObject);
	}

	private void OnCollisionEnter(Collision collision) {
		base.Collide(collision.gameObject);
	}
}
