using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    
    [SerializeField] public Transform posPlayer;    
    [SerializeField] public float speed = 2f;
    [SerializeField] GameObject player;          
    [SerializeField] NavMeshAgent agent;
    
    
    private float _health = 500;

    void Start()
    {
        var playerScript = FindObjectOfType<PlayerMovementCamera>();

        posPlayer = playerScript.transform;
        player = playerScript.gameObject;

        Debug.Log(_health);
        agent.GetComponent<NavMeshAgent>();
    }   
    void Update()
    {        
        CheckDistance();
        SetDestination();
        LookAtQuaternion();
    }
    void LookAtPlayer()
    {
        transform.LookAt(posPlayer);
    }
    void Distance()
    {
        float dist = Vector3.Distance(posPlayer.position, transform.position);
        if (dist < 2)
        {
            _health -= 1;
            Debug.Log(_health);
            if (_health == 0)
            {
                Destroy(player);
                Debug.Log("You died, the zombies ate you");
            }
        }
    }
    void CheckDistance()
    {
        float dist = Vector3.Distance(posPlayer.position, transform.position);
        if (dist < 10)
        {
            Debug.Log("10 metros distancia");
            Distance();
            agent.speed = 5f;
            
        }
        
    }
    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, posPlayer.position, speed * Time.deltaTime);
    }
    void SetDestination()
    {
        agent.SetDestination(posPlayer.position);
    }
    void LookAtQuaternion()
    {
        Quaternion rot = Quaternion.LookRotation(posPlayer.position - transform.position);
        transform.rotation = rot;
    }
}
