using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float chaseSpeed = 4f;
    public float angularSpeed = 300;

    private NavMeshAgent nm;
    private GameObject player;
    private Animator animator;
    private bool isAware = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        nm = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            nm.destination = player.transform.position;
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
}
