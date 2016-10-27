using UnityEngine;
using System.Collections;

public class RandomRotater : MonoBehaviour
{
	public float Tumble;

	void Start ()
	{
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
