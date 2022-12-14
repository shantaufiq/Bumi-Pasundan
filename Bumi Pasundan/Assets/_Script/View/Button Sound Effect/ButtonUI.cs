using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [Header("Clip")]
    [SerializeField] private AudioClip klickSound;

    public void KlickSound()
    {
        SoundManager.Instance.PlaySoundOneShot(klickSound);
    }

}
