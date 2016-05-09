using UnityEngine;
using System.Collections;

/// <summary>
/// Physics player controller in 2D.
/// Can move left or right or jump.
/// 
/// Author: rhagan
/// </summary>
public class PlayerControllerOverhead2D : MonoBehaviour {

	/// <summary>
	/// The input key to move left.
	/// </summary>
	[SerializeField]
	private string _leftKey = "left";

	/// <summary>
	/// The input key to move right.
	/// </summary>
	[SerializeField]
	private string _rightKey = "right";

	[SerializeField]
	private string _upKey = "up";

	[SerializeField]
	private string _downKey = "down";

	/// <summary>
	/// The force to move with.
	/// </summary>
	[SerializeField]
	private float _force = 10;

	/// <summary>
	/// The Rigidbody to apply a force to.
	/// </summary>
	[SerializeField]
	private Rigidbody _body = null;

	public bool faceDirection = true;

	void Start() {
		if (_body == null) {
			// set to this rigidbody if unset
			_body = GetComponent<Rigidbody>();
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 rotation = _body.transform.localRotation.eulerAngles;
		if (Input.GetKey(_leftKey)) {
			_body.AddForce(-_force, 0, 0);
			if (faceDirection) {
				_body.transform.localRotation = Quaternion.Euler(new Vector3(rotation.x, 180, rotation.z));
			}
		} else if (Input.GetKey(_rightKey)) {
			_body.AddForce(_force, 0, 0);
			if (faceDirection) {
				_body.transform.localRotation = Quaternion.Euler(new Vector3(rotation.x, 0, rotation.z));
			}
		} else if (Input.GetKey(_upKey)) {
			_body.AddForce(0, 0, _force);
			if (faceDirection) {
				_body.transform.localRotation = Quaternion.Euler(new Vector3(rotation.x, 270, rotation.z));
			}
		} else if (Input.GetKey(_downKey)) {
			_body.AddForce(0, 0, -_force);
			if (faceDirection) {
				_body.transform.localRotation = Quaternion.Euler(new Vector3(rotation.x, 90, rotation.z));
			}
		}
	}
}
