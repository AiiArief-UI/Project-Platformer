using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public float destroyTime;
	void Start()
	{
		StartCoroutine("DestroyMe");
	}

	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds(destroyTime);
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (gameObject.CompareTag ("Bullet") && other.gameObject.CompareTag ("Player")) {
			return;
		} else if (gameObject.CompareTag ("EnemyBullet") && other.gameObject.CompareTag ("enemy")) {
			return;
		} else {
			Destroy (gameObject);
			Debug.Log ("ayy");
		}
	}
}
