using UnityEngine;
using System.Collections;

/// <summary>
/// Repels with force.
/// 
/// @author rhagan
/// </summary>
public class RepelAction : BaseAction {

	/// <summary>
	/// The force to apply.
	/// </summary>
	public float force = 1000;

	/// <summary>
	/// Optional body to apply the force to.
	/// </summary>
	public Rigidbody body = null;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		Rigidbody theBody = body == null ? obj.GetComponent<Rigidbody>() : body;

		if (theBody != null) {
			Vector3 direction = obj == theBody.gameObject ?
				theBody.transform.position - transform.position :
				theBody.transform.position - obj.transform.position;
			direction.Normalize();
			theBody.AddForce(direction * force);
			                 //Vector3.up * force);
		}
	}
}
