using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
namespace BattleManeger
{
    /// <summary>
    /// バトルの勝利条件
    /// </summary>
    public class BattleMane : MonoBehaviour
    {
        static public int EnemyCount { get; set; } = 0;

        enum Win
        {
            Player,
            Enemy,
        }
        private void Update()
        {
            if (EnemyCount == 0)
            {
                GameSet(Win.Player);
            }
            if (PlayerStatus.PlayerLife <= 0)
            {
                GameSet(Win.Enemy);
            }
        }
        void GameSet(Win win)
        {
            switch (win)
            {
                case Win.Player:
                    Debug.Log("プレイヤーの勝ち");
                    break;
                case Win.Enemy:
                    Debug.Log("敵の勝ち");
                    break;
                default:
                    break;
            }
        }
    }
}