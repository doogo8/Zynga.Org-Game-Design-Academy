 //import UnityEngine;
//import System.Collections;
//import System.Collections.Generic;

/// <summary>
/// Contains mapping of action by id for an object ( networking : for  ).
/// </summary>
class ActionsJs extends MonoBehaviour {

	var _actions : BaseActionJs[];

	public function GetActions() : BaseActionJs[] {
		 return _actions;
	}

	private function Awake () : void {
		_actions = GetComponents(BaseActionJs);
	}

	function GetAction ( id : int  ) : BaseActionJs {
		return (_actions.Count > id && id >= 0) ? _actions[id] : null;
	}

	// TODO: rhagan
//	function GetId ( act : BaseActionJs  ) : int {
//		return _actions.IndexOf(act);
//	}
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
