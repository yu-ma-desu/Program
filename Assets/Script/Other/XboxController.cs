using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Xboxコントローラー確認用
/// </summary>
namespace Other
{
    public class XboxController : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                Debug.Log("Aボタン");
            }
            if (Input.GetKeyDown("joystick button 1"))
            {
                Debug.Log("Bボタン");
            }
            if (Input.GetKeyDown("joystick button 2"))
            {
                Debug.Log("Xボタン");
            }
            if (Input.GetKeyDown("joystick button 3"))
            {
                Debug.Log("Yボタン");
            }
            if (Input.GetKeyDown("joystick button 4"))
            {
                Debug.Log("LBボタン");
            }
            if (Input.GetKeyDown("joystick button 5"))
            {
                Debug.Log("RBボタン");
            }
            if (Input.GetKeyDown("joystick button 6"))
            {
                Debug.Log("Backボタン");
            }
            if (Input.GetKeyDown("joystick button 7"))
            {
                Debug.Log("Startボタン");
            }
            if (Input.GetKeyDown("joystick button 8"))
            {
                Debug.Log("Lスティック");
            }
            if (Input.GetKeyDown("joystick button 9"))
            {
                Debug.Log("Rスティック");
            }
            //L Stick
            float lsh = Input.GetAxis("LStick_Horizontal");
            float lsv = Input.GetAxis("LStick_Vertical");
            if ((lsh != 0) || (lsv != 0))
            {
                Debug.Log("L stick:x" + lsh + ",y" + lsv);
            }
            //R Stick
            float rsh = Input.GetAxis("RStick_Horizontal");
            float rsv = Input.GetAxis("RStick_Vertical");
            if ((rsh != 0) || (rsv != 0))
            {
                Debug.Log("R stick:x" + rsh + ",y" + rsv);
            }
            //十字キー
            float dph = Input.GetAxis("Cross_Horizontal");
            float dpv = Input.GetAxis("Cross_Vertical");
            if ((dph != 0) || (dpv != 0))
            {
                Debug.Log("Cross:x" + dph + ",y" + dpv);
            }
            //LRトリガー
            float tri = Input.GetAxis("LR_Trigger");
            if (tri > 0)
            {
                Debug.Log("L trigger:" + tri);
            }
            else if (tri < 0)
            {
                Debug.Log("R trigger:" + tri);
            }
        }
    }
}

