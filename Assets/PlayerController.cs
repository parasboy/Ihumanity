using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 6f;
	public float force = 20000f;
	public controls _controls;

	Rigidbody rb;
	PlayerShooting playerShooting;

	float xM;
	bool isGrounded;

	int lastDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerShooting = GetComponent<PlayerShooting> ();

		isGrounded = true;
		lastDirection = 1;
	}
	
	// Update is called once per frame
	void Update () {
		xM = 0;

		if (_controls == controls.ARROW) {
			if(Input.GetKey(KeyCode.RightArrow)){
				xM = 1;
				lastDirection = 1;
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				xM = -1;
				lastDirection = -1;
			}
		}
		if (_controls == controls.WASD) {
			if(Input.GetKey(KeyCode.D)){
				xM = 1;
				lastDirection = 1;
			}
			if(Input.GetKey(KeyCode.A)){
				xM = -1;
				lastDirection = -1;
			}
		}

		Vector3 movement = Vector3.right * xM * Time.deltaTime * speed;

		rb.MovePosition (rb.position + movement);

		if (_controls == controls.ARROW && isGrounded) {
			
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				Jump ();
				isGrounded = false;
			}
		}

		if (_controls == controls.WASD && isGrounded) {
			
			if(Input.GetKeyDown(KeyCode.W)){
				Jump ();
				isGrounded = false;
			}
		}

		if (_controls == controls.ARROW) {
			
			if(Input.GetKeyDown(KeyCode.RightShift)){
				playerShooting.Shoot(lastDirection);
			}
		}
		
		if (_controls == controls.WASD && isGrounded) {
			
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				playerShooting.Shoot(lastDirection);
			}
		}
	}

	void Jump (){
		rb.AddForce(transform.up * force * Time.deltaTime);
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
		}
	}
}

public enum controls {
	ARROW,
	WASD
}