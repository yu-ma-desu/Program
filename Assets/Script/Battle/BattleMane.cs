using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.SceneManagement;

namespace BattleManeger
{
    /// <summary>
    /// バトルの勝利条件
    /// </summary>
    public class BattleMane : MonoBehaviour
    {
        static public int EnemyCount { get; set; } = 0;
        [SerializeField] GameObject WinImage;
        [SerializeField] GameObject LoseImege;


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
            if (isGame && Input.GetKeyDown(KeyCode.A))
            {
                SceneManager.LoadScene(0);
            }
        }
        void GameSet(Win win)
        {
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
        }
        void WinResult()
        {
            WinImage.SetActive(true);
        }
        void LoseResult()
        {
            LoseImege.SetActive(true);
        }
    }
}