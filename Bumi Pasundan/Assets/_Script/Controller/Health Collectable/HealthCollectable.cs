using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BumiPasundan
{
    public class HealthCollectable : MonoBehaviour
    {
        [SerializeField] private float healthValue;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<HealthManager>().AddHealth(healthValue);
                gameObject.SetActive(false);
            };
        }
    }
}
