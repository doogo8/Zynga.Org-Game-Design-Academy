using UnityEngine;
using System.Collections;

/// <summary>
/// Moves object to a given location
/// 
/// @author rhagan
/// </summary>
public class MoveToAction : BaseAction {

	/// <summary>
	/// The position.
	/// </summary>
	public Vector3 position;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		Rigidbody body = obj.GetComponent<Rigidbody>();
		if (body != null) {
			body.position = position;
		} else {
			obj.transform.position = position;
		}
	}
}
