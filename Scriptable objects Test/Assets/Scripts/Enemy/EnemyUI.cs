using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    //Enemy data.
    public EnemyData enemy;

    //UI elements.
    public Slider healthBar;

    //Health bar offset.
    public Vector3 healthBarOffset;

    private void Update()
    {
        //Enable health bar when the healht value lower then 100.
        if (enemy.enemyHealth < 100)
            healthBar.gameObject.SetActive(true);
        else
            healthBar.gameObject.SetActive(false);

        if(healthBar != null)
            //Set the health bar value to enemy health value.
            healthBar.value = enemy.enemyHealth / 100;

        //Health bar follow the enemy.
        healthBar.transform.position = new Vector3(enemy.enemyPosition.x + healthBarOffset.x, enemy.enemyPosition.y + healthBarOffset.y);
    }
}
