using UnityEngine;
using System.Collections;

/// <summary>
/// Adds force towards a target.
/// 
/// @author rhagan
/// </summary>
public class JumpTargetAction : BaseAction {

	public float force = 1000;

	public float yForce = 1000;

	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		Vector3 direction = obj.transform.forward;
		Target target = obj.GetComponent<Target>();
		if (target != null) {
			direction = target.GetDirection();
		}
		Rigidbody body = obj.GetComponent<Rigidbody>(); 
		if (body != null) {
			Vector3 applyForce = force * direction.normalized + Vector3.up * yForce;
			body.AddForce(applyForce);
		}
	}
}
