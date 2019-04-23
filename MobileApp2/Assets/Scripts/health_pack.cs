using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pack : MonoBehaviour
{
	public Transform player;
	public float rotationSpeed = 15;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

	void OnTriggerEnter(Collider other){
		if(other.gameObject == player.gameObject){
			player.gameObject.GetComponent<PlayerScript>().TakeDamage(-75);
			Destroy(gameObject);
		}
	}
}
