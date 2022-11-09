using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] Vector3 randomPosition;

    private float counter = 1;
    private float counterTwo = 1;


    void Start()
    {
        for (int enemy = 0; enemy < 10; enemy++)
        {
            Instantiate(prefabEnemy, randomPosition, Quaternion.identity);
        }
    }

    
    void Update()
    {
        
    }

    void EnemyAmount()
    {

        randomPosition.x = Random.Range(-1, 10);
        randomPosition.y = Random.Range(4, 4);
        randomPosition.z = Random.Range(9, 17);
        counter += counterTwo;       
        if (counter < 10)
        {
            Instantiate(prefabEnemy, randomPosition, Quaternion.identity);
        }
        else
        {

        }
    }
}
