using UnityEngine;
using System.Collections;

/// <summary>
/// Physics player controller in 2D.
/// Can move left or right or jump.
/// 
/// Author: rhagan
/// </summary>
public class PlayerController2D : MonoBehaviour {

	/// <summary>
	/// The jump input key.
	/// </summary>
	[SerializeField]
	private string _jumpKey = "up";

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
	/// The force to move with.
	/// </summary>
	[SerializeField]
	private float _force = 10;

	/// <summary>
	/// The force to jump with.
	/// </summary>
	[SerializeField]
	private float _jumpForce = 400;

	/// <summary>
	/// The torque to apply on jump.
	/// </summary>
	[SerializeField]
	private float _jumpTorque = 100;

	/// <summary>
	/// The Rigidbody to apply a force to.
	/// </summary>
	[SerializeField]
	private Rigidbody _body = null;
	
	protected SpriteRenderer _sprite;

	void Start() {
		if (_body == null) {
			// set to this rigidbody if unset
			_body = GetComponent<Rigidbody>();
		}
		_sprite = GetComponentInChildren<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(_leftKey)) {
			_body.AddForce(-_force, 0, 0);
			if (_sprite != null) {
				Vector3 scale = _sprite.transform.localScale;
				_sprite.transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
			}
		}
		if (Input.GetKey(_rightKey)) {
			_body.AddForce(_force, 0, 0);
			if (_sprite != null) {
				Vector3 scale = _sprite.transform.localScale;
				_sprite.transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
			}
		}
		if (Input.GetKeyDown(_jumpKey) && Mathf.Abs(_body.velocity.y) < 0.01f) {
			_body.AddForce(0, _jumpForce, 0);
			_body.AddTorque(_jumpTorque, _jumpTorque, _jumpTorque);
		}
	}
}
