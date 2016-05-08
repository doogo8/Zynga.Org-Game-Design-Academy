 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Item that you can collect.
/// 
/// Author: rhagan
/// </summary>
class ItemJs extends MonoBehaviour {
	
	/// <summary>
	/// Called on collision.
	/// </summary>
	/// <param name="collision">Collision.</param>
	private function OnCollisionEnter ( collision : Collision  ) : void {
		 var itemCount : ItemCountJs= collision.gameObject.GetComponent(ItemCountJs);
		if (itemCount != null) {
			itemCount.itemCount++;
			Destroy(gameObject);
		}
	}
}
