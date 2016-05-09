 //import UnityEngine;
//import System.Collections;
//import System.Collections.Generic;

/// <summary>
/// Runs actions on collision.
/// 
/// @author rhagan
/// </summary>
class ActionsOnCollideJs extends BaseCollideJs {

	/// <summary>
	/// Called on starting collision.
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	private function OnCollisionEnter ( other : Collision  ) : void {
		Collide(other.gameObject);
	}
}
