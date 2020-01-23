using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleManeger;

/// <summary>
///敵関係
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] int Life;
    [SerializeField] int Power;
    [SerializeField] int Difence;
    [SerializeField] int AttackRange;
    float distance;

    GameObject[] Player;
    Transform target;

    Animator anim;

    //敵の行動種類
    enum MoveParameta
    {
        Move,
        Attack,
        Deth,
    }

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        target = Player[0].transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, Player[0].transform.position);

        if (distance > AttackRange) Move(MoveParameta.Move);

        else Move(MoveParameta.Attack);

        if (Life <= 0 || Input.GetKeyDown(KeyCode.Space)) Move(MoveParameta.Deth);
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
                break;
            //敵の攻撃
            case MoveParameta.Attack:
                anim.SetBool("isAttack", true);
                break;
            //敵倒した時の処理
            case MoveParameta.Deth:
                BattleMane.EnemyCount--;
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
