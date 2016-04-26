using UnityEngine;
using System.Collections;

/// <summary>
/// Script to apply a force towards a target.
/// 
/// Author rhagan
/// </summary>
public class SeekTarget : MonoBehaviour {

	/// <summary>
	/// The target to follow.
	/// </summary>
	public GameObject target;
	
	/// <summary>
	/// The speed to follow with.
	/// </summary>	
	public float force = 100;

	/// <summary>
	/// Optional body to move.
	/// </summary>
	public Rigidbody body = null;

	/// <summary>
	/// Cached target component.
	/// </summary>
	protected Target _target = null;

	/// <summary>
	/// The start point.
	/// </summary>
	protected Vector3 startPoint;
	
	virtual protected void Start() {
		_target = GetComponent<Target>();
		startPoint = gameObject.transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update() {
		if (body == null) {
			body = GetComponent<Rigidbody>();
		}
		if (_target != null) {
			target = _target.target;
		}
		Vector3 targetPos = GetTargetPosition();
		Vector3 direction = targetPos - body.transform.position;
		direction.Normalize();
		body.AddForce(direction * force);
	}

	/// <summary>
	/// Gets the target position.
	/// </summary>
	/// <returns>The target position.</returns>
	virtual protected Vector3 GetTargetPosition() {
		return _target == null ? target.transform.position : _target.targetPosition;
	}
}
