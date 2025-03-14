using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Slider hp_Slider;
    public Slider air_Slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp_Slider.value = player.currentHp / player.maxHp;
        air_Slider.value = player .currentAir / player.maxAir;
    }
}
