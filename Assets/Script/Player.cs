using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distance;
    public float yLimit;
    public float xLimit;
    public Character character;
    public float maxSpeed;
    public float maxSpeedBoost;

    public float speed;
    public float speedBoost;
    public float speedCalc;
    public float acceleration;
    public int place;
    public SplineFollower splineFollower;

    public Transform circleTransform;

    public Animator animator;
    public string[] animations;
    
    /// Code made for testing purposes of collision at arbitrary times. To Simulate skill issues.
    //public float maxSeconds;
    //public float timer;
    //bool stop;
    //public bool isDodging;
    private void Start()
    {
        acceleration = character.acceleration;
        maxSpeed = character.maxSpeed;

        int whichAnimation = Random.Range(0, animations.Length);
        animator.Play(animations[whichAnimation]);
    }

    private void Update()
    {
        // Speed Calculations
        if(speed < maxSpeed + maxSpeedBoost)
        {
            speedCalc += acceleration * Time.deltaTime; // Speed slowly increases with acc.            
        }
        else
        {
            speedCalc = maxSpeed + maxSpeedBoost;
        }

        speed = speedCalc;
        // RandomInterruption(); // THis test func needs to go here in order to work.
        // Speed needs to be calculated before.
        splineFollower.followSpeed = speed + speedBoost;
        distance += speed * Time.deltaTime;




        if (Input.GetKey(KeyCode.D))
        {
            if(circleTransform.localPosition.x > -xLimit)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x - character.manouverability * Time.deltaTime, circleTransform.localPosition.y, circleTransform.localPosition.z);
            }
        }else if(Input.GetKey(KeyCode.A))
        {
            if (circleTransform.localPosition.x < xLimit)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x + character.manouverability * Time.deltaTime, circleTransform.localPosition.y, circleTransform.localPosition.z);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (circleTransform.localPosition.y > -yLimit)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x, circleTransform.localPosition.y - character.manouverability * Time.deltaTime, circleTransform.localPosition.z);
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (circleTransform.localPosition.y < yLimit)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x, circleTransform.localPosition.y + character.manouverability * Time.deltaTime, circleTransform.localPosition.z);
            }
        }
    }

        // Function that makes it so the player randomly stumbles. Made for the purpose of testing.
    //void RandomInterruption()
    //{
    //    if(timer > maxSeconds)
    //    {
    //        timer = 0;
    //        maxSeconds = Random.Range(15, 30);
    //        stop = true;
    //    }
    //    else
    //    {
    //        timer += Time.deltaTime;
    //    }

    //    if (stop && timer < 2.0 - (2.0 * ( character.resistance + 1.0) / 100.0))
    //    {
    //        speed = maxSpeed / 2;
    //        speedCalc = maxSpeed / 2;
    //    }
    //    else
    //    {
    //        stop = false;
    //    }
    //}
}
