using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

namespace BumiPasundan
{
    public class CharController : MonoBehaviour
    {
        [Header("Player Input")]
        public InputController inputController;

        [Header("Components")]
        public Rigidbody2D rb;
        [SerializeField] private bool grounded;

        [Range(0f, 20f)]
        [SerializeField] private float speed;

        [Range(0f, 10f)]
        [SerializeField] private float jumpForce;

        [Header("Animation")]
        public Animator anim;

        [Header("Sounds")]
        [SerializeField] private AudioClip jumpSound;

        private void Awake()
        {
            inputController = GameObject.FindGameObjectWithTag("InputController").GetComponent<InputController>();

            FindObjectOfType<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
        }

        // Update is called once per frame
        private void Update()
        {
            if (inputController.Direction.y != 0 && grounded) Jump();

            Move();

            SetAnimation();
        }
        public void Move()
        {
            rb.velocity = new Vector2(inputController.Direction.x * speed, rb.velocity.y);
        }

        public void Jump()
        {
            rb.velocity = new Vector2(rb.transform.localPosition.x, jumpForce);
            anim.SetTrigger("jump");

            SoundManager.Instance.PlaySoundOneShot(jumpSound);
            grounded = false;
        }

        public void SetAnimation()
        {
            // flip character
            if (inputController.Direction.x > 0.01f)
                transform.localScale = Vector3.one;
            else if (inputController.Direction.x < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);

            // Set walk Animation
            anim.SetBool("walk", inputController.Direction.x != 0);

            // set jum Animation
            anim.SetBool("grounded", grounded);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Ground") grounded = true;
        }

        public void OnCharacterIdle()
        {
            inputController.input = Vector2.zero;
        }

    }
}