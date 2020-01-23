using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーステータス
/// </summary>
namespace Player
{
    public class PlayerStatus
    {
        static public int PlayerLevel { get; set; } = 1;
        static public int PlayerLifeMax { get; set; } = 30;
        static public int PlayerLife { get; set; } = 30;
        static public int PlayerPower { get; set; } = 7;
        static public int PlayerDifece { get; set; } = 3;
    }
}