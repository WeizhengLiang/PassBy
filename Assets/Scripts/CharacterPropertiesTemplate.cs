using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPropertiesTemplate  : MonoBehaviour
{
    [SerializeField] private CharaterPropertiesData propertiesData;
    public int Health
    {
        get => propertiesData.health; 
        set => propertiesData.health = value;
    }

    public int Strength
    {
        get=>propertiesData.strength; 
        set=>propertiesData.strength=value;
    }

    public int Sanity
    {
        get=>propertiesData.sanity; 
        set=>propertiesData.sanity=value;
    }

    public int Luck
    {
        get => propertiesData.luck; 
        set=>propertiesData.luck=value;
    }
    
}
