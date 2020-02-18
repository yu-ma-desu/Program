using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleManeger;
using Player;

public class Boss : MonoBehaviour
{
    [SerializeField] int Life;
    [SerializeField] public int Power;
    [SerializeField] public int Difence;
    [SerializeField] GameObject JumpAttack;
    [SerializeField] GameObject Takkuru;
    [SerializeField] int keiken;

    float distance;
    float _time;
    float _Kougeki;
    float _timetime;

    GameObject[] Player;
    Transform target;

    Animator anim;

    bool isKougeki;
    bool isAttack;
    enum MoveParameta
    {
        Instance,
        Attack,
        Deth,
        Wait,
        KougekiMae
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        target = Player[0].transform;
        anim = GetComponent<Animator>();
        BattleMane.EnemyCount++;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Player[0].transform.position);
        if (distance > 3 && !isKougeki)
        {
            BossMove(MoveParameta.KougekiMae);
        }
        if(distance <= 3 && !isAttack)
        {
            BossMove(MoveParameta.Attack);
        }
        if (isKougeki)
        {
            _time += Time.deltaTime;
            transform.position += transform.forward * 10 * Time.deltaTime;
            if (distance < 1 || _time > 1)
            {
                BossMove(MoveParameta.Wait);
                isKougeki = false;
                _time = 0;
            }
        }
        if (isAttack)
        {
            _timetime += Time.deltaTime;
            if(_timetime > 3)
            {
                isAttack = false;
                _timetime = 0;
            }
        }
        if (Life <= 0) BossMove(MoveParameta.Deth);
    }

    void BossMove(MoveParameta parameta)
    {
        switch (parameta)
        {
            case MoveParameta.Attack:
                anim.SetBool("isAttack", true);
                break;
            case MoveParameta.Deth:
                Destroy(gameObject);
                BattleMane.EnemyCount--;
                BattleMane.Keiken += keiken;
                break;
            case MoveParameta.Wait:
                anim.SetBool("isAttack", false);
                isAttack = true;
                break;
            case MoveParameta.KougekiMae:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
                _Kougeki += Time.deltaTime;
                if (_Kougeki > 3)
                {
                    isKougeki = true;
                    Instantiate(Takkuru, transform.position + transform.forward * 1, Quaternion.identity, this.transform);
                    _Kougeki = 0;
                }
                break;
            case MoveParameta.Instance:
                Instantiate(JumpAttack,this.transform);
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
        }
    }
}
