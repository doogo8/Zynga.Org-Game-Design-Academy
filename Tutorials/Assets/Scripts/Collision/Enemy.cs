using UnityEngine;
using System.Collections;

/// <summary>
/// Running into an enemy restarts the level.
/// 
/// Author: rhagan
/// </summary>
public class Enemy : MonoBehaviour {

	public string requiredTag;

	/// <summary>
	/// Called on collision.
	/// </summary>
	/// <param name="collision">Collision.</param>
	private void OnCollisionEnter(Collision collision) {
		if (string.IsNullOrEmpty (requiredTag) || collision.gameObject.CompareTag (requiredTag)) {
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
