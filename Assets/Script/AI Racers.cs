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
    public SplineFollower splineFollower; public float maxSeconds;
    public float timer;
    bool stop;
    public bool isDodging;
    private void Start()
    {
        acceleration = character.acceleration;
        maxSpeed = character.maxSpeed;
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
        if (!isDodging)
        {
            RandomInterruption();
        }
        // Speed needs to be calculated before.
        splineFollower.followSpeed = speed + speedBoost;
        distance += speed * Time.deltaTime;

    }

    void RandomInterruption()
    {
        if (timer > maxSeconds)
        {
            timer = 0;
            maxSeconds = Random.Range(15, 30);
            stop = true;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (stop && timer < 2.0 - (2.0 * (character.resistance + 1.0) / 100.0))
        {
            if(speed != 0)
            {
                speed = maxSpeed / 2;
                speedCalc = maxSpeed / 2;
            }
        }
        else
        {
            stop = false;
        }
    }
}
