using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    public Slider _slider;
    float currentHp;
    float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        _slider.value = 1;
        currentHp = PlayerStatus.PlayerLife;
        maxHp = PlayerStatus.PlayerLifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = PlayerStatus.PlayerLife;
        maxHp = PlayerStatus.PlayerLifeMax;
        _slider.value = currentHp / maxHp;
    }
}
