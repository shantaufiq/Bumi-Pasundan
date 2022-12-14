using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInstruction : MonoBehaviour
{
    public SpriteRenderer[] instructionImg;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            foreach (var item in instructionImg)
            {
                item.enabled = true;
            }
        }
    }
}
