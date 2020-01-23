using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Other
{
    /// <summary>
    /// シングルトンのテスト、ゲームには関らない
    /// </summary>
    public class Sample : MonoBehaviour
    {
        SingletonTest test1;
        SingletonTest test2;
        void Start()
        {
            test1 = SingletonTest.Instance;
            test2 = SingletonTest.Instance;

            if (test1 == test2)
            {
                Debug.Log("等しい");
            }
            Debug.Log(test2.TestNum);
            test1.SetNum(100);
            Debug.Log(test2.TestNum);
        }
    }
}

