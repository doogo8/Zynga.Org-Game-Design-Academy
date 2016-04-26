using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a fixed joint.
/// 
/// @author rhagan
/// </summary>
public class AddTorqueAction : BaseAction {

	public Vector3 torque;

	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		GameObject intersectedObj = PickUtil.GetObjectUnderMouseRay();
		if (intersectedObj != null) {
			ApplyTorque applyTorque = intersectedObj.AddComponent<ApplyTorque> ();
			if (torque != Vector3.zero) {
				applyTorque.torque = torque;
			}
		}
	}
}
