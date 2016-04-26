using UnityEngine;
using System.Collections;

/// <summary>
/// Helper functions for mouse/ray picking.
/// 
/// @author rhagan
/// </summary>
public class PickUtil : MonoBehaviour {

	/// <summary>
	/// Gets the object under screen position.
	/// </summary>
	/// <returns>The object under screen position.</returns>
	/// <param name="pos">Position.</param>
	public static GameObject GetObjectUnderScreenPos(Vector2 pos) {
		return GetObjectUnderRay(GetScreenRay(pos));
	}
	
	/// <summary>
	/// Gets the object under the mouse ray ray.
	/// </summary>
	/// <returns>The object under mouse ray.</returns>
	/// <param name="ray">Ray.</param>
	public static GameObject GetObjectUnderMouseRay(Camera camera = null) {
		return GetObjectUnderRay(GetMouseRay(camera));
	}

	/// <summary>
	/// Gets the objects under the mouse ray ray.
	/// </summary>
	/// <returns>The object under mouse ray.</returns>
	/// <param name="ray">Ray.</param>
	public static RaycastHit[] GetObjectsUnderMouseRay(Camera camera = null) {
		return GetObjectsUnderRay(GetMouseRay(camera));
	}

	/// <summary>
	/// Determines if is object hit by ray the specified ray collider.
	/// </summary>
	public static bool IsObjectHitByRay(Collider collider, float scale = 1) {
		Ray ray = GetMouseRay();
		RaycastHit hitInfo;
		if (scale != 1) {
			Bounds bounds = collider.bounds;
			bounds.extents *= scale;
			return bounds.IntersectRay(ray);
		}
		return collider.Raycast(ray, out hitInfo, float.MaxValue);
	}

	/// <summary>
	/// Determines if is object hit by ray the specified ray collider.
	/// </summary>
	public static bool IsObjectHitByRay(Ray ray, Collider collider, float scale = 1) {
		RaycastHit hitInfo;
		if (scale != 1) {
			Bounds bounds = collider.bounds;
			bounds.extents *= scale;
			return bounds.IntersectRay(ray);
		}
		return collider.Raycast(ray, out hitInfo, float.MaxValue);
	}

	/// <summary>
	/// Gets the object under a ray.
	/// </summary>
	/// <returns>The object under ray.</returns>
	/// <param name="ray">Ray.</param>
	public static RaycastHit[] GetObjectsUnderRay(Ray ray) {
		return Physics.RaycastAll(ray.origin, ray.direction);
	}
	
	/// <summary>
	/// Gets the object under a ray.
	/// </summary>
	/// <returns>The object under ray.</returns>
	/// <param name="ray">Ray.</param>
	public static GameObject GetObjectUnderRay(Ray ray) {
		RaycastHit hitInfo;
		GameObject hitObj = null;
		
		if (Physics.Raycast(ray.origin, ray.direction, out hitInfo) && hitInfo.rigidbody != null) {
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
	public static float GetMouseGroundHitPoint(out Vector3 hitPoint) {
		float hitT = -1;
		
		//		hitPoint = previousShootPoint;
		
		// try to hit plane
		if (hitT < 0) {
			hitPoint = GetXZPlaneHitPoint(out hitT);
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
	public static Ray GetMouseRay(Camera camera = null) {
		if (camera == null) {
			camera = Camera.main;
		}
		return camera == null ? new Ray() : camera.ScreenPointToRay (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
	}

	/// <summary>
	/// Gets the current ray for the screen position from the camera.
	/// </summary>
	/// <returns>
	/// The mouse ray.
	/// </returns>
	public static Ray GetScreenRay(Vector2 screenPos) {
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
	public static Vector3 GetXZPlaneHitPointForRay(out float hitT, Ray ray) {
		Plane plane = new Plane(new Vector3(0, -1, 0), Vector3.zero);
		Vector3 hitPoint = Vector3.zero;
		if (plane.Raycast(ray, out hitT)) {
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
	public static Vector3 GetXZPlaneHitPoint(out float hitT) {
		return GetXZPlaneHitPointForRay(out hitT, GetMouseRay());
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
	public static Vector3 GetXYPlaneHitPointForRay(out float hitT, Ray ray) {
		Plane plane = new Plane(new Vector3(0, 0, 1), Vector3.zero);
		Vector3 hitPoint = Vector3.zero;
		if (plane.Raycast(ray, out hitT)) {
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
	public static Vector3 GetXYPlaneHitPoint(out float hitT) {
		return GetXYPlaneHitPointForRay(out hitT, GetMouseRay());
	}	
}
