 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Physics player controller in 2D.
/// Can move left or right or jump.
/// 
/// Author: rhagan
/// </summary>
class PlayerController2DJs extends MonoBehaviour {

	/// <summary>
	/// The jump input key.
	/// </summary>
	
	public  var _jumpKey : String= "up";

	/// <summary>
	/// The input key to move left.
	/// </summary>
	
	public  var _leftKey : String= "left";

	/// <summary>
	/// The input key to move right.
	/// </summary>
	
	public  var _rightKey : String= "right";

	/// <summary>
	/// The force to move with.
	/// </summary>
	
	public  var _force : float= 10;

	/// <summary>
	/// The force to jump with.
	/// </summary>
	
	public  var _jumpForce : float= 400;

	/// <summary>
	/// The torque to apply on jump.
	/// </summary>
	
	public  var _jumpTorque : float= 100;

	/// <summary>
	/// The Rigidbody to apply a force to.
	/// </summary>
	
	public  var _body : Rigidbody= null;
	
	protected  var _sprite : SpriteRenderer;

	function Start () : void {
		if (_body == null) {
			// set to this rigidbody if unset
			_body = GetComponent(Rigidbody);
		}
		_sprite = GetComponentInChildren(SpriteRenderer);
	}

	// Update is called once per frame
	function Update () : void {
		if (Input.GetKey(_leftKey)) {
			_body.AddForce(-_force, 0, 0);
			if (_sprite != null) {
				 var scale : Vector3= _sprite.transform.localScale;
				_sprite.transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
			}
		}
		if (Input.GetKey(_rightKey)) {
			_body.AddForce(_force, 0, 0);
			if (_sprite != null) {
				 var scale2 : Vector3= _sprite.transform.localScale;
				_sprite.transform.localScale = new Vector3(Mathf.Abs(scale2.x), scale2.y, scale2.z);
			}
		}
		if (Input.GetKeyDown(_jumpKey) && Mathf.Abs(_body.velocity.y) < 0.01f) {
			_body.AddForce(0, _jumpForce, 0);
			_body.AddTorque(_jumpTorque, _jumpTorque, _jumpTorque);
		}
	}
}
