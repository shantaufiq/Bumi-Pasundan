using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace BumiPasundan
{
    public class GMCutScene : GameManager
    {
        [Header("Video Clips")]
        public List<string> SceneLevel;

        [Header("Video Clips")]
        public List<VideoClip> _videoClips;

        [Header("Cut Scene Components")]
        public GameObject cutSceneView;
        public VideoPlayer video;

        private void Awake()
        {
            PlayEndVideo(true);
        }

        // Update is called once per frame
        void Update()
        {
            if ((video.frame) > 0 && video.isPlaying == false) PlayEndVideo(false);
        }

        public void PlayEndVideo(bool state)
        {
            if (state)
            {
                cutSceneView.SetActive(true);
                video.clip = _videoClips[GMLevelSelection.instance.level];
                video.Play();
            }
            else
            {
                cutSceneView.SetActive(false);
                ChangeScene(SceneLevel[GMLevelSelection.instance.level]);
            }
        }
    }
}
