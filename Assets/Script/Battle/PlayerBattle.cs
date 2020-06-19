using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleManeger;

/// <summary>
/// プレイヤーバトル中行動
/// </summary>
public class PlayerBattle : MonoBehaviour
{
    float Speed = 5f;
    [SerializeField] GameObject Attack;
    [SerializeField] GameObject Magik;
    int _a = 0;
    Animator anim;
    bool isMotion;
    enum num
    {
        first,
        second,
        third,
        final
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!isMotion)
        {
            Debug.Log("いま");
        }
        float lsh = Input.GetAxis("LStick_Horizontal") * Speed * -1;
        float lsv = Input.GetAxis("LStick_Vertical") * Speed * -1;
        transform.position += transform.forward * Time.deltaTime * lsv;
        transform.position += transform.right * Time.deltaTime * lsh;

        float rsh = Input.GetAxis("RStick_Horizontal");
        transform.Rotate(0, rsh * 2, 0);

        if (Input.GetKeyDown("joystick button 2"))
        {
            anim.SetBool("isFirst", true);
            Instantiate(Attack, transform.position + transform.forward * -1, Quaternion.identity, this.transform);
        }
        if (Input.GetKeyDown("joystick button 3") && BattleMane.Keiken > 9)
        {
            Instantiate(Magik, transform.position + transform.forward * -1, Quaternion.identity);
        }
    }
    /// <summary>
    /// 連続攻撃
    /// </summary>
    /// <param name="Num"> 攻撃回数</param>
    void Miss(num Num)
    {
        switch (Num)
        {
            case num.first:
                anim.SetBool("isFirst", true);
                _a = 1;
                isMotion = false;
                if (Input.GetKeyDown("joystick button 2"))
                {
                    isMotion = true;
                }
                break;
            case num.second:
                if (!isMotion)
                {
                    anim.SetBool("isFirst", false);
                    _a = 0;
                }
                isMotion = false;
                if (Input.GetKeyDown("joystick button 2"))
                {
                    isMotion = true;
                }
                break;
            case num.third:
                if (!isMotion)
                {
                    anim.SetBool("isFirst", false);
                    _a = 0;
                }
                isMotion = false;
                break;
            case num.final:
                _a = 0;
                anim.SetBool("isFirst", false);
                break;
            default:
                break;
        }
    }
}
