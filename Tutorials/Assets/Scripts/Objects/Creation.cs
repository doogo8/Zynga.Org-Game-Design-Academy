using UnityEngine;
using System.Collections;

/// <summary>
/// A script that holds a reference to the creator of an object (the object that spawned this one).
/// 
/// Author: rhagan
/// </summary>
public class Creation : MonoBehaviour {

	/// The creator of this object.
	public GameObject creator;

	/// <summary>
	/// Returns the creator if there is one; otherwise the object itself.
	/// </summary>
	/// <returns>The creator or self.</returns>
	/// <param name="obj">Object.</param>
	public static GameObject GetCreatorOrSelf(GameObject obj) {
		Creation creation = obj.GetComponent<Creation>();
		return (creation == null || creation.creator == null) ? obj : creation.creator;
	}
}
