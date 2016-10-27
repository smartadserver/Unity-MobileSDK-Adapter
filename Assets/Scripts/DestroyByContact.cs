using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject Explosion;
	public GameObject PlayerExplosion;
	public int ScoreValue;

	private GameController _gameController;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag != "Boundary") {
			DestroyBothObjects (other.gameObject);
		}
	}

	void DestroyBothObjects (GameObject other)
	{
		if (other.tag == "Player") {
			Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
			GameController ().GameOver ();
		}
		Instantiate (Explosion, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (other);
		Destroy (gameObject);

		GameController ().AddScore (ScoreValue);
	}

	GameController GameController ()
	{
		if (_gameController == null) {
			_gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
		}
		return _gameController;
	}
}
