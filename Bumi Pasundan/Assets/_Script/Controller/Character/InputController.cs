using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BumiPasundan
{
    public class InputController : MonoBehaviour
    {
        public static InputController instance;

        [Header("Input Value")]
        public Vector2 input = Vector2.zero;
        public float horizontalValue { get { return input.x; } }
        public float verticalValue { get { return input.y; } }
        public Vector2 Direction { get { return new Vector2(horizontalValue, verticalValue); } }

        private void Awake() => instance = this;

        private void Update()
        {
            // if (Direction.y != 0) Debug.Log("jalan");
        }
    }
}
