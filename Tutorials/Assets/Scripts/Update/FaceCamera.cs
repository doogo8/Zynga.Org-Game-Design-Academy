using UnityEngine;
using System.Collections;

/// <summary>
/// Looks at the camera each frame.
/// </summary>
public class FaceCamera : MonoBehaviour {

	private Camera _cam;

	private void Start() {
		_cam = Camera.main;
	}
	
	/// Update is called once per frame
	void Update () {
		if (_cam != null) {
			transform.LookAt(_cam.transform.position);
		}
	}
}
