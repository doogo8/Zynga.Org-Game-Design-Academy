using UnityEngine;
using System.Collections;

/// <summary>
/// Seeks a target if it is within range, then returns to start point.
/// </summary>
public class SeekTargetReturn : SeekTarget {
	
	/// <summary>
	/// The sight range: how far it will seek out enemies.
	/// </summary>
	public float sightRange = 20;
		
	/// <summary>
	/// Gets the target position.
	/// </summary>
	/// <returns>
	/// The target position.
	/// </returns>
	override protected Vector3 GetTargetPosition() {
		float targetDistance = float.MaxValue;
		if (_target != null && _target.target != null) {
			targetDistance = 
				(_target.target.transform.position - gameObject.transform.position).magnitude;
		}
		if (_target != null && targetDistance < sightRange) {
			return _target.target.transform.position;
		} else {
			return GetStartPos();
		}
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
