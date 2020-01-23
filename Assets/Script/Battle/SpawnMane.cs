using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleManeger;

/// <summary>
/// 敵味方の生成
/// </summary>
public class SpawnMane : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyPos = { };
    [SerializeField] GameObject[] PlyerPos = { };
    GameObject Enemy;
    GameObject Player;
    int EnemyNum;
    int PlyerNum;
    void Awake()
    {
        EnemyNum = Random.Range(0, 3);
    }
    void Start()
    {
        Player = (GameObject)Resources.Load("Prefab/Player/Player()");
        for (int i = 0; i <= PlyerNum; i++)
        {
            Instantiate(Player, PlyerPos[i].transform.position, Quaternion.identity);
        }
        Enemy = (GameObject)Resources.Load("Prefab/NPC/Enemy");
        for (int i = 0; i <= EnemyNum; i++)
        {
            Instantiate(Enemy,EnemyPos[i].transform.position,Quaternion.identity);
            BattleMane.EnemyCount++;
        }
    }
}
