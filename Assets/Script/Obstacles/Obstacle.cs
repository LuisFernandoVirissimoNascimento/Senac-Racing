using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float obstaclePower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            Player play = other.GetComponentInParent<Player>();

            play.speed /= obstaclePower;
            play.speedCalc /= obstaclePower;
        }

        if(other.GetComponentInParent<AIRacers>() != null)
        {
            AIRacers play = other.GetComponentInParent<AIRacers>();

            play.speed /= obstaclePower;
            play.speedCalc /= obstaclePower;
        }
    }
}
