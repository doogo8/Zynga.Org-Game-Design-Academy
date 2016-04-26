using UnityEngine;
using System.Collections;

/// <summary>
/// Moves object to a given location
/// 
/// @author rhagan
/// </summary>
public class SeekPointAction : BaseAction {

	public Vector3 targetPos;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		SeekPoint seek = obj.GetComponent<SeekPoint>();
		if (seek == null) {
			seek = obj.AddComponent<SeekPoint>();
		}
		float hitT;
		if (targetPos == Vector3.zero) {
			seek.targetPos = data.mousePos;
		} else {
			seek.targetPos = targetPos;
		}
	}
}
