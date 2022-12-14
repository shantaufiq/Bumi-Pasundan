using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BumiPasundan
{
    public class DialogTrigger : MonoBehaviour
    {
        public int DialogSection;
        [SerializeField] private DialogController _DialogController;
        [SerializeField] private DialogManager _DialogManager;

        [Header("Gameplay Component")]
        public GameObject ButtonUIComponents;
        public CharController Player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                // other.GetComponent<CharController>().enabled = false;
                // _DialogManager._index = DialogSection;
                _DialogManager.SetDialogsOnStage(DialogSection);
                _DialogController.StartDialog();
                ButtonUIComponents.SetActive(false);

                other.gameObject.SetActive(false);
                Player.OnCharacterIdle();

                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
