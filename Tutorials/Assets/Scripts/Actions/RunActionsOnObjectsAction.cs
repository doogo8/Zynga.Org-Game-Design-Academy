using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys after a delay.
/// 
/// @author rhagan
/// </summary>
public class RunActionsOnObjectsAction : BaseAction {

	/// <summary>
	/// The tag for objects to run on.
	/// </summary>
	public string objectTag;

	/// <summary>
	/// The actions to run on the object.
	/// </summary>
	public BaseAction[] actions;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
		foreach (GameObject anObj in objects) {
			foreach (BaseAction act in actions) {
				act.Run(anObj, new ActionData());
			}
		}
	}
}
