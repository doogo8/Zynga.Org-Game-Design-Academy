 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Running into an enemy restarts the level.
/// 
/// Author: rhagan
/// </summary>
class EnemyJs extends MonoBehaviour {

	 var requiredTag : String;

	/// <summary>
	/// Called on collision.
	/// </summary>
	/// <param name="collision">Collision.</param>
	private function OnCollisionEnter ( collision : Collision  ) : void {
		if (String.IsNullOrEmpty (requiredTag) || collision.gameObject.CompareTag (requiredTag)) {
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
