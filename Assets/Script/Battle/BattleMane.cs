using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleManeger
{
    /// <summary>
    /// バトルの勝利条件
    /// </summary>
    public class BattleMane : MonoBehaviour
    {
        static public int EnemyCount { get; set; } = 0;
        static public int Keiken { get; set; } = 0;
        [SerializeField] GameObject WinImage;
        [SerializeField] GameObject LoseImege;
        [SerializeField] Text text;


        bool isGame = false;
        enum Win
        {
            Player,
            Enemy,
        }
        private void Update()
        {
            if (EnemyCount == 0 && isGame == false)
            {
                GameSet(Win.Player);
            }
            if (PlayerStatus.PlayerLife <= 0 && isGame == false)
            {
                GameSet(Win.Enemy);
            }
            if (isGame && Input.GetKeyDown("joystick button 2"))
            {
                SceneManager.LoadScene(0);
            }
        }
        void GameSet(Win win)
        {
            MapMane.EnemyCount -= 1;
            switch (win)
            {
                case Win.Player:
                    Debug.Log("プレイヤーの勝ち");
                    WinResult();
                    break;
                case Win.Enemy:
                    Debug.Log("敵の勝ち");
                    LoseResult();
                    break;
                default:
                    break;
            }
            isGame = true;
            EnemyCount = 0;
        }
        void WinResult()
        {
            WinImage.SetActive(true);
            text.text = Keiken.ToString();
        }
        void LoseResult()
        {
            LoseImege.SetActive(true);

            PlayerPrefs.DeleteKey("X");
            PlayerPrefs.DeleteKey("Y");
            PlayerPrefs.DeleteKey("Z");

            PlayerStatus.PlayerLife = 30;
        }
    }
}