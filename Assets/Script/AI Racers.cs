using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacers : MonoBehaviour
{
    // The racers need a reference to the player so that they may be able to keep up with the player, in order to solve that old problem with racing games where if the player is too good. The NPCs need a boost to keep up. We are doing that.
    public Player player;

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
    public Transform circleTransform;
    public Vector2 targetPos;
    public float timeForNextTarget;
    float timer;

    int skillHandler;

    public Animator animator;
    public string[] animations;
    private void Start()
    {
        acceleration = character.acceleration;
        maxSpeed = character.maxSpeed;

        int whichAnimation = Random.Range(0, animations.Length);
        animator.Play(animations[whichAnimation]);

        player = GameObject.Find("Player").GetComponent<Player>();
        skillHandler = 1;
    }

    private void Update()
    {
        // Account for Player skill
        skillHandler = (distance + 100 < player.distance) ? 2 : 1;

        // Speed Calculations
        if (speed < maxSpeed + maxSpeedBoost)
        {
            speedCalc += acceleration * Time.deltaTime; // Speed slowly increases with acc.            
        }
        else
        {
            speedCalc = maxSpeed + maxSpeedBoost;
        }

        speed = speedCalc * skillHandler;
        // Speed needs to be calculated before.
        splineFollower.followSpeed = speed + speedBoost;
        distance += speed * Time.deltaTime;
        // Make a func that gives them a random coordinate of x and y, then they have to try and use these functions to arrive at that result.
        timer += 1 * Time.deltaTime;
        if(timer >= timeForNextTarget)
        {
            timeForNextTarget = Random.Range(1, 4);
            timer = 0;
            targetPos = new Vector2(Random.Range(-8,8), Random.Range(-5,5));
        }
        // Go right
            if (circleTransform.localPosition.x > targetPos.x)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x - character.manouverability * Time.deltaTime, circleTransform.localPosition.y, circleTransform.localPosition.z);
            }
        
            // Go left
            if (circleTransform.localPosition.x < targetPos.x)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x + character.manouverability * Time.deltaTime, circleTransform.localPosition.y, circleTransform.localPosition.z);
            }
        

        
            // Go Down
            if (circleTransform.localPosition.y > targetPos.y) // Instead of ylimit, we simply say the vector2 y of target.
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x, circleTransform.localPosition.y - character.manouverability * Time.deltaTime, circleTransform.localPosition.z);
            }        
            else if (circleTransform.localPosition.y < targetPos.y)
            {
                circleTransform.localPosition = new Vector3(circleTransform.localPosition.x, circleTransform.localPosition.y + character.manouverability * Time.deltaTime, circleTransform.localPosition.z);
            }
        

    }

}
