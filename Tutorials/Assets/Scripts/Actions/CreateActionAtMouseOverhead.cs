using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a given object and applies optional force.
/// 
/// @author rhagan
/// </summary>
public class CreateActionAtMouseOverhead : CreateAction {
	
	/// <summary>
	/// The tile size.
	/// </summary>
	public float tileSize = 0;
	
	/// <summary>
	/// Returns the position for the shot to start at.
	/// </summary>
	override protected Vector3 GetPosition(GameObject obj, Vector3 shotDirection, ActionData data) {
		float hitT;
		Vector3 mousePos = data.mousePos == Vector3.zero ? PickUtil.GetXZPlaneHitPoint(out hitT) : data.mousePos;
		if (tileSize > 0) {
			mousePos = new Vector3((int)(mousePos.x / tileSize) * tileSize, 0, (int)(mousePos.z / tileSize) * tileSize);
		}
		return mousePos;
	}
}
