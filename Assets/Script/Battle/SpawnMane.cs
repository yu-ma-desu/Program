using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMane : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyPos = { };
    [SerializeField] GameObject[] PlyerPos = { };
    GameObject Enemy;
    GameObject Player;
    int EnemyNum;
    int PlyerNum = 0;
    void Awake()
    {
        EnemyNum = Random.Range(0, 3);
    }
    void Start()
    {
        Debug.Log(EnemyNum);
        Enemy = (GameObject)Resources.Load("Prefab/NPC/Enemy");
        for (int i = 0; i <= EnemyNum; i++)
        {
            Instantiate(Enemy,EnemyPos[i].transform.position,Quaternion.identity);
        }
        Player = (GameObject)Resources.Load("Prefab/Player/Player()");
        for (int i = 0; i <= PlyerNum; i++)
        {
            Instantiate(Player, PlyerPos[i].transform.position, Quaternion.identity);
        }
    }

    void Update()
    {

    }
}
