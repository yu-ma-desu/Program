using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class EnemyAttack : MonoBehaviour
{
    GameObject Parent;
    EnemyMove enemy;
    private void Start()
    {
        Parent = transform.root.gameObject;
        enemy = Parent.GetComponent<EnemyMove>();
        Invoke("_Destory", 2);
    }
    void _Destory()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStatus.PlayerLife -= enemy.Power;
        }
    }
}
