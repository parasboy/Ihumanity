using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player1;
	public Transform player2;
	
	private const float DISTANCE_MARGIN = 1.0f;
	
	private Vector3 middlePoint;
	private float distanceFromMiddlePoint;
	private float distanceBetweenPlayers;
	private float cameraDistance;
	private float aspectRatio;
	private float fov;
	private float tanFov;

	private Camera mainCam;
	
	void Start() {
		mainCam = Camera.main;
		aspectRatio = (Screen.width) / (Screen.height);
		tanFov = Mathf.Tan(Mathf.Deg2Rad * mainCam.fieldOfView / 2.0f);
	}
	
	void Update () {

		if (player1 != null && player2 != null) {
			
			// Position the camera in the center.
			Vector3 newCameraPos = mainCam.transform.position;
			newCameraPos.x = middlePoint.x;
			mainCam.transform.position = newCameraPos;
			
			// Find the middle point between players.
			Vector3 vectorBetweenPlayers = player2.position - player1.position;
			middlePoint = player1.position + 0.5f * vectorBetweenPlayers;
			
			// Calculate the new distance.
			distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
			cameraDistance = (distanceBetweenPlayers / 0.75f / aspectRatio) / tanFov;
			
			// Set camera to new position.
			Vector3 dir = (mainCam.transform.position - middlePoint).normalized;
			mainCam.transform.position = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);
		}
	}
}
