using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float attackDelay = 0.25f;

	public GameObject bullet;
	Vector3 lookDir;

	float nextAttackTime;

	public void Shoot (int dir){
		if (Time.time > nextAttackTime) {
			ShootSequence(dir);
			nextAttackTime = Time.time + attackDelay;
		}
	}

	void ShootSequence (int dir){
		if (dir == 1) {
			lookDir = transform.right;
		}
		if (dir == -1) {
			lookDir = -transform.right;
		}
		GameObject bulletGO = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
		bulletGO.GetComponent<Rigidbody> ().AddForce(lookDir * 2000);
		bulletGO.GetComponent<Bullet> ().SetOwner(gameObject.name);
	}
}
