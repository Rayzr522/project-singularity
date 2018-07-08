using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public float speed = 5f;
	public float destroyDelay = 3f;

	public float direction = 1.0f;

	void Start() {
		
		Destroy(gameObject, destroyDelay);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x += speed * direction * Time.deltaTime;
		transform.position = position;
	}
}
