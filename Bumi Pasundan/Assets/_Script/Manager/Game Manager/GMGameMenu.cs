using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BumiPasundan
{
    public class GMGameMenu : GameManager
    {
        private void Awake()
        {
            // DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SoundManager.Instance.PlayMusic();
        }
    }
}
