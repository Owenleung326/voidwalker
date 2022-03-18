using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarNor : MonoBehaviour
{
    public class HealthBar : MonoBehaviour
    {
        private Image Health;
        public float CurrentHealth;
        private float MaxHealth = 100f;
        StatusManager Manager;

        private void Start()
        {
            Health = GetComponent<Image>();
            Manager = FindObjectOfType<StatusManager>();
        }

        private void Update()
        {
            CurrentHealth = Manager.playerStatus.health;
            Health.fillAmount = CurrentHealth / MaxHealth;
        }
    }
}
