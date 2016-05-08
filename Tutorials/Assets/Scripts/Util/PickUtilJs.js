 //import UnityEngine;
//import System.Collections;

/// <summary>
/// Helper functions for mouse/ray picking.
/// 
/// @author rhagan
/// </summary>
class PickUtilJs {

	/// <summary>
	/// Gets the object under screen position.
	/// </summary>
	/// <returns>The object under screen position.</returns>
	/// <param name="pos">Position.</param>
	static function GetObjectUnderScreenPos ( pos : Vector2  ) : GameObject {
		return GetObjectUnderRay(GetScreenRay(pos));
	}
	
	/// <summary>
	/// Gets the object under the mouse ray ray.
	/// </summary>
	/// <returns>The object under mouse ray.</returns>
	/// <param name="ray">Ray.</param>
	static function GetObjectUnderMouseRay( camera : Camera) {
		return GetObjectUnderRay(GetMouseRay(camera));
	}

	static function GetObjectUnderMouseRay() {
		return GetObjectUnderRay(GetMouseRay(null));
	}

	/// <summary>
	/// Gets the objects under the mouse ray ray.
	/// </summary>
	/// <returns>The object under mouse ray.</returns>
	/// <param name="ray">Ray.</param>
	static function GetObjectsUnderMouseRay( camera : Camera) {
		return GetObjectsUnderRay(GetMouseRay(camera));
	}

	static function GetObjectsUnderMouseRay() {
		return GetObjectsUnderRay(GetMouseRay(null));
	}

	/// <summary>
	/// Determines if is object hit by ray the specified ray collider.
	/// </summary>
	static function IsObjectHitByRay(collider:Collider, scale:float) {
		 var ray : Ray= GetMouseRay();
		 var hitInfo : RaycastHit;
		if (scale != 1) {
			 var bounds : Bounds= collider.bounds;
			bounds.extents *= scale;
			return bounds.IntersectRay(ray);
		}
		return collider.Raycast(ray,  hitInfo,  float.MaxValue);
	}

	static function IsObjectHitByRay(collider:Collider) {
		return IsObjectHitByRay(collider, 1);
	}

	/// <summary>
	/// Determines if is object hit by ray the specified ray collider.
	/// </summary>
	static function IsObjectHitByRay(ray:Ray, collider:Collider, scale:float) {
		 var hitInfo : RaycastHit;
		if (scale != 1) {
			 var bounds : Bounds= collider.bounds;
			bounds.extents *= scale;
			return bounds.IntersectRay(ray);
		}
		return collider.Raycast(ray, hitInfo,  float.MaxValue);
	}

	/// <summary>
	/// Gets the object under a ray.
	/// </summary>
	/// <returns>The object under ray.</returns>
	/// <param name="ray">Ray.</param>
	static function GetObjectsUnderRay ( ray : Ray  ) : RaycastHit[] {
		return Physics.RaycastAll(ray.origin, ray.direction);
	}
	
	/// <summary>
	/// Gets the object under a ray.
	/// </summary>
	/// <returns>The object under ray.</returns>
	/// <param name="ray">Ray.</param>
	static function GetObjectUnderRay ( ray : Ray  ) : GameObject {
		 var hitInfo : RaycastHit;
		 var hitObj : GameObject= null;
		
		if (Physics.Raycast(ray.origin, ray.direction,  hitInfo  ) && hitInfo.rigidbody != null) {
			hitObj = hitInfo.collider.gameObject;
		}
		 return hitObj;
	}
	
	/// <summary>
	/// Gets the mouse plane hit point.
	/// </summary>
	/// <returns>
	/// The mouse plane hit point.
	/// </returns>
	/// <param name='actObj'>
	/// Act object.
	/// </param>
	/// <param name='hitPoint'>
	/// Hit point.
	/// </param>
	static function GetMouseGroundHitPoint ( hitPoint : Vector3  ) : float {
		 var hitT : float= -1;
		
		//		hitPoint = previousShootPoint;
		
		// try to hit plane
		if (hitT < 0) {
			hitPoint = GetXZPlaneHitPoint( hitT );
			 return hitT;
		}
		
		hitPoint = new Vector3();
		return -999999;
	}
	
	/// <summary>
	/// Gets the current mouse ray from the camera.
	/// </summary>
	/// <returns>
	/// The mouse ray.
	/// </returns>
	static function GetMouseRay( camera : Camera) {
		if (camera == null) {
			camera = Camera.main;
		}
		return camera.ScreenPointToRay (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
	}

	static function GetMouseRay() {
		return GetMouseRay(null);
	}


	/// <summary>
	/// Gets the current ray for the screen position from the camera.
	/// </summary>
	/// <returns>
	/// The mouse ray.
	/// </returns>
	static function GetScreenRay ( screenPos : Vector2  ) : Ray {
		return Camera.main.ScreenPointToRay (new Vector3(screenPos.x, screenPos.y, 0));
	}

	/// <summary>
	/// Gets the plane hit point for a ray from camera.
	/// </summary>
	/// <returns>
	/// The plane hit point.
	/// </returns>
	/// <param name='hitT'>
	/// Hit t.
	/// </param>
	static function GetXZPlaneHitPointForRay ( hitT : float ,   ray : Ray  ) : Vector3 {
		 var plane : Plane= new Plane(new Vector3(0, -1, 0), Vector3.zero);
		 var hitPoint : Vector3= Vector3.zero;
		if (plane.Raycast(ray,  hitT  )) {
			hitPoint = ray.GetPoint(hitT);
		}
		 return hitPoint;
	}

	/// <summary>
	/// Gets the plane hit point for current mouse ray from camera.
	/// </summary>
	/// <returns>
	/// The plane hit point.
	/// </returns>
	/// <param name='hitT'>
	/// Hit t.
	/// </param>
	static function GetXZPlaneHitPoint ( hitT   : float  ) : Vector3 {
		return GetXZPlaneHitPointForRay(hitT, GetMouseRay());
	}	

	/// <summary>
	/// Gets the plane hit point for a ray from camera.
	/// </summary>
	/// <returns>
	/// The plane hit point.
	/// </returns>
	/// <param name='hitT'>
	/// Hit t.
	/// </param>
	static function GetXYPlaneHitPointForRay ( hitT  : float ,   ray : Ray  ) : Vector3 {
		 var plane : Plane= new Plane(new Vector3(0, 0, 1), Vector3.zero);
		 var hitPoint : Vector3= Vector3.zero;
		if (plane.Raycast(ray,  hitT  )) {
			hitPoint = ray.GetPoint(hitT);
		}
		 return hitPoint;
	}

	/// <summary>
	/// Gets the plane hit point for current mouse ray from camera.
	/// </summary>
	/// <returns>
	/// The plane hit point.
	/// </returns>
	/// <param name='hitT'>
	/// Hit t.
	/// </param>
	static function GetXYPlaneHitPoint ( hitT : float  ) : Vector3 {
		return GetXYPlaneHitPointForRay(hitT, GetMouseRay());
	}	
}
