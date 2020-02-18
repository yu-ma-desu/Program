using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _destroy;
    GameObject Parent;
    EnemyMove enemy;
    Boss boss;
    int Damege;
    private void Start()
    {
        Parent = transform.root.gameObject;
        if (PlayerPrefs.GetInt("Battle") == 1)
        {
            enemy = Parent.GetComponent<EnemyMove>(); 
            Damege = enemy.Power - PlayerStatus.PlayerDifece;
        }
        else if (PlayerPrefs.GetInt("Battle") == 2)
        {
            boss = Parent.GetComponent<Boss>();
            Damege = boss.Power - PlayerStatus.PlayerDifece;
        }
        Invoke("_Destory", _destroy);
    }
    void _Destory()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Damege <= 0)
            {
                Damege = 1;
            }
            PlayerStatus.PlayerLife -= Damege;
        }
    }
}
