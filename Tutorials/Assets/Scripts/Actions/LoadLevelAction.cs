using UnityEngine;
using System.Collections;

/// <summary>
/// Loads a level (by id or serialized field)
/// 
/// @author rhagan
/// </summary>
public class LoadLevelAction : BaseAction {

	/// <summary>
	/// Name of level to load
	/// </summary>
	public string levelName;

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		string levelId = levelName;
//		if (data != null && data.id != null) 
		{
			levelId = data.id;
		}
		Application.LoadLevel(levelId);
	}
}
