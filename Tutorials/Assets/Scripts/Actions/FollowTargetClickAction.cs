using UnityEngine;
using System.Collections;

/// <summary>
/// Follows the clicked target.
/// 
/// @author rhagan
/// </summary>
public class FollowTargetClickAction : BaseAction {

	override public void Run(GameObject obj, ActionData data) {
		Follow follow = GetComponent<Follow>();
		if (follow != null) {
			GameObject intersectedObj = PickUtil.GetObjectUnderMouseRay();
			if (intersectedObj != null) {
				follow.target = intersectedObj;
			}
		}
	}
}
