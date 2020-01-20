using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    SingletonTest test1;
    SingletonTest test2;
    // Start is called before the first frame update
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
