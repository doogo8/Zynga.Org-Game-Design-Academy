using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Persists the object across loading a new scene.
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour {	

	private void Awake() {
		Object.DontDestroyOnLoad(gameObject);
	}
}
