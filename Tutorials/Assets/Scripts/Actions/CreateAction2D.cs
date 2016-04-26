using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a given object and applies optional force.
/// 
/// @author rhagan
/// </summary>
public class CreateAction2D : CreateAction {

	/// <summary>
	/// The tile size.
	/// </summary>
	public float tileSize = 0;

	/// <summary>
	/// Returns the position for the shot to start at.
	/// </summary>
	override protected Vector3 GetPosition(GameObject obj, Vector3 shotDirection, ActionData data) {
		float hitT;
		Vector3 pos = PickUtil.GetXYPlaneHitPoint(out hitT);
		if (tileSize > 0) {
			pos = new Vector3((int)(pos.x / tileSize) * tileSize, (int)(pos.y / tileSize) * tileSize, 0);
		}
		return pos;
	}
}
