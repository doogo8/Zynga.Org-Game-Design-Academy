using UnityEngine;
using System.Collections;

/// <summary>
/// Sends a message to the target object
/// 
/// @author rhagan
/// </summary>
public class SendMessageAction : BaseAction {

	public string message;

	public string target;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		GameObject targetObj = obj;
		if (!string.IsNullOrEmpty(target)) {
			targetObj = GameObject.Find(target);
		}
		if (targetObj != null) {
			targetObj.SendMessage(message);
		}
	}
}
