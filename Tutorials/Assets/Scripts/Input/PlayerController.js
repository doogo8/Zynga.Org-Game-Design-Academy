 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Physics player controller in 3D.
/// Can move left or right or jump.
/// 
/// Author: rhagan
/// </summary>
class PlayerController extends MonoBehaviour {

	/// <summary>
	/// The jump input key.
	/// </summary>
	public var _jumpKey : String= "space";

	/// <summary>
	/// The input key to move left.
	/// </summary>
	public  var _leftKey : String= "left";

	/// <summary>
	/// The input key to move right.
	/// </summary>
	public  var _rightKey : String= "right";

	/// <summary>
	/// The input key to move up.
	/// </summary>
	public  var _upKey : String= "up";
	
	/// <summary>
	/// The input key to move down.
	/// </summary>
	public  var _downKey : String= "down";

	/// <summary>
	/// The force to move with.
	/// </summary>
	public  var _force : float= 10;

	/// <summary>
	/// The force to move with.
	/// </summary>
	public  var _turnForce : float= 100;

	/// <summary>
	/// The force to jump with.
	/// </summary>
	public  var _jumpForce : float= 400;

	/// <summary>
	/// The torque to apply on jump.
	/// </summary>
	public  var _jumpTorque : float= 0;

	/// <summary>
	/// The Rigidbody to apply a force to.
	/// </summary>
	public  var _body : Rigidbody= null;

	/// <summary>
	/// If true, left and right strafe; if false, they turn.
	/// </summary>
	public  var strafe : boolean= false;

	function Start () : void {
		if (_body == null) {
			// set to this rigidbody if unset
			_body = GetComponent(Rigidbody);
		}
	}

	// Update is called once per frame
	function Update () : void {
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
		if (Input.GetKeyDown(_jumpKey)) {
			_body.AddForce(0, _jumpForce * Time.deltaTime, 0);
			_body.AddTorque(_jumpTorque, _jumpTorque, _jumpTorque);
		}
	}
}
