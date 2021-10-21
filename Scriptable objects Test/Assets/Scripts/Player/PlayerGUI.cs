using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    public PlayerData player;
    public Slider healthSlider;

    void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

    void Update()
    {
        healthSlider.value = player.playerHealth / 100;
    }
}
