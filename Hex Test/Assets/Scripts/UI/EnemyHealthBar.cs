using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Image Health;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    BattleSystemManager Manager;

    private void Start()
    {
        Health = GetComponent<Image>();
        Manager = FindObjectOfType<BattleSystemManager>();
    }

    private void Update()
    {
        CurrentHealth = Manager.enemyStatus.health;
        Health.fillAmount = CurrentHealth / MaxHealth;
    }
}
