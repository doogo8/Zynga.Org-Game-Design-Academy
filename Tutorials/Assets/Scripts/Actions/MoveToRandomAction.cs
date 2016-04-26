using UnityEngine;
using System.Collections;

/// <summary>
/// Moves object to a random location
/// 
/// @author rhagan
/// </summary>
public class MoveToRandomAction : BaseAction {

	public Vector3 minPos = new Vector3(-100, 0, -100);

	public Vector3 maxPos = new Vector3(100, 0, 100);

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		obj.transform.localPosition = new Vector3(
			Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), Random.Range(minPos.z, maxPos.z));
	}
}
