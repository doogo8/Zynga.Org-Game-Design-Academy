 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Destroys after a delay.
/// 
/// @author rhagan
/// </summary>
class DestroyActionJs extends BaseActionJs {

	/// <summary>
	/// Delay to destroy.
	/// </summary>
	 var delaySecs : float= 0;
	
	/// <summary>
	/// If true, destroys recursive parent.
	/// </summary>	
	 var destroyParent : boolean= true;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override function Run ( obj : GameObject ,   data : ActionDataJs  ) : void {
		StartCoroutine(DestroySelf(obj, delaySecs));
	}

	/// <summary>
	/// Destroies the self.
	/// </summary>
	private function DestroySelf ( obj : GameObject ,   delaySecs : float  ) : IEnumerator {
		yield new WaitForSeconds(delaySecs);
		 var parent : Transform= obj.transform;
		if (destroyParent) {
			while (parent.parent != null) {
				parent = parent.parent;
			}
		}
		Destroy(parent.gameObject);
	}
}
