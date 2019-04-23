﻿using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	public int health = 6;
	public float zombieFireRate = 15f;
    public float timeToNextHit = 0f;
    public float deathTimer = 3;
    public float timeStamp;
	public float noiseTime = 2;

    private NavMeshAgent nm;
    private GameObject player;
    private Animator animator;
    private bool isAware = false;
    private bool isDie = false;
    private AudioSource zombieNoise;
    private float noiseTimeStamp;
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        nm = GetComponent<NavMeshAgent>();
        zombieNoise = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if(isDie){
    		if(Time.time >= timeStamp){
				Destroy(gameObject);
			}
    	}

        if (player != null && !isDie)
        {
            nm.destination = player.transform.position;
            if(Vector3.Distance(player.transform.position, transform.position) < 2f && Time.time >= timeToNextHit)
            {
                timeToNextHit = Time.time + 1f / zombieFireRate;             
                if(Time.time >= noiseTimeStamp){
					zombieNoise.Play();
					noiseTimeStamp = Time.time + noiseTime;

				}

                player.GetComponent<PlayerScript>().TakeDamage(1);
            }

            if (isAware)
            {
                SearchForPlayer();
                animator.SetBool("Aware", true);

            }
            else
            {
                SearchForPlayer();
                animator.SetBool("Aware", false);

            }
            if (health <= 0)
            {
                die();
                //Destroy(gameObject);
            }
        } else
        {
            nm.destination = nm.transform.position;
        }
    }
	public void die()
    {
        isDie = true;
        animator.SetTrigger("Die");
		
		timeStamp = Time.time + deathTimer;	
        
    }
    public void onAware()
    {
        isAware = true;
    }
    public void onIdle()
    {
        isAware = false;
    }

    public void SearchForPlayer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3f)
        {
            onAware();
        }
        else
        {
            onIdle();
        }
    }

    public void get_shot( int gunDamage){
    	health--;
		Debug.Log("Zombie health " + health);
    }

}
