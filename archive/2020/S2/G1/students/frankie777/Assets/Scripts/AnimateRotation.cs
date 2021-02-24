using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class AnimateRotation : MonoBehaviour 
{
    [Header("Timings (seconds)")]
    public float turnSpeed;
    public float turnDuration;

    #region Editor Tricks
    private float _prevTurnSpeed;
    private float _prevTurnDuration;

    /// <summary>
    /// update timings so that loop duration, frame duration, and frame count
    /// are consistent with each other, based on which have just changed
    /// </summary>
    private void MakeTimingsConsistent()
    {
        if (_prevTurnSpeed != turnSpeed)
        {
            turnDuration = 360f / Mathf.Abs(turnSpeed);
        }
        else if (_prevTurnDuration != turnDuration)
        {
            turnSpeed = 360f / turnDuration;
        }
        
        _prevTurnSpeed = turnSpeed;
        _prevTurnDuration = turnDuration;
    }
    #endregion

    private void Update()
    {
        MakeTimingsConsistent();

        if (Application.isPlaying)
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);
        }
    }
}
