using UnityEngine;
using System.Collections;

/// <summary>
/// Item that you can collect.
/// 
/// Author: rhagan
/// </summary>
public class Item : MonoBehaviour {
	
	/// <summary>
	/// Called on collision.
	/// </summary>
	/// <param name="collision">Collision.</param>
	private void OnCollisionEnter(Collision collision) {
		ItemCount itemCount = collision.gameObject.GetComponent<ItemCount>();
		if (itemCount != null) {
			itemCount.itemCount++;
			Destroy(gameObject);
		}
	}
}
