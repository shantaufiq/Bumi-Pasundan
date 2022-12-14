using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    [Header("UI Controller")]
    private FixedJoystick joystick;
    private Button btn_jump;

    [Header("Components")]
    public Rigidbody2D rb;

    [Range(0f, 10f)]
    [SerializeField] private float speed;
    [Range(0f, 10f)]
    [SerializeField] private float jumpForce;

    private void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        btn_jump = GameObject.FindGameObjectWithTag("Btn_Jump").GetComponent<Button>();
    }

    private void Update()
    {
        // if (joystick.Direction.x != 0) Debug.Log(joystick.Direction.x);

        Move();

        btn_jump.onClick.AddListener(() => Jump());
    }

    public void Move()
    {
        rb.velocity = new Vector2(joystick.Direction.x * speed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
