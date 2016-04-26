using UnityEngine;
using System.Collections;

/// <summary>
/// Resets the game.
/// 
/// @author rhagan
/// </summary>
public class ResetGameAction : BaseAction {
	
	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		Application.LoadLevel(Application.loadedLevelName);
	}
}
