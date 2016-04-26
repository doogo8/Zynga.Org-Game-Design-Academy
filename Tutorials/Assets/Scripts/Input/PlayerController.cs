using UnityEngine;
using System.Collections;

/// <summary>
/// Physics player controller in 3D.
/// Can move left or right or jump.
/// 
/// Author: rhagan
/// </summary>
public class PlayerController : MonoBehaviour {

	/// <summary>
	/// The jump input key.
	/// </summary>
	[SerializeField]
	private string _jumpKey = "space";

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

	/// <summary>
	/// The input key to move up.
	/// </summary>
	[SerializeField]
	private string _upKey = "up";
	
	/// <summary>
	/// The input key to move down.
	/// </summary>
	[SerializeField]
	private string _downKey = "down";

	/// <summary>
	/// The force to move with.
	/// </summary>
	[SerializeField]
	private float _force = 10;

	/// <summary>
	/// The force to move with.
	/// </summary>
	[SerializeField]
	private float _turnForce = 100;

	/// <summary>
	/// The force to jump with.
	/// </summary>
	[SerializeField]
	private float _jumpForce = 400;

	/// <summary>
	/// The torque to apply on jump.
	/// </summary>
	[SerializeField]
	private float _jumpTorque = 0;

	/// <summary>
	/// The Rigidbody to apply a force to.
	/// </summary>
	[SerializeField]
	private Rigidbody _body = null;

	/// <summary>
	/// If true, left and right strafe; if false, they turn.
	/// </summary>
	[SerializeField]
	private bool strafe = false;

	void Start() {
		if (_body == null) {
			// set to this rigidbody if unset
			_body = GetComponent<Rigidbody>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (strafe) {
			if (Input.GetKey(_leftKey)) {
				_body.AddForce(transform.right * -_turnForce * Time.deltaTime);
			}
			if (Input.GetKey(_rightKey)) {
				_body.AddForce(transform.right * _turnForce * Time.deltaTime);
			}
		} else {
			if (Input.GetKey(_leftKey)) {
				transform.Rotate(0, -_turnForce * Time.deltaTime, 0);
			}
			if (Input.GetKey(_rightKey)) {
				transform.Rotate(0, _turnForce * Time.deltaTime, 0);
			}
		}
		if (Input.GetKey(_upKey)) {
			_body.AddForce(transform.forward * _force * Time.deltaTime);
		}
		if (Input.GetKey(_downKey)) {
			_body.AddForce(transform.forward * -_force * Time.deltaTime);
		}
		if (Input.GetKeyDown(_jumpKey) && Mathf.Abs(_body.velocity.y) < 0.01f) {
			_body.AddForce(0, _jumpForce * Time.deltaTime, 0);
			_body.AddTorque(_jumpTorque, _jumpTorque, _jumpTorque);
		}
	}
}
