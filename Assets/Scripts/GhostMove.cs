using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 1;
    public Animator animator;
    public GameObject target;
    
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        target = FindNearestOrb();
        Vector3 destination = target.transform.position;
        agent.SetDestination(destination);
        agent.speed = speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Orb")
        {
            other.gameObject.GetComponent<OrbManager>().TakeDamage();
            Kill();
        }
    }

    public void Kill()
    {
        agent.enabled = false;
        animator.SetTrigger("Death");
        gameManager.ghostsActive--;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public GameObject FindNearestOrb()
    {
        GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
        GameObject nearest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject orb in orbs)
        {
            float distance = Vector3.Distance(currentPosition, orb.transform.position);
            if (distance < minDist)
            {
                nearest = orb;
                minDist = distance;
            }
        }
        return nearest;
    }
}
