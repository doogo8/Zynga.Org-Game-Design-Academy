using UnityEngine;
using System.Collections;

/// <summary>
/// Adds to a given attribute
/// 
/// @author rhagan
/// </summary>
public class AddAttributeAction : BaseAction {

	public string attribute;

	public float amount;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
//		Attributes attr = obj.GetComponent<Attributes>();
//		if (attr != null) {
//			attr.Get(attribute).increase(amount); 
//		}
	}
}
