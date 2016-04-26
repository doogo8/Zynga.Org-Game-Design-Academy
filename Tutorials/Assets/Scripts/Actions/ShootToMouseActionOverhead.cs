using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a given object and applies force to mouse/touch.
/// 
/// @author rhagan
/// </summary>
public class ShootToMouseActionOverhead : CreateAction {
		
	/// <summary>
	/// Returns the shooting direction.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	override protected Vector3 GetDirection(GameObject obj, ActionData data) {
		float hitT;
		Vector3 mousePos = data.mousePos == Vector3.zero ? PickUtil.GetXZPlaneHitPoint(out hitT) : data.mousePos;
		Vector3 direction = mousePos - obj.transform.position;
		direction.y = 0;
		direction.Normalize();
		return direction;
	}
}
