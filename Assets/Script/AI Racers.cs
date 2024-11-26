using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacers : MonoBehaviour
{
    public float distance;
    public float yLimit = 5;
    public float xLimit = 8;
    public Character character;
    public float maxSpeed;
    public float maxSpeedBoost;

    public float speed;
    public float speedBoost;
    public float speedCalc;
    public float acceleration;
    public int place;
    public SplineFollower splineFollower;

    public Animator animator;
    public string[] animations;
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
        if (speed < maxSpeed + maxSpeedBoost)
        {
            speedCalc += acceleration * Time.deltaTime; // Speed slowly increases with acc.            
        }
        else
        {
            speedCalc = maxSpeed + maxSpeedBoost;
        }

        speed = speedCalc;
        // Speed needs to be calculated before.
        splineFollower.followSpeed = speed + speedBoost;
        distance += speed * Time.deltaTime;

    }

}
