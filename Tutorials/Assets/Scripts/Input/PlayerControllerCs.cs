using UnityEngine;
using System.Collections;

/// <summary>
/// Physics player controller in 3D.
/// Handles move, turn, and jump.
/// 
/// Author: rhagan
/// </summary>
public class PlayerController : MonoBehaviour {

	#region Inputs

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

	#endregion Inputs


	/// <summary>
	/// Start() is always called first when an object is created
	/// </summary>
	void Start() {
		if (_body == null) {
			// Set to this rigidbody if unset
			_body = GetComponent<Rigidbody>();
		}
	}

	/// <summary>
	/// Update() is called once per frame
	/// </summary>
	void Update () {
		// Handle moving/turning left and right
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
		// Handle moving forward
		if (Input.GetKey(_upKey)) {
			_body.AddForce(transform.forward * _force * Time.deltaTime);
		}
		// Handle moving backward
		if (Input.GetKey(_downKey)) {
			_body.AddForce(transform.forward * -_force * Time.deltaTime);
		}
		// Handle jumping
		if (Input.GetKeyDown(_jumpKey) && Mathf.Abs(_body.velocity.y) < 0.01f) {
			_body.AddForce(0, _jumpForce * Time.deltaTime, 0);
			_body.AddTorque(_jumpTorque, _jumpTorque, _jumpTorque);
		}
	}
}
