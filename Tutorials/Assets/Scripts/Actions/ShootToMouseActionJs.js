 //import UnityEngine;
//import System.Collections;

/// <summary>
/// An action for shooting a GameObject towards where the mouse is in 3D space ( overhead : not  ).
/// </summary>
class ShootToMouseActionJs extends CreateActionJs {

	/// <summary>
	/// Returns the shooting direction.
	/// </summary>
	/// <param name='obj'>
	/// Object.
	/// </param>
	override protected function GetDirection ( obj : GameObject ,   data : ActionDataJs  ) : Vector3 {
		return PickUtilJs.GetMouseRay().direction;
	}
}