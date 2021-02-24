using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class MoveSimply : MonoBehaviour
{
    [Tooltip("Should this object move relative to the direction it is facing?")]
    bool relativeMovement;
    [Tooltip("How many units of distance does this object move per second?")]
    public float movementSpeed = 3;

    [Header("Keyboard Input")]
    public KeyCode upKey = KeyCode.W;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode downKey = KeyCode.S;

    private void Update()
    {
		UpdateSettings();
		UpdateMovement();
    }
	
	private  void UpdateMovement()
	{		
        var direction = Vector3.zero;

        if (Input.GetKey(leftKey))
        {
            direction -= new Vector3(1, 0, 0);
        }

        if (Input.GetKey(rightKey))
        {
            direction += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(upKey))
        {
            direction += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(downKey))
        {
            direction -= new Vector3(0, 1, 0);
        }

        // Time.deltaTime tells us how many seconds have passed since we last
        // updated the movement - we multiply by movementSpeed to work out
        // how far that many seconds of movement takes us, and multiply by
        // direction to work out the final vector of movement
        Vector2 displacement = direction * movementSpeed * Time.deltaTime;

        if (relativeMovement)
        {
            transform.Translate(displacement, Space.Self);
        }
        else
        {
            transform.Translate(displacement, Space.World);
        }
	}

    //The above code controls movement and 
    //the following code controls turning & flipping the object.

    [Header("")]
    public FlipWithMovementVariables flipWithMovement;
    public TurnWithMovementVariables turnWithMovement;
    public bool resetWhenStill;

    private Vector2 prevPosition;

    private void Awake()
    {
        if(flipWithMovement == null)
            flipWithMovement = new FlipWithMovementVariables();
        if(turnWithMovement == null)
            turnWithMovement = new TurnWithMovementVariables();

        prevPosition = transform.position;
        turnWithMovement.startAngle = transform.eulerAngles.z;

        turnWithMovement.enabledLastFrame = turnWithMovement.enabled;
        flipWithMovement.flipHorizontalLastFrame = flipWithMovement.flipHorizontal;
        flipWithMovement.flipVerticalLastFrame = flipWithMovement.flipVertical;
    }

    private void LateUpdate()
    {
        UpdateFlipWithMovement();
        UpdateTurnWithMovement();
    }

    private void UpdateFlipWithMovement()
    {
        if (!flipWithMovement.flipHorizontal && !flipWithMovement.flipVertical)
            return;

        Vector2 nextPosition = transform.position;
        Vector2 delta = nextPosition - prevPosition;

        if (flipWithMovement.flipHorizontal)
        {
            if (delta.x != 0)
                SetFlippedHorizontal(delta.x < 0);
        }

        if (flipWithMovement.flipVertical)
        {
            if(delta.y != 0)
                SetFlippedVertical(delta.y < 0);
        }
        
        if(resetWhenStill && delta.magnitude < 0.0001f)
        {
            SetFlippedHorizontal(false);
            SetFlippedVertical(false);
        }


        prevPosition = nextPosition;
    }

    public void SetFlippedHorizontal(bool flipped)
    {
        if (flipWithMovement.flippedHorizontal != flipped)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            flipWithMovement.flippedHorizontal = flipped;
        }
    }

    public void SetFlippedVertical(bool flipped)
    {
        if (flipWithMovement.flippedVertical != flipped)
        {
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;

            flipWithMovement.flippedVertical = flipped;
        }
    }

    private void UpdateTurnWithMovement()
    {
        if (!turnWithMovement.enabled)
            return;

        Vector2 nextPosition = transform.position;
        Vector2 delta = nextPosition - prevPosition;
        Vector3 angles = transform.eulerAngles;
        float angle = transform.eulerAngles.z;

        float target; 

        if (delta.magnitude > 0.001f)
        {
            target = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        }
        else
        {
            if (resetWhenStill)
            {
                target = turnWithMovement.startAngle;
            }
            else
            {
                target = angle;
            }
        }

        angles.z = Mathf.SmoothDampAngle(angle,
                                         target,
                                         ref turnWithMovement.angleVelocity,
                                         turnWithMovement.rotateTime);
        transform.eulerAngles = angles;

        prevPosition = nextPosition;
    }



    private void UpdateSettings()
    {
        if (flipWithMovement.flipHorizontalLastFrame != flipWithMovement.flipHorizontal)
        {
            flipWithMovement.flipHorizontalLastFrame = flipWithMovement.flipHorizontal;

            turnWithMovement.enabledLastFrame = turnWithMovement.enabled = false;
        }

        if (flipWithMovement.flipVerticalLastFrame != flipWithMovement.flipVertical)
        {
            flipWithMovement.flipVerticalLastFrame = flipWithMovement.flipVertical;

            turnWithMovement.enabledLastFrame = turnWithMovement.enabled = false;
        }

        if (turnWithMovement.enabledLastFrame != turnWithMovement.enabled)
        {
            turnWithMovement.enabledLastFrame = turnWithMovement.enabled;

            flipWithMovement.flipHorizontal = flipWithMovement.flipHorizontalLastFrame = false;
            flipWithMovement.flipVertical = flipWithMovement.flipVerticalLastFrame = false;
        }
    }

}

[System.Serializable]
public class FlipWithMovementVariables
{
    public bool flipHorizontal;
    public bool flipVertical;

    [HideInInspector]
    public bool flippedHorizontal;
    [HideInInspector]
    public bool flippedVertical;

    [HideInInspector]
    public bool flipHorizontalLastFrame;
    [HideInInspector]
    public bool flipVerticalLastFrame;
}

[System.Serializable]
public class TurnWithMovementVariables
{
    public bool enabled;
    [HideInInspector]
    public bool enabledLastFrame;

    [Header("How long does turning take?")]
    public float rotateTime = 0.4f;

    [HideInInspector]
    public float startAngle;
    [HideInInspector]
    public float angleVelocity;
    [HideInInspector]
    public bool flipped;
}