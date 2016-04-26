using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// List of actions that can be run.
/// </summary>
public class ActionList : MonoBehaviour {

	public List<BaseAction> actions;

	private ActionData _data;

	public void RunActions() {
		foreach (BaseAction action in actions) {
			action.Run(gameObject, _data);
		}
	}
}
