using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys after a delay.
/// 
/// @author rhagan
/// </summary>
public class DestroyAction : BaseAction {

	/// <summary>
	/// Delay to destroy.
	/// </summary>
	public float delaySecs = 0;
	
	/// <summary>
	/// If true, destroys recursive parent.
	/// </summary>	
	public bool destroyParent = true;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		StartCoroutine(DestroySelf(obj, delaySecs));
	}

	/// <summary>
	/// Destroies the self.
	/// </summary>
	private IEnumerator DestroySelf(GameObject obj, float delaySecs) {
		yield return new WaitForSeconds(delaySecs);
		Transform parent = obj.transform;
		if (destroyParent) {
			while (parent.parent != null) {
				parent = parent.parent;
			}
		}
		Destroy(parent.gameObject);
	}
}
