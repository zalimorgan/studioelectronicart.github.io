using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

/// <summary>
/// animate by treating all children of this object as a frame of an animation,
/// turning them off and on in sequence, ensuring only one is ever on at a time
/// </summary>
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class AnimateSimply : MonoBehaviour 
{
    public int currentFrame;

    [Header("Timing (seconds)")]
    [Tooltip("How many seconds it takes the animation to complete")]
    public float animationLoopDuration = 0.3f;
    [Tooltip("How many seconds each frame is shown for")]
    public float eachFrameDuration = 0.15f;
    [Tooltip("Should the animation start part way through a random frame?")]
    public bool startAtRandomTime;

    [Header("Editor")]
    [Tooltip("Should we rename frame objects in the heirarchy as a reminder?")]
    public bool renameFrames = true;
    [Tooltip("Should the animations move in Edit mode? This sometimes prevents you renaming.")]
	bool animateInEditMode = true;

    private float timeSinceCurrentFrame;

    #region Editor Tricks
    private float _prevFrameDuration;
    private float _prevAnimationDuration;
    private int _prevFrameCount;

    /// <summary>
    /// update timings so that loop duration, frame duration, and frame count
    /// are consistent with each other, based on which have just changed
    /// </summary>
    private void MakeTimingsConsistent()
    {
        int frameCount = transform.childCount;

        if (frameCount == 0)
        {
            return;
        }

        if (_prevFrameCount != frameCount)
        {
            animationLoopDuration = frameCount * eachFrameDuration;
        }
        else if (_prevAnimationDuration != animationLoopDuration)
        {
            eachFrameDuration = animationLoopDuration / frameCount;
        }
        else if (_prevFrameDuration != eachFrameDuration)
        {
            animationLoopDuration = frameCount * eachFrameDuration;
        }

        _prevFrameCount = frameCount;
        _prevFrameDuration = eachFrameDuration;
        _prevAnimationDuration = animationLoopDuration;
    }

    private void RenameFrames()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).name = "Frame " + (i + 1);
        }
    }
    #endregion

    private void Start()
    {
        if (startAtRandomTime)
        {
            currentFrame = Random.Range(0, transform.childCount);
            timeSinceCurrentFrame = Random.value * eachFrameDuration;
        }
    }

    private void Update()
    {
		if(!Application.isPlaying && !animateInEditMode )
			return;
		
        MakeTimingsConsistent();        
		RenameFrames();
		
		AdvanceTime(Time.deltaTime);
    }

    /// <summary>
    /// advance the animation by a duration in seconds, advancing as many
    /// frames as necessary
    /// </summary>
    private void AdvanceTime(float duration)
    {
        timeSinceCurrentFrame += duration;
        
        while (timeSinceCurrentFrame > eachFrameDuration && eachFrameDuration > 0)
        {
            timeSinceCurrentFrame -= eachFrameDuration;

            AdvanceFrame();
        }
    }

    /// <summary>
    /// advance the animation by one frame, looping if necessary
    /// </summary>
    private void AdvanceFrame()
    {
        currentFrame += 1;

        // looping
        if (currentFrame >= transform.childCount)
        {
            currentFrame = 0;
        }

        RefreshFrame();
    }

    /// <summary>
    /// turn off all frames except the current frame, which is turned on
    /// </summary>
    private void RefreshFrame()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(i == currentFrame);
        }
    }
}
