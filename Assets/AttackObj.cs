using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObj : MonoBehaviour
{
    //プレイヤーの打った球の処理 関連script TAma
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 1);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
