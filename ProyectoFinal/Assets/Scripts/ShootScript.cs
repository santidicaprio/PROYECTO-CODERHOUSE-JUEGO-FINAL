using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;
    [SerializeField] AudioSource shoot;
    [SerializeField] AudioClip shootAudio;
    [SerializeField] ParticleSystem shootEffect;
    [SerializeField] Transform effectPosition;
    [SerializeField] GameObject bloodEffect;
    [SerializeField] float range = 1000f;   
    [SerializeField] ParticleSystem casingEffect;
    [SerializeField] ParticleSystem muzzleFlash;


    void Start()
    {     
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {


            Shoot();
            ShootRayCast();
            EffectShoot();
            shoot.PlayOneShot(shootAudio);






        }
        
    }

    void EffectShoot()
    {
       var effectReference = Instantiate(shootEffect, effectPosition.position, spawnPoint.rotation);
       Destroy(effectReference, 5f);

        

    }

    void Shoot()
    {
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    }
        

    void ShootRayCast()
    {
        
        muzzleFlash.Play();
        casingEffect.Play();
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemies")
            {
                
                GameObject go = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));               
                Destroy(go, 0.4f);
            }
        }

    }



}
