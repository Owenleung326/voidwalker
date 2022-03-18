using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusData", menuName = "StatusObjects/Characters", order = 1)]
public class Characters : ScriptableObject
{
    public string charName = "name";
    public float[] position = new float[3];
    public GameObject characterGameObject;
    public float maxHealth = 100;
    public float health = 100;
    public float attackPoint;

}
