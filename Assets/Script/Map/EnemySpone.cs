using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpone : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject[] EnemyPoint = { };
    float SponeTime = 0.0f;
    int random;
    void Update()
    {
        SponeTime += Time.deltaTime;
        if (SponeTime > 3)
        {
            random = Random.Range(0, 3);
            if (MapMane.EnemyCount < 3)
            {
                Instantiate(enemy,EnemyPoint[random].transform.position,Quaternion.identity);
                MapMane.EnemyCount++;
            }
            SponeTime = 0;
        }
    }
}
