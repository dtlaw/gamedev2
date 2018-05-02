using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleVideoPlayer : MonoBehaviour
{
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        UnityEngine.Video.VideoPlayer videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = true;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 0.5F;
        videoPlayer.isLooping = true;
    }
}