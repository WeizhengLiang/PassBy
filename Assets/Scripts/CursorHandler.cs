using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] private GameObject chatboxPrefab;
    [SerializeField] private Transform chatboxParent;
    [SerializeField] private TextMeshProUGUI chatboxTextContent;
    [SerializeField] private String chatboxText;
    
    private GameObject chatboxInstance;
    private bool isHovering;
    private Collider2D col;

    private void Start()
    {
        chatboxInstance = Instantiate(chatboxPrefab, chatboxParent);
        chatboxInstance.SetActive(false);
        col = chatboxParent.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isHovering)
        {
            chatboxInstance.SetActive(true);
            chatboxInstance.transform.position = Input.mousePosition + new Vector3(10f, 10f, 0f);
        }
        else
        {
            chatboxInstance.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        isHovering = true;
        chatboxTextContent.SetText(chatboxText);
    }
    
    private void OnMouseExit()
    {
        isHovering = false;
    }

    
}
