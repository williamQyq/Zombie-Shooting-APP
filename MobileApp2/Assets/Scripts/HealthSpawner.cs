using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSpawner : MonoBehaviour
{

	//Not sure why but it seems to have trouble keeping track of both zombies and healthpacks in the same script

    public GameObject spawnee;

    private bool stopSpawning = false;
    private float spawnTime = 2.0f;
    private float spawnDelay = 4.0f;
    private float position_x;
    private float position_z;
	public int maxHealthPacks = 4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
		if (GameObject.FindGameObjectsWithTag("healthPack").Length >= maxHealthPacks)
        {
            CancelInvoke();
        }
		if (GameObject.FindGameObjectsWithTag("powerUp").Length >= maxHealthPacks)
        {
            CancelInvoke();
        }
    }
    public void SpawnObject()
    {
        position_x = Random.Range(-30, 30);
        position_z = Random.Range(-30, 30);
        Instantiate(spawnee, new Vector3(position_x, spawnee.transform.position.y, position_z), transform.rotation);
    }
}
