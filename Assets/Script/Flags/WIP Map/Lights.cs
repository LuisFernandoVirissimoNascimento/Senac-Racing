using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public bool isEntrance;
    public GameObject[] lights;

    private void OnTriggerEnter(Collider collision)
    {
        if (isEntrance && collision.gameObject.CompareTag("Player"))
        {
            lights[1].SetActive(false);
        }
        else
        {
            lights[1].SetActive(true);
        }
    }
}
