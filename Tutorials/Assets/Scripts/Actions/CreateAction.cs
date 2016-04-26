using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a given object and applies optional force.
/// 
/// @author rhagan
/// </summary>
public class CreateAction : BaseAction {

	/// <summary>
	/// The object to create.
	/// </summary>
	public GameObject shot;
	
	/// <summary>
	/// The force for the shot.
	/// </summary>
	public float force = 1000;

	public float yForce = 0;
	
	/// <summary>
	/// The offset to create the object at, in direction of the object's
	/// transform.forward.
	/// </summary>
	public float offset = 0;

	/// <summary>
	/// The y offset.
	/// </summary>
	public float yOffset = 0;
	
	/// <summary>
	/// Number of seconds to destroy it. -1 for no timed destroy.
	/// </summary>
	public float destroySeconds = -1;
	
	/// <summary>
	/// If true, attaches the new object to the creator.
	/// </summary>
	public bool attach = false;

	/// <summary>
	/// The stack vertically.
	/// </summary>
	public bool stackVertically = false;
	
	/// <summary>
	/// Execute the action; actObj.
	/// </summary>
	/// <param name='actObj'>
	/// Object doing the action
	/// </param>
	override public void Run(GameObject obj, ActionData data) {
		float forceValue = force;

		if (data.value != 0) {
			forceValue = data.value;
		}

		Vector3 shotDirection = GetDirection(obj, data);
		Vector3 pos = GetPosition(obj, shotDirection, data);

		if (stackVertically) {
			Vector3 rayPos = pos;
			rayPos.y += 100;
			Ray ray = new Ray(rayPos, Vector3.down);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo)) {
				pos = hitInfo.point;
				pos.y += Mathf.Abs(shot.transform.localScale.y) * 0.5f;
			}
		}

		GameObject newObj = Instantiate(shot, pos, obj.transform.rotation) as GameObject;
		newObj.transform.forward = shotDirection;
		if (newObj.GetComponent<Rigidbody>() != null) {
			Vector3 forceVec = newObj.transform.forward * forceValue + Vector3.up * yForce;
			newObj.GetComponent<Rigidbody>().AddForce(forceVec);
		}
		
		Creation creation = newObj.GetComponent<Creation>();
		if (creation == null) {
			creation = newObj.AddComponent<Creation>();
		}
		creation.creator = gameObject;

//		Attributes attr = gameObject.GetComponent<Attributes>();
//		if (attr != null && attr.Get(Attributes.POWER) != null) {
//			Attributes newAttr = newObj.GetComponent<Attributes>();
//			if (newAttr == null) {
//				newAttr = newObj.AddComponent<Attributes>();
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

		Team.CopyTeam(newObj, obj);
		
		if (destroySeconds >= 0) {
			StartCoroutine(DelayDestroy(newObj, destroySeconds));
		}
	}

	/// <summary>
	/// Returns the position for the shot to start at.
	/// </summary>
	virtual protected Vector3 GetPosition(GameObject obj, Vector3 shotDirection, ActionData data) {
		Vector3 pos = shotDirection;
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
	virtual protected Vector3 GetDirection(GameObject obj, ActionData data) {
		return obj.transform.forward;
	}

	/// <summary>
	/// Destroys the object after a delay.
	/// </summary>
	/// <param name="obj">Object to destroy.</param>
	/// <param name="seconds">Seconds.</param>
	private IEnumerator DelayDestroy(GameObject obj, float seconds) {
		yield return new WaitForSeconds(seconds);
		Destroy(obj);
	}

	/// <summary>
	/// Selects a new prefab to spawn when a message is sent.
	/// </summary>
	public void OnObjectSelected(GameObject obj) {
		shot = obj;
	}
}
