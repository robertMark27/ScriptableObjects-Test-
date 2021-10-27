using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    //All player's data.
    public PlayerData player;

    //UI elements.
    public Image healthCircle;
    public Text healthText;
    public Slider waveTimeBreak;
    public GameObject waveBreakPanell;

    void Update()
    {
        //Attach the player health to the slider.
        healthCircle.fillAmount = player.playerHealth / 100;

        //Show the health amount on the text.
        healthText.text = player.playerHealth.ToString();

        //Active the wave time breake panel.
        if (player.playerWaveBreak)
        {
            waveBreakPanell.SetActive(true);
            waveTimeBreak.value = player.playerBreakTime / 100;
        }
        else
            waveBreakPanell.SetActive(false);
    }
}
