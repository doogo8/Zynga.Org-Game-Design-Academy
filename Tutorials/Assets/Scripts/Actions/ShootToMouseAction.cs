using UnityEngine;
using System.Collections;

/// <summary>
/// An action for shooting a GameObject towards where the mouse is in 3D space (not overhead).
/// </summary>
public class ShootToMouseAction : CreateAction {

	/// <summary>
	/// Returns the shooting direction.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	override protected Vector3 GetDirection(GameObject obj, ActionData data) {
		return PickUtil.GetMouseRay().direction;
	}
}