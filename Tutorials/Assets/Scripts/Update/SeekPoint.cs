using UnityEngine;
using System.Collections;

/// <summary>
/// Script to apply a force towards a target point.
/// 
/// Author rhagan
/// </summary>
public class SeekPoint : MonoBehaviour {

	/// <summary>
	/// The target to follow.
	/// </summary>
	public Vector3 targetPos;

	/// <summary>
	/// Whether we are currently seeking.
	/// </summary>
	public bool seeking = false;
	
	/// <summary>
	/// The speed to follow with.
	/// </summary>	
	public float force = 100;

	/// <summary>
	/// Optional body to move.
	/// </summary>
	public Rigidbody body = null;

	/// <summary>
	/// The threshold to apply force in.
	/// </summary>
	public float threshold = 1;

	public bool useVelocity = true;

	private void Awake() {
		targetPos = gameObject.transform.localPosition;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update() {
		if (body == null) {
			body = GetComponent<Rigidbody>();
		}
		float timeFactor = Time.deltaTime * 60;
		float applyForce = force;
		Vector3 direction = targetPos - body.transform.position;
		float distance = direction.magnitude;
		if (distance < threshold) {
			body.velocity *= 0.8f;
			direction.Normalize();
			if (useVelocity) {
				body.velocity = direction * force * (distance / threshold);
			} else {
				body.AddForce(timeFactor * direction * force * (distance / threshold));
			}
		} else {
			direction.Normalize();
			if (useVelocity) {
				body.velocity = direction * force;
			} else {
				body.AddForce(timeFactor * direction * force);
			}
		}
	}

	/// <summary>
	/// Gets the target position.
	/// </summary>
	/// <returns>The target position.</returns>
	virtual protected Vector3 GetTargetPosition() {
		return seeking ? targetPos : gameObject.transform.localPosition;
	}

	public void OnDeath() {
		targetPos = gameObject.transform.localPosition;
	}
}
