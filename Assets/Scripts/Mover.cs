using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float Speed;

	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = Vector3.forward * Speed;
	}
}
