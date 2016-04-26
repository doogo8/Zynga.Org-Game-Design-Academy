using UnityEngine;
using System.Collections;

public class SeekStartPoint : SeekTarget {

	public bool changeY = false;

	// Use this for initialization
	override protected void Start () {
		base.Start();
	}
	
	/// <summary>
	/// Gets the target point.
	/// </summary>
	/// <returns>
	/// The target point.
	/// </returns>
	override protected Vector3 GetTargetPosition() {
		Vector3 pos = GetStartPos();
		return changeY ? pos : new Vector3(pos.x, transform.position.y, pos.z);
	}

	/// <summary>
	/// Gets the start position.
	/// </summary>
	/// <returns>
	/// </returns>
	public Vector3 GetStartPos() {
		return startPoint;
	}
}
