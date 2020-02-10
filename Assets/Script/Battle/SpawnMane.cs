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
    [SerializeField] Cinemachine.CinemachineTargetGroup targetGroup;
    GameObject Enemy;
    GameObject enemy;
    GameObject Player;
    int EnemyNum;
    int PlyerNum;
    public static Vector3[] a = { };
    void Awake()
    {
        EnemyNum = Random.Range(0, 3);
    }
    void Start()
    {
        Cinemachine.CinemachineTargetGroup.Target[] targets = new Cinemachine.CinemachineTargetGroup.Target[EnemyNum + 1];

        Player = (GameObject)Resources.Load("Prefab/Player/Player()");
        for (int i = 0; i <= PlyerNum; i++)
        {
            targets[0].target = Instantiate(Player, PlyerPos[i].transform.position, Quaternion.identity).transform;
        }
        targets[0].radius = 1.0f;
        targets[0].weight = 2.0f;

        Enemy = (GameObject)Resources.Load("Prefab/NPC/Enemy");
        for (int i = 0; i < EnemyNum; i++)
        {
           enemy = Instantiate(Enemy, EnemyPos[i].transform.position, Quaternion.identity);
           targets[i+1].target = enemy.transform;
            targets[i+1].radius = 1.0f;
            targets[i+1].weight = 1.0f;
        }
        targetGroup.m_Targets = targets;
    }
}
