 //import UnityEngine;
//import System.Collections;
//import System.Collections.Generic;

/// <summary>
/// Contains mapping of action by id for an object ( networking : for  ).
/// </summary>
class ActionsJs extends MonoBehaviour {

	var _actions : Component[];

	public function GetActions() : Component[] {
		 return _actions;
	}

	private function Awake () : void {
		_actions = GetComponents(BaseActionJs);
	}

	function GetAction ( id : int  ) : BaseActionJs {
		return (_actions.Length > id && id >= 0) ? _actions[id] : null;
	}

	function GetId ( act : Component  ) : int {
		return ArrayUtility.IndexOf(_actions, act);
	}
//
//	static function GetId ( obj : GameObject ,   act : BaseActionJs  ) : int {
//		 var actions : ActionsJs= obj.GetComponent(ActionsJs);
//		if (actions == null) {
//			actions = obj.AddComponent(ActionsJs);
//		}
//		return actions.GetId(act);
//	}
//
	static function GetOrCreate ( obj : GameObject  ) : ActionsJs {
		 var acts : ActionsJs= obj.GetComponent(ActionsJs);
		 return acts == null ? obj.AddComponent(ActionsJs) : acts;
	}
}
