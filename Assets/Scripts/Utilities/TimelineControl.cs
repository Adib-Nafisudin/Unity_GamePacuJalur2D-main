using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Video;

public class TimelineControl : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public SceneTransitioner SceneTransition;
    public string skipToNextScene;
    public float holdTime = 1f; // The time user needs to hold the key to skip the cutscene
    public bool holdingSkip;
    private float holdCounter = 0f; // Counter for the hold time
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
        HomeManager.OnResetLevel();
    }
    // Update is called once per frame
    void Update()
    {
        if (holdingSkip)
        {
            holdCounter += Time.deltaTime;
            if (holdCounter >= holdTime)
            {
                LoadScene(VideoPlayer);
            }
        } else
        {
            holdCounter = 0f;
        }
    }
    public void LoadScene(VideoPlayer vp)
    {
        SceneTransition.FadeTo(skipToNextScene);
    }
    public void HoldSkip(){
        holdingSkip = true;
    }
    public void ReleaseSkip()
    {
        holdingSkip = false;
    }
}
