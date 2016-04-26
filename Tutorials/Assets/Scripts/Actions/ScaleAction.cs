using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a fixed joint.
/// 
/// @author rhagan
/// </summary>
public class ScaleAction : BaseAction {

	/// <summary>
	/// The amount of scale to substract each time.
	/// </summary>
	public float scaleSubstract = 0.2f;

	public bool destroyOnZeroScale = true;

	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		Vector3 scale = obj.transform.localScale - scaleSubstract * Vector3.one;
		scale = new Vector3 (Mathf.Max (0.001f, scale.x), Mathf.Max (0.001f, scale.y), Mathf.Max (0.001f, scale.z));
		obj.transform.localScale = scale;
		if (destroyOnZeroScale && scale.magnitude < 0.1f) {
			Destroy(obj);
		}
	}
}
