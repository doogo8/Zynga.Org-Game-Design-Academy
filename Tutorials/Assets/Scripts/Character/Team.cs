using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Team for a shot or player.
/// 
/// @author rhagan
/// </summary>
public class Team : MonoBehaviour {
	
	/// <summary>
	/// No team, meaning it can hurt anyone else.
	/// </summary>
	public const int NO_TEAM = 0;
	
	// USE POWERS OF 2 FOR & to work
	/// <summary>
	/// The player team.
	/// </summary>
	public const int PLAYER = 1;
	
	/// <summary>
	/// The enemy team.
	/// </summary>
	public const int ENEMY = 2;
	
	/// <summary>
	/// The team.
	/// </summary>
	public int team = NO_TEAM;
	
	/// The creator of this. */
	// TODO: consider deleting for Creation
	public GameObject creator = null;

	/// <summary>
	/// Whether this can be targeted by other AI characters.
	/// </summary>
	public bool isTargetable = true;

	/// <summary>
	/// The global list of objects with a Team component.
	/// </summary>
	private static List<GameObject> _teamObjects = new List<GameObject>();

	void Start() {
		_teamObjects.Add(gameObject);
	}

	void OnDestroy() {
		_teamObjects.Remove(gameObject);
	}
	
	/// <summary>
	/// Gets the team for any game object or NO_TEAM if it has no team.
	/// </summary>
	/// <returns>
	/// The team.
	/// </returns>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public static int GetTeam(GameObject obj) {
		int result = NO_TEAM;
		Team team = obj.GetComponent<Team>();
		if (team) {
			result = team.team;
		}
		return result;
	}
	
	/// <summary>
	/// Returns the closest object to the point of a different team.
	/// </summary>
	/// <param name='pos'>
	/// Position.
	/// </param>
	/// <param name='team'>
	/// Team.
	/// </param>
	public static GameObject GetClosestDifferentTeam(Vector3 pos, int team) {
		Team closestObj = null;
		float closestDist = Mathf.Infinity;
		float currentDistance = 0;
		Team chara2 = null;
		
		// check all characters
		foreach (GameObject obj in _teamObjects) {
			chara2 = obj.GetComponent<Team>();
			if (chara2 && chara2.team != team && chara2.isTargetable) {
				currentDistance = Vector3.Distance(obj.transform.position, pos);
				if (currentDistance < closestDist) {
					closestDist = currentDistance;
					closestObj = chara2;
				}
			}
		}
		return closestObj ? closestObj.gameObject : null;
	}
		
	/// <summary>
	/// Returns the closest object to the point of the same team.
	/// </summary>
	/// <param name='pos'>
	/// Position.
	/// </param>
	/// <param name='team'>
	/// Team.
	/// </param>
	public static GameObject GetClosestSameTeam(Vector3 pos, int team) {
		Team closestObj = null;
		float closestDist = Mathf.Infinity;
		float currentDistance = 0;
		Team chara2 = null;
		
		// check all characters
		foreach (GameObject obj in _teamObjects) {
			chara2 = obj.GetComponent<Team>();
			if (chara2 && chara2.team == team) {
				currentDistance = Vector3.Distance(obj.transform.position, pos);
				if (currentDistance < closestDist) {
					closestDist = currentDistance;
					closestObj = chara2;
				}
			}
		}
		return closestObj ? closestObj.gameObject : null;
	}
	
	/// <summary>
	/// Gets the number of players on a team.
	/// </summary>
	/// <returns>
	/// The team count.
	/// </returns>
	/// <param name='team'>
	/// Team.
	/// </param>
	public static int GetTeamCount(int team) {
		int count = 0;
		Team chara = null;

		// check all characters
		foreach (GameObject obj in _teamObjects) {
			chara = obj.GetComponent<Team>();
			if (chara.team == team) {
				count++;
			}
		}
		
		return count;
	}

	/// <summary>
	/// Returns whether 2 teams are different.
	/// </summary>
	/// <returns>
	/// Whether teams are different.
	/// </returns>
	/// <param name='team1'>
	/// </param>
	/// <param name='team2'>
	/// </param>
	public static bool IsDifferentTeam(int team1, int team2) {
		return team1 != team2 && team1 != NO_TEAM && team2 != NO_TEAM;
	}

	/// <summary>
	/// Copies the team from copyFrom to copyTo (if a team component exists).
	/// </summary>
	/// <returns>
	/// The team.
	/// </returns>
	/// <param name='copyTo'>
	/// If set to <c>true</c> copy to.
	/// </param>
	/// <param name='copyFrom'>
	/// If set to <c>true</c> copy from.
	/// </param>
	public static bool CopyTeam(GameObject copyTo, GameObject copyFrom) {
		Team toTeam = copyTo.GetComponent<Team>();
		if (toTeam) {
			toTeam.team = Team.GetTeam(copyFrom);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Returns the creator if there is one; otherwise the object itself.
	/// </summary>
	/// <returns>The creator or self.</returns>
	/// <param name="obj">Object.</param>
	public static GameObject GetCreatorOrSelf(GameObject obj) {
		Team team = obj.GetComponent<Team>();
		return team.creator == null ? obj : team.creator;
	}
}

