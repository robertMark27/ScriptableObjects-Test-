using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New enemy", menuName ="Enemy")]
public class EnemyData : ScriptableObject
{
    //Enemy characteristics.
    public float enemyHealth;
    public float enemySpeed;
    public float enemyjumpForce;

    //Player other data
    public Material enemyMaterial;
    public Vector3 enemyPosition;
}
