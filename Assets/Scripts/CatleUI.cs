using System;
using System.Collections;
using System.Collections.Generic;
using Polyperfect.People;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CatleUI : MonoBehaviour
{
    private People_WanderScript followTargetInfo;
    [SerializeField] private GameObject followTarget;
    [SerializeField] private GameObject healthUIContainer;
    public bool isHealing = false;
    
    // Start is called before the first frame update

    void Start()
    {
        followTargetInfo = followTarget.GetComponent<People_WanderScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followTargetInfo.isDamaged)
        {
            LosingHealth();
        }

        if (isHealing)
        {
            IsHeal();
        }
        
        
    }

    private void LosingHealth()
    {
        if (followTargetInfo.toughness < 0) followTargetInfo.toughness = 0;
        for (int i = 11; i > followTargetInfo.toughness - 1; i--)
        {
            healthUIContainer.transform.GetChild(i).gameObject.SetActive(false);
        }

        followTargetInfo.isDamaged = false;
    }

    public void IsHeal()
    {
        Debug.Log("Healing");
        followTargetInfo.toughness += 2;
        if (followTargetInfo.toughness > 12) followTargetInfo.toughness = 12;
        for (int i = 0; i < followTargetInfo.toughness; i++)
        {
            healthUIContainer.transform.GetChild(i).gameObject.SetActive(true);
        }

        isHealing = false;
    }
}
