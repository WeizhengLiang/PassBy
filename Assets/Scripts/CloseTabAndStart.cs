using System.Collections;
using System.Collections.Generic;
using Polyperfect.Animals;
using UnityEngine;

public class CloseTabAndStart : MonoBehaviour
{
    [SerializeField] private GameObject manager;

    private AnimalWanderManager animanager;
    // Start is called before the first frame update
    void Start()
    {
        animanager = manager.GetComponent<AnimalWanderManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(false);
            animanager.PeaceTime = false;
        }
    }
}
