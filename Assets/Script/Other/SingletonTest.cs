using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Other
{
    /// <summary>
    /// シングルトンのテスト、ゲームには関らない
    /// </summary>
    public class SingletonTest
    {
        private static SingletonTest test;
        GameObject Test;
        private SingletonTest()
        {
            Test = (GameObject)Resources.Load("Prefab/Test");
        }
        public static SingletonTest Instance
        {
            get
            {
                if (test == null)
                {
                    test = new SingletonTest();
                }
                return test;
            }
        }
        public int TestNum = 10;
        /// <param name="num">テスト用数値</param>
        public void SetNum(int num)
        {
            TestNum = num;
        }
    }
}

