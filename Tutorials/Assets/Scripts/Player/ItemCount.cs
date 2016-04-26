using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps track of and shows item count.
/// 
/// Author: rhagan
/// </summary>
public class ItemCount : MonoBehaviour {

	/// <summary>
	/// Number of items.
	/// </summary>
	public int itemCount = 0;

	private void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 20), "Score: " + itemCount);
	}
}
