using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    //All player's data.
    public PlayerData player;

    public Slider healthSlider;

    void Start()
    {
        //Reference the health slider to the veriable.
        healthSlider = GetComponent<Slider>();
    }

    void Update()
    {
        //Attach the player health to the slider.
        healthSlider.value = player.playerHealth / 100;
    }
}
