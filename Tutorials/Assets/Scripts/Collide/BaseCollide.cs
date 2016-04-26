using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Base collision class: triggers a list of actions on collision.
/// 
/// @author rhagan
/// </summary>
public class BaseCollide : MonoBehaviour {
	
	/// <summary>
	/// List of actions to run.
	/// </summary>
	public List<BaseAction> actions = new List<BaseAction>();
	
	/// <summary>
	/// If true, triggers on the other GameObject.
	/// </summary>
	public bool onOther = false;
	
	/// <summary>
	/// The required tag for the collided object.
	/// </summary>
	public string requiredTag = null;
	
	/// <summary>
	/// If set, will not collide with creator
	/// </summary>
	public bool excludeCreator = true;

	/// <summary>
	/// The require opposite team.
	/// </summary>
	public bool requireOppositeTeam = false;

	public bool disableOnStart = false;

	private void Awake() {
		if (disableOnStart) {
			enabled = false;
		}
	}
	
	/// <summary>
	/// Raises the collision enter event; triggers the action.
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	protected virtual void Collide(GameObject other) {
		if (!enabled || other.transform.root == gameObject.transform.root) {
			return;
		}
		GameObject obj = gameObject;
		bool isCreator = false;
		if (excludeCreator) {
			Creation creation = GetComponent<Creation>();
			if (creation != null) {
				isCreator = creation.creator == other;
			}
		}
		if (!isCreator && (!requireOppositeTeam || Team.IsDifferentTeam(Team.GetTeam(gameObject), Team.GetTeam(other))) && 
		    	(string.IsNullOrEmpty(requiredTag) || other.CompareTag(requiredTag))) 
		{
			if (onOther) {
				obj = other;
			}
			foreach (BaseAction action in actions) {
				action.CheckRun(obj);
			}
		}
	}

	public void DelayedDisable(float seconds = 2) {
		enabled = true;
		StartCoroutine(DelayedDisableHelper(seconds));
	}

	private IEnumerator DelayedDisableHelper(float seconds) {
		yield return new WaitForSeconds(seconds);
		enabled = false;
	}
}
