using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class MoveWithCamera : MonoBehaviour
{
    Camera mainCamera
    {
        get { return Camera.main; }
    }

    public bool changePosition;
    public bool thisIsStartPosition;

    [Header("1 to 99 for far away. < 0 for close")]
    [Tooltip("Left/Right. 0 - still. \n100 - stuck to camera\n0 to 99 - far away objects\nLess than< 0 - closer objects")]
    public float percentXSpeed = 100;
    [Tooltip("Up/Down. 0 - still. \n100 - stuck to camera\n0 to 99 - far away objects\nLess than< 0 - closer objects")]
    public float percentYSpeed = 0;

    [HideInInspector]
    public Vector3 cameraCenterPosition;
    [HideInInspector]
    public Vector3 centerPosition;

    void Awake()
    {
       // if (centerPosition == Vector3.zero && cameraCenterPosition == Vector3.zero)
         //   GetNewParallaxStartPosition();
    }

    void GetNewParallaxStartPosition()
    {
        centerPosition = transform.position;
        cameraCenterPosition = mainCamera.transform.position;
    }

    void UpdatePosition()
    {
        Vector3 _newPos = Vector3.zero;
        Vector3 _camPos = mainCamera.transform.position;

        float _movementX = percentXSpeed / 100.0f;
        float _movementY = percentYSpeed / 100.0f;
        
        _newPos.x = centerPosition.x + ((_camPos.x - cameraCenterPosition.x) * (_movementX));
        _newPos.y = centerPosition.y + ((_camPos.y - cameraCenterPosition.y) * (_movementY));

        if (_movementX == 0)
            _newPos.x = transform.position.x;
        if (_movementY == 0)
            _newPos.y = transform.position.y;

        _newPos.z = transform.position.z;

        transform.position = _newPos;
    }


    void LateUpdate()
    {
        if (Application.isPlaying)
        {
            changePosition = false;
        }

        thisIsStartPosition = transform.position == centerPosition;

#if UNITY_EDITOR

        if (changePosition)
        {

            if (Selection.activeGameObject != gameObject)
                changePosition = false;
            GetNewParallaxStartPosition();
            return;
        }
        
#endif

        UpdatePosition();
    }

    private void OnValidate()
    {
        UpdatePosition();
    }
}
