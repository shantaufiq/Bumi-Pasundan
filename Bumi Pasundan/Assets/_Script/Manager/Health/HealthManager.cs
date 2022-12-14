using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BumiPasundan
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private float startingHealth;
        public float currentHealth { get; private set; }

        public bool dead;

        [Header("Animation")]
        [SerializeField] private Animator anim;

        private void Awake()
        {
            currentHealth = startingHealth;
        }

        public void TakeDemage(float _damage)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                //iframes
            }
            else
            {
                if (!dead)
                {
                    anim.SetTrigger("die");
                    // GetComponent<CharacterController>().enabled = false;
                    dead = true;
                }
            }
        }

        public void AddHealth(float _value)
        {
            currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        }

        // private IEnumerator Invunerability()
        // {
        //     invulnerable = true;
        //     Physics2D.IgnoreLayerCollision(10, 11, true);
        //     for (int i = 0; i < numberOfFlashes; i++)
        //     {
        //         spriteRend.color = new Color(1, 0, 0, 0.5f);
        //         yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        //         spriteRend.color = Color.white;
        //         yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        //     }
        //     Physics2D.IgnoreLayerCollision(10, 11, false);
        //     invulnerable = false;
        // }
        private void Deactivate()
        {
            gameObject.SetActive(false);
        }

        //Respawn
        public void Respawn()
        {
            AddHealth(startingHealth);
            anim.ResetTrigger("die");
            anim.Play("idle");
            // StartCoroutine(Invunerability());

            //Activate all attached component classes
            // foreach (Behaviour component in components)
            //     component.enabled = true;
        }
    }
}
