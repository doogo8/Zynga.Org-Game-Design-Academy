using UnityEngine;
using System.Collections;

/// <summary>
/// Controller for a player in a continuous runner game (also spawns obstacles).
/// </summary>
public class PlayerRunner : MonoBehaviour {
	
	public float runSpeed = 100;
	
	public float jumpForce = 200;
	
	public GameObject obstacle;
	
	public float difficulty = 0;

	public float spawnDistance = 50;

	public bool spawnEnemies = false;

	public int difficultyIncreaseRate = 1;
	
	private Rigidbody _rigidbody;
	
	private Transform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform>();
		_rigidbody = GetComponent<Rigidbody>();
		StartCoroutine(SpawnObstacle());
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.velocity = new Vector3(runSpeed * Mathf.Pow(1.1f, difficulty), _rigidbody.velocity.y, _rigidbody.velocity.z);
		if (Input.GetKeyDown("up")) {
			Jump();
		}
	}
	
	IEnumerator SpawnObstacle() {
		yield return new WaitForSeconds(Mathf.Pow(0.98f, difficulty) * 2 + Random.Range(1, 3));
		if (spawnEnemies) {
			Instantiate(obstacle, new Vector3(_transform.localPosition.x + spawnDistance, 0, _transform.localPosition.z), 
			            Quaternion.identity);
		}
		StartCoroutine(SpawnObstacle());
		difficulty += difficultyIncreaseRate;
	}
	
	void Jump() {
		if (Mathf.Abs(_rigidbody.velocity.y) < 0.01f) {
			_rigidbody.AddForce(0, jumpForce, 0);
		}
	}
}