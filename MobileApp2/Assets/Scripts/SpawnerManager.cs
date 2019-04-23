using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerManager : MonoBehaviour
{
    public GameObject spawnee;
    public int maxNumZombie = 10;
    private bool stopSpawning = false;
    private float spawnTime = 2.0f;
    private float spawnDelay = 4.0f;
    private float position_x;
    private float position_z;
    private float surviveTimer = 180;
   

    // Start is called before the first frame update
    void Start()
    {
        surviveTimer = Time.time+surviveTimer;
        //Debug.Log("Time ="+Time.time);

        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

    }

    // Update is called once per frame
    void Update()
    {
    	
		

	

        if (GameObject.FindGameObjectsWithTag("zombie").Length >= maxNumZombie)
        {
            CancelInvoke();
        }
        
        //Debug.Log("update time" + Time.time);
		if (Time.time >= surviveTimer && Time.time != 0)
        {
            //Debug.Log("Time:"+Time.time);
            Debug.Log("load survive menu");
            loadSurviveMenu();
        }
    }
    public void SpawnObject()
    {
        position_x = Random.Range(-30, 30);
        position_z = Random.Range(-30, 30);
        Instantiate(spawnee, new Vector3(position_x, transform.position.y, position_z), transform.rotation);
    }
    void loadSurviveMenu()
    {
        SceneManager.LoadScene("Menu2");
    }
}
