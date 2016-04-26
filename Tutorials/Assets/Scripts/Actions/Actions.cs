using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Contains mapping of action by id for an object (for networking).
/// </summary>
public class Actions : MonoBehaviour {

	private List<BaseAction> _actions = null;

	public List<BaseAction> GetActions() {
		return _actions;
	}

	private void Awake() {
		_actions = new List<BaseAction>(GetComponents<BaseAction>());
	}

	public BaseAction GetAction(int id) {
		return (_actions.Count > id && id >= 0) ? _actions[id] : null;
	}

	public int GetId(BaseAction act) {
		return _actions.IndexOf(act);
	}

	public static int GetId(GameObject obj, BaseAction act) {
		Actions actions = obj.GetComponent<Actions>();
		if (actions == null) {
			actions = obj.AddComponent<Actions>();
		}
		return actions.GetId(act);
	}

	public static Actions GetOrCreate(GameObject obj) {
		Actions acts = obj.GetComponent<Actions>();
		return acts == null ? obj.AddComponent<Actions>() : acts;
	}
}
