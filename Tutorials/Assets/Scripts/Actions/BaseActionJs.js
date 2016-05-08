 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Base action for all actions that a GameObject executes.
/// 
/// @author rhagan
/// </summary>
class BaseActionJs extends MonoBehaviour {

	// TODO: rhagan
//	static event ActionHandler OnActionRun;
//	delegate void ActionHandler( act : BaseAction ,   obj : GameObject ,   data : ActionData  );

	/// <summary>
	/// The energy cost to run the action.
	/// </summary>
	 var energyCost : float;

	/// <summary>
	/// The attributes.
	/// </summary>
//	private Attributes _attributes;

	function Awake () : void {
//		_attributes = GetComponent(Attributes);
	}

	function Run () : void {
		Run(gameObject, new ActionDataJs());
	}

	function Run ( obj : GameObject  ) : void {
		Run(obj, new ActionDataJs());
	}

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	virtual function Run ( obj : GameObject ,   data : ActionDataJs  ) : void {
		
	}

	function CheckRun ( obj : GameObject  ) : void {
		CheckRun(obj, new ActionDataJs());
	}

	/// <summary>
	/// Execute the action.
	/// </summary>
	/// <param name='obj'>
	/// Object doing the action
	/// </param>
	virtual function CheckRun ( obj : GameObject ,   data : ActionDataJs  ) : void {
		if (energyCost <= 0) {// || _attributes == null || _attributes.TryRemove(Attributes.ENERGY, energyCost)) {
			DoRun(obj, data);
		}
	}

	private function DoRun ( obj : GameObject ,   data : ActionDataJs  ) : void {
		Run(obj, data);
//		if (OnActionRun != null) {
//			OnActionRun(this, obj, data);
//		}
	}
}
