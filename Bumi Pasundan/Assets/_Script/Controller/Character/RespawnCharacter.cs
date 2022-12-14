using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BumiPasundan
{
    public class RespawnCharacter : MonoBehaviour
    {
        private Transform currentCheckpoint;
        private HealthManager playerHealth;

        private void Awake()
        {
            playerHealth = GetComponent<HealthManager>();
        }

        public void Respawn()
        {
            playerHealth.Respawn(); //Restore player health and reset animation
            transform.position = currentCheckpoint.position; //Move player to checkpoint location

            //Move the camera to the checkpoint's room
            // Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Checkpoint")
            {
                // SoundManager.instance.PlaySound(checkpoint);
                // collision.GetComponent<Animator>().SetTrigger("activate");
                currentCheckpoint = collision.transform;
                collision.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
