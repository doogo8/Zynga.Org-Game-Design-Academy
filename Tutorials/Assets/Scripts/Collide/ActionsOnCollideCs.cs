using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Runs actions on collision.
/// 
/// @author rhagan
/// </summary>
public class ActionsOnCollide : BaseCollide {

	/// <summary>
	/// Called on starting collision.
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	private void OnCollisionEnter(Collision other) {
		Collide(other.gameObject);
	}
}
