using UnityEngine;
using System.Collections;

/// <summary>
/// Adds force.
/// 
/// @author rhagan
/// </summary>
public class ForceAction : BaseAction {

	public Vector3 direction;

	public float force = 1;

	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		Rigidbody body = obj.GetComponent<Rigidbody>();
		if (body != null) {
			if (data.value != 0) {
				body.AddForce(force * data.value * (data.mousePos - obj.transform.position).normalized);
			} else {
				body.AddForce(force * direction.normalized);
			}
		}
	}
}
