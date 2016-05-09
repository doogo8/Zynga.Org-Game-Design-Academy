 //import UnityEngine;
//import System.Collections;
//import System.Collections.Generic;

/// <summary>
/// Base collision class: triggers a list of actions on collision.
/// 
/// @author rhagan
/// </summary>
class BaseCollideJs extends MonoBehaviour {
	
	/// <summary>
	/// List of actions to run.
	/// </summary>
	var actions:BaseActionJs[];
	
	/// <summary>
	/// If true, triggers on the other GameObject.
	/// </summary>
	 var onOther : boolean= false;
	
	/// <summary>
	/// The required tag for the collided object.
	/// </summary>
	 var requiredTag : String= null;
	
	/// <summary>
	/// If set, will not collide with creator
	/// </summary>
	 var excludeCreator : boolean= true;

	/// <summary>
	/// The require opposite team.
	/// </summary>
	 var requireOppositeTeam : boolean= false;

	 var disableOnStart : boolean= false;

	private function Awake () : void {
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
	protected virtual function Collide ( other : GameObject  ) : void {
		if (!enabled || other.transform.root == gameObject.transform.root) {
			return;
		}
		 var obj : GameObject= gameObject;
		 var isCreator : boolean= false;
		if (excludeCreator) {
//			 var creation : Creation= GetComponent(Creation);
//			if (creation != null) {
//				isCreator = creation.creator == other;
//			}
		}
//		if (!isCreator && (!requireOppositeTeam || Team.IsDifferentTeam(Team.GetTeam(gameObject), Team.GetTeam(other))) && 
//		    	(string.IsNullOrEmpty(requiredTag) || other.CompareTag(requiredTag))) 
//		{
			if (onOther) {
				obj = other;
			}
			for (var action:BaseActionJs in actions) {
				action.CheckRun(obj);
			}
//		}
	}

	function DelayedDisable(seconds : float):void {
		enabled = true;
		DelayedDisableHelper(seconds);
	}

	function DelayedDisable():void {
		DelayedDisable(2);
	}

	private function DelayedDisableHelper ( seconds : float  ) : IEnumerator {
		yield new WaitForSeconds(seconds);
		enabled = false;
	}
}
