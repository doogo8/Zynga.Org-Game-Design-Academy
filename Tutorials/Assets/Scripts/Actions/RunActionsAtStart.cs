using UnityEngine;
using System.Collections;

/// <summary>
/// Runs actions at start
/// 
/// @author rhagan
/// </summary>
public class RunActionsAtStart : BaseAction {

	/// <summary>
	/// The actions to run.
	/// </summary>
	public BaseAction[] actions;

	private void Start() {
		foreach (BaseAction act in actions) {
			act.Run(gameObject, new ActionData());
		}
	}
}
