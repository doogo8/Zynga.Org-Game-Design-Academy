using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a spring joint.
/// 
/// @author rhagan
/// </summary>
public class CreateSpringJointAction2D : BaseAction {

	/// <summary>
	/// The start object for the joint (set on first activation).
	/// </summary>
	private Rigidbody startObject = null;

	/// <summary>
	/// The anchor start point on the startObject.
	/// </summary>
	private Vector3 anchor;

	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		if (startObject == null) {
			GameObject intersectedObj = PickUtil.GetObjectUnderMouseRay();
			if (intersectedObj != null) {
				startObject = intersectedObj.GetComponent<Rigidbody>();
				if (startObject != null) {
					float hitT;
					anchor = PickUtil.GetXYPlaneHitPoint(out hitT) - intersectedObj.transform.position;
				}
			}
		} else {
			GameObject obj2 = PickUtil.GetObjectUnderMouseRay();
			if (obj2 != null && obj2 != startObject) {
				Rigidbody body2 = obj2.GetComponent<Rigidbody>();
				if (body2 != null) {
					float hitT;
					Vector3 anchor2 = PickUtil.GetXYPlaneHitPoint(out hitT) - obj2.transform.position;

					SpringJoint joint = startObject.gameObject.AddComponent<SpringJoint>();
					joint.anchor = anchor;
					joint.connectedBody = body2;
					joint.connectedAnchor = anchor2;
				}
			}
		}
	}
}
