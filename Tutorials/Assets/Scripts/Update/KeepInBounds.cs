using UnityEngine;
using System.Collections;

/// <summary>
/// Applies a force to object if it goes outside the bounds
/// 
/// Author rhagan
/// </summary>
public class KeepInBounds : MonoBehaviour {

	public Vector3 boundsMin;

	public Vector3 boundsMax;

	public float force = 100;

	public bool useForce = false;

	private Vector3 _center;

	private Rigidbody _body;

	private void Awake() {
		_body = GetComponent<Rigidbody>();
		_center = (boundsMin + boundsMax) * 0.5f;
	}

	public bool IsInBounds() {
		Vector3 pos = transform.position;
		return (pos.x < boundsMin.x || pos.y < boundsMin.y || pos.z < boundsMin.z ||
		    pos.x > boundsMax.x || pos.y > boundsMax.y || pos.z > boundsMax.z);
	}

	private void Update() {
		if (_body != null) {
			Vector3 pos = transform.position;
			if (IsInBounds()) {
				if (useForce) {
					Vector3 applyForce = _center - pos;
					_body.AddForce(applyForce.normalized * force * Time.deltaTime * 60);
				} else {
					transform.position = new Vector3(
						Mathf.Min(Mathf.Max(pos.x, boundsMin.x), boundsMax.x),
						Mathf.Min(Mathf.Max(pos.y, boundsMin.y), boundsMax.y),
						Mathf.Min(Mathf.Max(pos.z, boundsMin.z), boundsMax.z)
						);
				}
			}
		}
	}
}
