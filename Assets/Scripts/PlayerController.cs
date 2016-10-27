using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public float Tilt;
	public Boundary Boundary;
	public float AccelerationRate;
	public float AccelerationVerticalZeroAngle;

	public GameObject Shot;
	public Transform ShotSpawn;

	private float _nextFire = 0.0f;
	public float FireRate;

	void Update ()
	{
		FireShot ();
	}

	void FixedUpdate ()
	{
		HandleControls ();
	}
	
	void FireShot ()
	{
		if (IsFireShot ()) {
			_nextFire = Time.time + FireRate;
			Instantiate (Shot, ShotSpawn.position, ShotSpawn.rotation);
		}
	}

	bool IsFireShot ()
	{
		return (Input.GetKey ("space") || Input.GetMouseButton (0)) && Time.time > _nextFire;
	}

	void HandleControls ()
	{
		ConfigurePlayerVelocity ();
		ConfigurePlayerTilt ();
		EnforcePlayerBoundary ();
	}

	void ConfigurePlayerVelocity ()
	{
		float moveHorizontal;
		float moveVertical;

		if (SystemInfo.deviceType == DeviceType.Desktop) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical"); 
		} else {
			moveHorizontal = Mathf.Clamp (Input.acceleration.x * AccelerationRate, -1.0f, 1.0f);
			// The player can only move horizontally when using accerometer controls
			//moveVertical = Mathf.Clamp ((Input.acceleration.y + accelerationVerticalZeroAngle) * accelerationRate, -1.0f, 1.0f);
			moveVertical = 0.0f;
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical) * Speed;
		GetComponent<Rigidbody> ().velocity = movement;
	}
	
	void ConfigurePlayerTilt ()
	{
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.rotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, rigidBody.velocity.x * -Tilt));
	}

	void EnforcePlayerBoundary ()
	{
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.position = new Vector3 (
			Mathf.Clamp (rigidBody.position.x, Boundary.xMin, Boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rigidBody.position.z, Boundary.zMin, Boundary.zMax)
		);
	}
}
