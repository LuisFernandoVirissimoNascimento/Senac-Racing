using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Senac/Character")]
public class Character : ScriptableObject
{
    public int index;
    public string nome;
    public string description;
    public float maxSpeed;
    public float acceleration;
    public float resistance;
    public float manouverability;
}
