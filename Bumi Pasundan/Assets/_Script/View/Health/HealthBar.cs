using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BumiPasundan
{
    public class HealthBar : MonoBehaviour
    {
        public HealthManager _HealthManager;
        [SerializeField] private Slider _healthBar;

        void Start() => _healthBar.value = _HealthManager.currentHealth;
        void Update() => _healthBar.value = _HealthManager.currentHealth;
    }
}
