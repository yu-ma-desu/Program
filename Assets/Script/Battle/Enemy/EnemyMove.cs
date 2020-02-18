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
    [SerializeField] int Keiken;

    int WaitNum;

    float distance;
    float _time;

    bool isWait;
    bool isAttack = true;

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

        if (distance > AttackRange && !isWait) Move(MoveParameta.Move);

        else if (isAttack) Move(MoveParameta.Attack);

        if (Life < 0) Move(MoveParameta.Deth);

        if (isWait)
        {
            _time += Time.deltaTime;
            if (_time >= WaitNum)
            {
                isAttack = true;
                isWait = false;
                anim.SetBool("isAttack", false);
                _time = 0;
            }
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
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
                transform.position += transform.forward * Speed * Time.deltaTime;
                break;
            //敵の攻撃
            case MoveParameta.Attack:
                anim.SetBool("isAttack", true);
                Instantiate(Attack, transform.position + transform.forward * AttackRange, Quaternion.identity, gameObject.transform);
                isAttack = false;
                Move(MoveParameta.Wait);
                break;
            case MoveParameta.Wait:
                WaitNum = Random.Range(3, 10);
                isWait = true;
                break;
            //敵倒した時の処理
            case MoveParameta.Deth:
                Destroy(gameObject);
                BattleMane.EnemyCount--;
                BattleMane.Keiken += Keiken;
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            Life -= PlayerStatus.PlayerPower - Difence;
            Debug.Log(Life);
        }
    }
}
