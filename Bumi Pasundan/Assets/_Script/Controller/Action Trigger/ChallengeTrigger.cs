using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BumiPasundan
{
    public class ChallengeTrigger : MonoBehaviour
    {
        public GameObject challengePanel;
        public GameObject coret;

        [Header("Gameplay Component")]
        public GameObject ButtonUIComponents;
        public CharController Player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                challengePanel.SetActive(true);
                ButtonUIComponents.SetActive(false);

                other.gameObject.SetActive(false);
                Player.OnCharacterIdle();

                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        public void ResetGamePlay()
        {
            ButtonUIComponents.SetActive(true);
            Player.gameObject.SetActive(true);
        }

        public void OnClickChallengeSuccessful()
        {
            ResetGamePlay();
            coret.SetActive(true);
        }
    }
}
