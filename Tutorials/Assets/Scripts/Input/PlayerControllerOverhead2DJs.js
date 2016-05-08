 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Physics player controller in 2D.
/// Can move left or right or jump.
/// 
/// Author: rhagan
/// </summary>
class PlayerControllerOverhead2DJs extends MonoBehaviour {

	/// <summary>
	/// The input key to move left.
	/// </summary>
	
	public  var _leftKey : String= "left";

	/// <summary>
	/// The input key to move right.
	/// </summary>
	
	public  var _rightKey : String= "right";

	
	public  var _upKey : String= "up";

	
	public  var _downKey : String= "down";

	/// <summary>
	/// The force to move with.
	/// </summary>
	
	public  var _force : float= 10;

	/// <summary>
	/// The Rigidbody to apply a force to.
	/// </summary>
	
	public  var _body : Rigidbody= null;

	 var faceDirection : boolean= true;

	function Start () : void {
		if (_body == null) {
			// set to this rigidbody if unset
			_body = GetComponent(Rigidbody);
		}
	}

	// Update is called once per frame
	function Update () : void {
		 var rotation : Vector3= _body.transform.localRotation.eulerAngles;
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
