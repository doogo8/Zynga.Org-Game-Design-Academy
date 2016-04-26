using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Runs an action when team count goes below a certain value
/// (continually checks team count).
/// 
/// @author rhagan
/// </summary>
public class CheckTeamCount : MonoBehaviour {

	/// <summary>
	/// The actions to run.
	/// </summary>
	public BaseAction[] actions;

	/// <summary>
	/// The team id to check for.
	/// </summary>
	public int team = 0;

	/// <summary>
	/// If team count drops at or below this, run the actions.
	/// </summary>
	public int teamCount = 0;

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start() {
		StartCoroutine(UpdateCheck());
	}

	/// <summary>
	/// Updates the check.
	/// </summary>
	private IEnumerator UpdateCheck() {
		while (true) {
			if (Team.GetTeamCount(team) <= teamCount) {
				break;
			}
			yield return new WaitForSeconds(1);
		}
		foreach (BaseAction act in actions) {
			act.Run(gameObject);
		}
	}
}
