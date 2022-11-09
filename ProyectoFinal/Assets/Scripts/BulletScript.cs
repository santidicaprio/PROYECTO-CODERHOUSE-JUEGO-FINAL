using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject kill;
    [SerializeField] GameObject bulllllet;
    [SerializeField] AudioSource killSound;
    [SerializeField] AudioClip finishSound;


    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position +=  transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 5f);
        


    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            killSound.PlayOneShot(finishSound, 0.8f);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

    }   
}
