using UnityEngine;
using System.Collections;

/// <summary>
/// Action data to pass into BaseAction.run().
/// </summary>
[System.Serializable]
public struct ActionData {
	
	/// <summary>
	/// The primary value to use in an action (ie such as force).
	/// </summary>
	public float value;
	
	/// <summary>
	/// The generic string id for the action.
	/// </summary>
	public string id;

	/// <summary>
	/// The mouse position.
	/// </summary>
	public Vector3 mousePos;
}
