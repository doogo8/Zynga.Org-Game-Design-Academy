using UnityEngine;
using System.Collections;

/// <summary>
/// A script for specifying a target (such as a zombie targeting a survivor).
/// </summary>
public class Target : MonoBehaviour {
	
	/// <summary>
	/// The game object to target.
	/// </summary>
	public GameObject target;
	
	/// <summary>
	/// Whether to target the closest enemy.
	/// </summary>
	public bool targetClosestEnemy = true;
	
	/// <summary>
	/// The position that is targeted.
	/// </summary>
	public Vector3 targetPosition;
	
	/// <summary>
	/// Whether to face target.
	/// </summary>
	public bool faceTarget = true;
	
	/// <summary>
	/// Whether to target start position if no enemy targets are in sight.
	/// </summary>
	public bool targetStartPosition = true;
	
	/// <summary>
	/// The sight range for targeting enemies.
	/// </summary>
	public float sightRange = 30;
	
	/// <summary>
	/// The interval seconds for updating target.
	/// </summary>
	public float intervalSecs = 1;
	
	/// Whether this object should initially target its creator. */
	public bool targetCreator = false;

	/// <summary>
	/// The cached team.
	/// </summary>
	private Team team;
	
	/// <summary>
	/// The start position.
	/// </summary>
	private Vector3 startPosition;
	
	/// <summary>
	/// Returns the direction the object is facing.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public static Vector3 GetDirection(GameObject obj, bool excludeY = true) {
		Target target = obj.GetComponent<Target>();
		return target.GetDirection(excludeY);
	}
	
	/// Use this for initialization
	void Start () {		
		startPosition = gameObject.transform.position;
		team = GetComponent<Team>();
		
		if (targetCreator && team.creator) {
			target = team.creator;
		} else if (targetClosestEnemy) {
			if (team) {
				GameObject obj = Team.GetClosestDifferentTeam(
					transform.position, team.team);

				target = obj;
				if (target) {
					targetPosition = target.transform.position;
				}
			}
		}
				
//		if (intervalSecs >= 0) {
//			InvokeRepeating("intervalUpdate", 0, intervalSecs);
//		}
	}

	private void Update() {
		IntervalUpdate();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void IntervalUpdate() {
		UpdateTarget();
	}
	
	/// <summary>
	/// Updates the target for this object.
	/// </summary>
	public void UpdateTarget() {
		// target closest enemy
		if ((target == null || !target.activeInHierarchy) && targetClosestEnemy && team) {
			GameObject obj = Team.GetClosestDifferentTeam(transform.position, team.team);
			target = obj;
		}
		
		// update target position
		if (target != null) {
			targetPosition = target.transform.position;
				
			// reset target if it is too far
			float distance = (targetPosition - gameObject.transform.position).magnitude;
			if (distance > sightRange) {
				target = null;
				targetPosition = startPosition;
			}
		}

		// face the target
		if (faceTarget) {
			if (GetComponent<Rigidbody>() && (targetPosition - transform.position).magnitude < .5f) {
				GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			gameObject.transform.forward = GetDirection();
		}
	}

	/// <summary>
	/// Gets the aim direction.
	/// </summary>
	/// <returns>
	/// The direction.
	/// </returns>
	public Vector3 GetDirection(bool excludeY = true) {
		Vector3 dir = targetPosition - gameObject.transform.position;
		if (excludeY) {
			dir.y = 0;
		}
		// just return forward if next to start point
		if (dir.magnitude < .5f) {
			return gameObject.transform.forward;
		} 
		dir.Normalize();
		return dir;
	}
	
	/// <summary>
	/// Gets the target for a game object.
	/// </summary>
	/// <returns>
	/// The target.
	/// </returns>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public static GameObject GetTarget(GameObject obj) {
		Target target = obj.GetComponent<Target>();
		return target ?
			target.target : null;
	}
}
