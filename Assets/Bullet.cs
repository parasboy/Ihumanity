using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	string owner;

	public void SetOwner (string ownerName){
		owner = ownerName;
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("Player") && other.gameObject.name != owner) {
			Destroy (other.gameObject);
		}
	}
}
