using UnityEngine;
using System.Collections;

/// <summary>
/// Base action for all actions that a GameObject executes.
/// 
/// @author rhagan
/// </summary>
public class BaseAction : MonoBehaviour {
	
	public static event ActionHandler OnActionRun;
	public delegate void ActionHandler(BaseAction act, GameObject obj, ActionData data);

	/// <summary>
	/// The energy cost to run the action.
	/// </summary>
	public float energyCost;

	/// <summary>
	/// The attributes.
	/// </summary>
//	private Attributes _attributes;

	void Awake() {
//		_attributes = GetComponent<Attributes>();
	}

	public void Run() {
		Run(gameObject, new ActionData());
	}

	public void Run(GameObject obj) {
		Run(obj, new ActionData());
	}

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	virtual public void Run(GameObject obj, ActionData data) {
		
	}

	public void CheckRun(GameObject obj) {
		CheckRun(obj, new ActionData());
	}

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	virtual public void CheckRun(GameObject obj, ActionData data) {
		if (energyCost <= 0) {// || _attributes == null || _attributes.TryRemove(Attributes.ENERGY, energyCost)) {
			DoRun(obj, data);
		}
	}

	private void DoRun(GameObject obj, ActionData data) {
		Run(obj, data);
		if (OnActionRun != null) {
			OnActionRun(this, obj, data);
		}
	}
}
