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
    [SerializeField] GameObject Boss;
    [SerializeField] Cinemachine.CinemachineTargetGroup targetGroup;
    [SerializeField] GameObject BattleMane;
    GameObject Enemy;
    GameObject enemy;
    GameObject Player;
    int EnemyNum;
    int PlyerNum;

    void Awake()
    {
        EnemyNum = Random.Range(0, 3);
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("Battle") == 1)
        {
            Cinemachine.CinemachineTargetGroup.Target[] targets = new Cinemachine.CinemachineTargetGroup.Target[EnemyNum + 1 + PlyerNum + 1];

            Player = (GameObject)Resources.Load("Prefab/Player/Player()");
            for (int i = 0; i <= PlyerNum; i++)
            {
                targets[0].target = Instantiate(Player, PlyerPos[i].transform.position, Quaternion.identity).transform;
            }
            targets[0].radius = 1.0f;
            targets[0].weight = 2.0f;
            Enemy = (GameObject)Resources.Load("Prefab/NPC/Enemy");
            for (int i = 0; i < EnemyNum + 1; i++)
            {
                enemy = Instantiate(Enemy, EnemyPos[i].transform.position, Quaternion.identity);
                targets[i + PlyerNum + 1].target = enemy.transform;
                targets[i + PlyerNum + 1].radius = 1.0f;
                targets[i + PlyerNum + 1].weight = 1.0f;
            }

            targetGroup.m_Targets = targets;
        }

        if (PlayerPrefs.GetInt("Battle") == 2)
        {
            Cinemachine.CinemachineTargetGroup.Target[] targets = new Cinemachine.CinemachineTargetGroup.Target[2];

            Player = (GameObject)Resources.Load("Prefab/Player/Player()");
            for (int i = 0; i <= PlyerNum; i++)
            {
                targets[0].target = Instantiate(Player, PlyerPos[i].transform.position, Quaternion.identity).transform;
            }
            targets[0].radius = 1.0f;
            targets[0].weight = 2.0f;

            enemy = Instantiate(Boss, EnemyPos[0].transform.position, Quaternion.identity);
            targets[1].target = enemy.transform;
            targets[1].radius = 1.0f;
            targets[1].weight = 1.0f;
            targetGroup.m_Targets = targets;
        }

        BattleMane.SetActive(true);
    }
}
