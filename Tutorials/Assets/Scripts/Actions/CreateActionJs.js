 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Creates a given object and applies optional force.
/// 
/// @author rhagan
/// </summary>
class CreateActionJs extends BaseActionJs {

	/// <summary>
	/// The object to create.
	/// </summary>
	 var shot : GameObject;
	
	/// <summary>
	/// The force for the shot.
	/// </summary>
	 var force : float= 1000;

	 var yForce : float= 0;
	
	/// <summary>
	/// The offset to create the object at, in direction of the object's
	/// transform.forward.
	/// </summary>
	 var offset : float= 0;

	/// <summary>
	/// The y offset.
	/// </summary>
	 var yOffset : float= 0;
	
	/// <summary>
	/// Number of seconds to destroy it. -1 for no timed destroy.
	/// </summary>
	 var destroySeconds : float= -1;
	
	/// <summary>
	/// If true, attaches the new object to the creator.
	/// </summary>
	 var attach : boolean= false;

	/// <summary>
	/// The stack vertically.
	/// </summary>
	 var stackVertically : boolean= false;
	
	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override function Run ( obj : GameObject ,   data : ActionDataJs  ) : void {
		 var forceValue : float= force;

		if (data.value != 0) {
			forceValue = data.value;
		}

		 var shotDirection : Vector3= GetDirection(obj, data);
		 var pos : Vector3= GetPosition(obj, shotDirection, data);

		if (stackVertically) {
			 var rayPos : Vector3= pos;
			rayPos.y += 100;
			 var ray : Ray= new Ray(rayPos, Vector3.down);
			 var hitInfo : RaycastHit;
			if (Physics.Raycast(ray, hitInfo  )) {
				pos = hitInfo.point;
				pos.y += Mathf.Abs(shot.transform.localScale.y) * 0.5f;
			}
		}

		 var newObj : GameObject= Instantiate(shot, pos, obj.transform.rotation) as GameObject;
		newObj.transform.forward = shotDirection;
		if (newObj.GetComponent(Rigidbody) != null) {
			 var forceVec : Vector3= newObj.transform.forward * forceValue + Vector3.up * yForce;
			newObj.GetComponent(Rigidbody).AddForce(forceVec);
		}
		
//		 var creation : Creation= newObj.GetComponent(Creation);
//		if (creation == null) {
//			creation = newObj.AddComponent(Creation);
//		}
//		creation.creator = gameObject;

//		Attributes attr = gameObject.GetComponent(Attributes);
//		if (attr != null && attr.Get(Attributes.POWER) != null) {
//			Attributes newAttr = newObj.GetComponent(Attributes);
//			if (newAttr == null) {
//				newAttr = newObj.AddComponent(Attributes);
//			}
//			Attribute power = newAttr.Get(Attributes.POWER);
//			if (power == null) {
//				power = new Attribute();
//				power.value = attr.Get(Attributes.POWER).value;
//				newAttr.AddAttribute(Attributes.POWER, power);
//			}
//		}
		
		if (attach) {
			newObj.transform.parent = obj.transform;
		}

//		Team.CopyTeam(newObj, obj);
		
		if (destroySeconds >= 0) {
			StartCoroutine(DelayDestroy(newObj, destroySeconds));
		}
	}

	/// <summary>
	/// Returns the position for the shot to start at.
	/// </summary>
	virtual protected function GetPosition ( obj : GameObject ,   shotDirection : Vector3 ,   data : ActionDataJs  ) : Vector3 {
		 var pos : Vector3= shotDirection;
		pos.Normalize();
		pos *= Mathf.Abs(gameObject.transform.localScale.x) * 1.0f;
		pos += obj.transform.position;
		//		pos.y += Mathf.Abs (obj.transform.localScale.y) * 0.5f;
		pos.y += yOffset;
		pos += offset * obj.transform.forward;
		return pos;
	}
	
	/// <summary>
	/// Returns the shooting direction.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	virtual protected function GetDirection ( obj : GameObject ,   data : ActionDataJs  ) : Vector3 {
		return obj.transform.forward;
	}

	/// <summary>
	/// Destroys the object after a delay.
	/// </summary>
	/// <param name="obj">Object to destroy.</param>
	/// <param name="seconds">Seconds.</param>
	private function DelayDestroy ( obj : GameObject ,   seconds : float  ) : IEnumerator {
		yield new WaitForSeconds(seconds);
		Destroy(obj);
	}

	/// <summary>
	/// Selects a new prefab to spawn when a message is sent.
	/// </summary>
	function OnObjectSelected ( obj : GameObject  ) : void {
		shot = obj;
	}
}
