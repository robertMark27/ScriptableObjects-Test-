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

    void Start()
    {
        //Reference the health slider to the veriable.
        healthCircle = GetComponent<Image>();
    }

    void Update()
    {
        //Attach the player health to the slider.
        healthCircle.fillAmount = player.playerHealth / 100;

        //Show the health amount on the text.
        healthText.text = player.playerHealth.ToString();
    }
}
