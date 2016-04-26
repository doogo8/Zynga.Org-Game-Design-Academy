using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Updates an object based on AI logic 
/// (does actions at interval and accounts for target).
/// </summary>
public class AIControl : MonoBehaviour {
	
	/// <summary>
	/// The interval to execute actions at.
	/// </summary>
	public float intervalSecs = 1;
	
	/// <summary>
	/// If true, must have a target to use actions.
	/// </summary>
	public bool requiresTarget = true;
	
	/// <summary>
	/// The required mode to run in.
	/// </summary>
	public string requiredMode = "";
	
	/// <summary>
	/// List of actions to run (randomly pick one each intervalSecs).
	/// </summary>
	public List<BaseAction> actions = new List<BaseAction>();

	/// <summary>
	/// The last update time.
	/// </summary>
//	private float lastUpdateTime = 0;
	
	/// <summary>
	/// Cached target component.
	/// </summary>
	private Target target;
	
	/// <summary>
	/// Reusable ActionData.
	/// </summary>
	private static ActionData m_data = new ActionData();

	// Use this for initialization
	void Start () {
		if (intervalSecs >= 0) {
			InvokeRepeating("intervalUpdate", 0, intervalSecs);
		}
		target = gameObject.GetComponent<Target>();
	}

	/// <summary>
	/// Updates this action every interval.
	/// </summary>
	void intervalUpdate() {
		if (gameObject.activeInHierarchy) {
//		    && (requiredMode == "" || ObjectManager.getMode() == requiredMode)) {
			if (target) {
				target.UpdateTarget();
			}

			// action
			if ((!requiresTarget || Target.GetTarget(gameObject) != null) && 
					actions.Count > 0) {
				int idIndex = Random.Range(0, actions.Count);
				BaseAction act = actions[idIndex];
				if (act != null) {
					act.CheckRun(gameObject, m_data);
				}
			}
		} else {
			CancelInvoke("intervalUpdate");
		}
	}
}
