 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Keeps track of and shows item count.
/// 
/// Author: rhagan
/// </summary>
class ItemCountJs extends MonoBehaviour {

	/// <summary>
	/// Number of items.
	/// </summary>
	 var itemCount : int= 0;

	private function OnGUI () : void {
		GUI.Label(new Rect(10, 10, 200, 20), "Score: " + itemCount);
	}
}
