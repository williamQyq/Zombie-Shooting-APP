using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
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
			PowerUpGun();
			Destroy(gameObject);
		}
	}

	public void PowerUpGun(){
		player.GetComponent<PlayerScript>().machineGunActive = true;
		Debug.Log(player.GetComponent<PlayerScript>().machineGunActive);
		player.GetComponent<PlayerScript>().SwitchWeapons();
	}
}
