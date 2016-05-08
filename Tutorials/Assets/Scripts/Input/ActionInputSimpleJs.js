 //import UnityEngine;
//import System.Collections;
//import System.Collections.Generic;

/// <summary>
/// Defines an input trigger for an action without networking.
/// </summary>
class ActionInputSimpleJs extends MonoBehaviour {
	
	/// <summary>
	/// List of actions to execute
	/// </summary>
	var actions:BaseActionJs[];
	
	/// <summary>
	/// Whether to do action when object is created.
	/// </summary>
	 var executeAtStart : boolean= false;
	
	/// Whether input is enabled ( press : checks   : for   : key  ).
	 var inputEnabled : boolean= true;
	
	/// Key to listen for if input is enabled. */
	 var keyTrigger : String= "";
	
	/// <summary>
	/// Whether you can hold the key down to continuously do it.
	/// </summary>
	 var canHoldKey : boolean= false;
	
	/// Whether this action is triggered on mouse down. */
	 var onMouseDown : boolean= false;
	
	/// <summary>
	/// Whether the object itself has to be clicked to trigger the action.
	/// </summary>
	 var selfClick : boolean= false;
	
	/// <summary>
	/// Whether to execute the action on the clicked object.
	/// </summary>
	 var useClickedObject : boolean= false;
	
	/// <summary>
	/// The required tag for the game object to run the action on.
	/// </summary>
	 var requiredTag : String= "";
	
	/// Whether this action is triggered when right mouse button is down. */
	 var onMouseRightDown : boolean= false;
	
	/// Energy cost to use this action. */
	 var energyCost : float= 0;
	
	/// Build Energy cost to use this action. */
	 var buildEnergyCost : float= 0;
	
	/// The number of times the action will be used
	 var useCount : int= 1;
	
	/// <summary>
	/// The interval for doing this action ( disabled : less   : than   : 0   : for  ).
	/// </summary>
	 var executeInterval : float= -1;

	 var requireLocalPlayer : boolean= false;

	/// <summary>
	/// The time passed since use.
	/// </summary>
	private  var timePassedSinceUse : float= 0;

	/// <summary>
	/// The identifier counter.
	/// </summary>
//	private static long idCounter = 0;
	
	/// <summary>
	/// Data to reuse.
	/// </summary>
	private  var _data : ActionDataJs= new ActionDataJs();

	/// <summary>
	/// The attributes for energy.
	/// </summary>
//	private Attributes _attributes;

//	private ObjectId _id;

	private  var _actions : ActionsJs;

	/// Use this for initialization
	function Start () : void {
//		_id = GetComponent(ObjectId);
//		_attributes = GetComponent(Attributes);
		_actions = GetComponent(ActionsJs);
		if (executeAtStart) {
			for ( var i : int= 0; i < useCount; ++i) {
				RunActions();
			}
		}
	}

	/// Update is called once per frame
	protected function Update () : void {
		timePassedSinceUse += Time.deltaTime;
		
		// check if the action is triggered by input or time
		// TODO: get this to work
		 var selfClickPass : boolean= true;
//		if (selfClick && Input.GetMouseButtonDown(0)) {
//			Ray mouseRay = ShootToMouseAction.getMouseRay();
//			RaycastHit newHitInfo;
//			Physics.Raycast(mouseRay.origin, mouseRay.direction,  newHitInfo : out  );
//			if (!newHitInfo.rigidbody || newHitInfo.rigidbody.gameObject != gameObject) {
//				selfClickPass = false;
//			}
//		}
		
		 var obj : GameObject= gameObject;
		
//		if (useClickedObject) {
//			// check for clicked object
//			if (Input.GetMouseButtonDown(0)) {
//				obj = PickUtil.GetObjectUnderMouseRay();
//				if (obj == null) {
//					return;
//				}
//			} else {
//				return;
//			}
//		}
//		
		if (requiredTag != "") {
			if (!obj.CompareTag(requiredTag)) {
				return;
			}
		}

		 var keyDown : boolean= keyTrigger != "" && (Input.GetKeyDown(keyTrigger) || 
			(canHoldKey && Input.GetKey(keyTrigger)));
		 var inputTriggered : boolean= inputEnabled && (keyDown || 
			(onMouseDown && selfClickPass && 
			(Input.GetMouseButtonDown(0) ||
			(Input.GetMouseButton(0) && canHoldKey) )));
		 var timeTriggered : boolean= executeInterval >= 0 && timePassedSinceUse >= executeInterval;

				
		if (inputTriggered || timeTriggered) {
			for ( var i : int= 0; i < useCount; ++i) {
				RunActions(); // obj
			}
		}
	}

//	private function CmdRun ( obj : GameObject  ) : void {
//		int id = ObjectManager.Instance.GetId(obj);
//		_data.mousePos = ActionInput.GetMousePos(_data);
//		if (isServer) {
//			RpcRun(id, _data);
//		} else {
//			CmdRun(id, _data);
//		}
//	}
//
//	[Command]
//	virtual function CmdRun ( id : int ,   data : ActionData  ) : void {
//		Run(id, data);
//	}
//
//	[ClientRpc]
//	virtual function RpcRun ( id : int ,   data : ActionData  ) : void {
//		Run(id, data);
//	}

	static function GetMousePos(data:ActionDataJs) : Vector3 {
		 var mouseRay : Ray= data == null ? 
			PickUtilJs.GetMouseRay() : PickUtilJs.GetScreenRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		 var hitT : float;
		 var pos : Vector3= PickUtilJs.GetXZPlaneHitPointForRay( hitT ,  mouseRay);
		 return pos;
	}
//	
//	/// Override this to execute the action. */
//	virtual function Run ( id : int ,   data : ActionData  ) : void {
//		GameObject actObj = ObjectManager.Instance.GetObject(id);
//
//		//		if (NetworkManager.singleton && NetworkManager.singleton.client != null) {
////			ActionData actData = new ActionData();
////			actData.mousePos = Input.mousePosition;
////			for( actions : BaseAction   : act   : in  ) {
////				NetworkSystem.Instance.SendRPCRunAction(RPCMode.Server, 
////					ObjectManager.Instance.GetId(actObj), Actions.GetId(actObj, act), actData);
////			}
////		} else 
//		{
//			if (_attributes == null || _attributes.TryRemove("energy", energyCost)) {
//				timePassedSinceUse = 0;
//
//				for( actions : BaseAction   : act   : in  ) {
//					act.CheckRun(actObj, data);
//				}
//			}
//		}
//	}

	private function RunActions () : void {
		for( var act:BaseActionJs in actions) {
			RunAction(_actions.GetId(act));
		}
	}

	private function RunAction ( id : int  ) : void {
//		if (ActionRunner.Instance == null) {
			_actions.GetAction(id).CheckRun(gameObject);
//		} else {
//			ActionRunner.Instance.RunAction(gameObject, _actions.GetAction(id));
//		}
	}
}
