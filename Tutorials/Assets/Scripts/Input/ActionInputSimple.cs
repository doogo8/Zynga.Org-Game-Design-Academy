using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Defines an input trigger for an action without networking.
/// </summary>
public class ActionInputSimple : MonoBehaviour {
	
	/// <summary>
	/// List of actions to execute
	/// </summary>
	public List<BaseAction> actions;
	
	/// <summary>
	/// Whether to do action when object is created.
	/// </summary>
	public bool executeAtStart = false;
	
	/// Whether input is enabled (checks for key press).
	public bool inputEnabled = true;
	
	/// Key to listen for if input is enabled. */
	public string keyTrigger = "";
	
	/// <summary>
	/// Whether you can hold the key down to continuously do it.
	/// </summary>
	public bool canHoldKey = false;
	
	/// Whether this action is triggered on mouse down. */
	public bool onMouseDown = false;
	
	/// <summary>
	/// Whether the object itself has to be clicked to trigger the action.
	/// </summary>
	public bool selfClick = false;
	
	/// <summary>
	/// Whether to execute the action on the clicked object.
	/// </summary>
	public bool useClickedObject = false;
	
	/// <summary>
	/// The required tag for the game object to run the action on.
	/// </summary>
	public string requiredTag = "";
	
	/// Whether this action is triggered when right mouse button is down. */
	public bool onMouseRightDown = false;
	
	/// Energy cost to use this action. */
	public float energyCost = 0;
	
	/// Build Energy cost to use this action. */
	public float buildEnergyCost = 0;
	
	/// The number of times the action will be used
	public int useCount = 1;
	
	/// <summary>
	/// The interval for doing this action (less than 0 for disabled).
	/// </summary>
	public float executeInterval = -1;

	public bool requireLocalPlayer = false;

	/// <summary>
	/// The time passed since use.
	/// </summary>
	private float timePassedSinceUse = 0;

	/// <summary>
	/// The identifier counter.
	/// </summary>
//	private static long idCounter = 0;
	
	/// <summary>
	/// Data to reuse.
	/// </summary>
	private ActionData _data = new ActionData();

	/// <summary>
	/// The attributes for energy.
	/// </summary>
//	private Attributes _attributes;

//	private ObjectId _id;

	private Actions _actions;

	/// Use this for initialization
	void Start () {
//		_id = GetComponent<ObjectId>();
//		_attributes = GetComponent<Attributes>();
		_actions = GetComponent<Actions>();
		if (executeAtStart) {
			for (int i = 0; i < useCount; ++i) {
				RunActions();
			}
		}
	}

	/// Update is called once per frame
	protected void Update() {
		timePassedSinceUse += Time.deltaTime;
		
		// check if the action is triggered by input or time
		// TODO: get this to work
		bool selfClickPass = true;
//		if (selfClick && Input.GetMouseButtonDown(0)) {
//			Ray mouseRay = ShootToMouseAction.getMouseRay();
//			RaycastHit newHitInfo;
//			Physics.Raycast(mouseRay.origin, mouseRay.direction, out newHitInfo);
//			if (!newHitInfo.rigidbody || newHitInfo.rigidbody.gameObject != gameObject) {
//				selfClickPass = false;
//			}
//		}
		
		GameObject obj = gameObject;
		
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

		bool keyDown = keyTrigger != "" && (Input.GetKeyDown(keyTrigger) || 
			(canHoldKey && Input.GetKey(keyTrigger)));
		bool inputTriggered = inputEnabled && (keyDown || 
			(onMouseDown && selfClickPass && 
			(Input.GetMouseButtonDown(0) ||
			(Input.GetMouseButton(0) && canHoldKey) )));
		bool timeTriggered = executeInterval >= 0 && timePassedSinceUse >= executeInterval;

				
		if (inputTriggered || timeTriggered) {
			for (int i = 0; i < useCount; ++i) {
				RunActions(); // obj
			}
		}
	}

//	private void CmdRun(GameObject obj) {
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
//	virtual public void CmdRun(int id, ActionData data) {
//		Run(id, data);
//	}
//
//	[ClientRpc]
//	virtual public void RpcRun(int id, ActionData data) {
//		Run(id, data);
//	}

	public static Vector3 GetMousePos(ActionData? data) {
		Ray mouseRay = data == null ? 
			PickUtil.GetMouseRay() : PickUtil.GetScreenRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		float hitT;
		Vector3 pos = PickUtil.GetXZPlaneHitPointForRay(out hitT, mouseRay);
		return pos;
	}
//	
//	/// Override this to execute the action. */
//	virtual public void Run(int id, ActionData data) {
//		GameObject actObj = ObjectManager.Instance.GetObject(id);
//
//		//		if (NetworkManager.singleton && NetworkManager.singleton.client != null) {
////			ActionData actData = new ActionData();
////			actData.mousePos = Input.mousePosition;
////			foreach (BaseAction act in actions) {
////				NetworkSystem.Instance.SendRPCRunAction(RPCMode.Server, 
////					ObjectManager.Instance.GetId(actObj), Actions.GetId(actObj, act), actData);
////			}
////		} else 
//		{
//			if (_attributes == null || _attributes.TryRemove("energy", energyCost)) {
//				timePassedSinceUse = 0;
//
//				foreach (BaseAction act in actions) {
//					act.CheckRun(actObj, data);
//				}
//			}
//		}
//	}

	private void RunActions() {
		foreach (BaseAction act in actions) {
			RunAction(_actions.GetId(act));
		}
	}

	private void RunAction(int id) {
//		if (ActionRunner.Instance == null) {
			_actions.GetAction(id).CheckRun(gameObject);
//		} else {
//			ActionRunner.Instance.RunAction(gameObject, _actions.GetAction(id));
//		}
	}
}
