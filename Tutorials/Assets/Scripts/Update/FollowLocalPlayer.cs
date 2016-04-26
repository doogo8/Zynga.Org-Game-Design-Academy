using UnityEngine;
using System.Collections;

/// <summary>
/// Script to update to an offset from the local player (the player you own in networked games).
/// 
/// Author rhagan
/// </summary>
public class FollowLocalPlayer : MonoBehaviour {
	
	/// <summary>
	/// The offset to move this object from its target.
	/// </summary>
	public Vector3 offset;

	private GameObject _target;
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	virtual protected void Update() {
//		if (_target == null && ObjectManager.Instance != null) {
//			_target = ObjectManager.Instance.LocalPlayer;
//		}
		if (_target != null) {
			Vector3 targetPos = _target.transform.position;
			transform.position = targetPos + offset;
			transform.LookAt(targetPos);
		}
	}
	
	public void OnCameraFollowSwitch() {
		enabled = !enabled;
	}
}
