using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleManeger;
using Player;

/// <summary>
///敵関係
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float WaitTime;
    [SerializeField] int Life;
    [SerializeField] public int Power;
    [SerializeField] public int Difence;
    [SerializeField] int AttackRange;
    [SerializeField] GameObject Attack;

    float distance;
    float _time;

    bool isAttack;

    GameObject[] Player;
    Transform target;

    Animator anim;

    //敵の行動種類
    enum MoveParameta
    {
        Move,
        Attack,
        Deth,
        Wait,
    }

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        target = Player[0].transform;
        anim = GetComponent<Animator>();
        BattleMane.EnemyCount++;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, Player[0].transform.position);

        if (distance > AttackRange) Move(MoveParameta.Move);

        else if (isAttack) Move(MoveParameta.Attack);

        if (Life < 0) Move(MoveParameta.Deth);

        if (!isAttack)
        {
            _time += Time.deltaTime;
            if (_time > WaitTime) Move(MoveParameta.Wait);
        }
    }
    /// <summary>
    /// 敵の行動
    /// </summary>
    /// <param name="parameta">行動</param>
    void Move(MoveParameta parameta)
    {
        switch (parameta)
        {
            //敵の移動
            case MoveParameta.Move:
                anim.SetBool("isAttack", false);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
                transform.position += transform.forward * Speed * Time.deltaTime;
                isAttack = true;
                break;
            //敵の攻撃
            case MoveParameta.Attack:
                anim.SetBool("isAttack", true);
                Instantiate(Attack, transform.position + transform.forward * AttackRange, Quaternion.identity, gameObject.transform);
                isAttack = false;
                break;
            case MoveParameta.Wait:
                break;
            //敵倒した時の処理
            case MoveParameta.Deth:
                Destroy(gameObject);
                BattleMane.EnemyCount--;
                break;
            default:
                break;
        }
    }
}
