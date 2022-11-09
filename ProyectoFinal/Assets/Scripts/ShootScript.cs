using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;
    [SerializeField] AudioSource shoot;


    void Start()
    {      
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            shoot.Play();                                  
        }
    }
}
