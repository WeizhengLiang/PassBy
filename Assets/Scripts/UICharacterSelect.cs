using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class UICharacterSelect : MonoBehaviour
{
    [SerializeField] private GameObject Joe;
    [SerializeField] private GameObject Amy;
    private Animator ani;
    private int currentSelectedCharacter;
    private CharacterPropertiesTemplate characterdata;
    [SerializeField] private GameObject UI_health_container;
    [SerializeField] private GameObject UI_strength_container;
    [SerializeField] private GameObject UI_sanity_container;
    [SerializeField] private GameObject UI_luck_container;

    [SerializeField] private Button ok;



    private enum Characters
    {
        Joe = 0,
        Amy = 1
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentSelectedCharacter = 1;
        characterdata = gameObject.GetComponent<CharacterPropertiesTemplate>();
        ChangeCharacterData(currentSelectedCharacter);
        ChangeCharacterDataUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Logic of switch character in character selection
    public void SwitchCharacter(int characterHit)
    {
        // selected Amy
        if ((int)Characters.Amy == characterHit && (int)Characters.Amy != currentSelectedCharacter)
        {
            
            // ok.GetComponent<TextMeshPro>().SetText("I Want You!");
            // ok.interactable = true;
            // Debug.Log("ok");
            
            
            currentSelectedCharacter = (int)Characters.Amy;
                    
            Joe.SetActive(false);
            Amy.SetActive(true);

            ani = Amy.GetComponent<Animator>();
            ani.SetTrigger("waving");
            
            ChangeCharacterData(currentSelectedCharacter);
            ChangeCharacterDataUI();
        }
        else if((int)Characters.Joe == characterHit && (int)Characters.Joe != currentSelectedCharacter)
        // selected Joe
        {
            // ok.GetComponent<TextMeshPro>().SetText("Comming Soon");
            // ok.interactable = false;
            // Debug.Log("commingsoon");
            
            
            currentSelectedCharacter = (int)Characters.Joe;
                    
            Amy.SetActive(false);
            Joe.SetActive(true);
            ani = Joe.GetComponent<Animator>();
            ani.SetTrigger("waving");
            
            ChangeCharacterData(currentSelectedCharacter);
            ChangeCharacterDataUI();
        }
        
        
        
        
    }

    private void ChangeCharacterData(int currentCharacter)
    {
        switch (currentCharacter)
        {
            case (int)Characters.Joe:
                characterdata.Health = 3;
                characterdata.Strength = 3;
                characterdata.Sanity = 1;
                characterdata.Luck = 2;
                break;
            case (int)Characters.Amy:
                characterdata.Health = 2;
                characterdata.Strength = 1;
                characterdata.Sanity = 3;
                characterdata.Luck = 4;
                break;
        }
        
    }

    private void ChangeCharacterDataUI()
    {
        ResetCharacterUI();
        
        for (int i = 5; i > characterdata.Health; i--)
        {
            // the range is 0-4 instead of 1-5 so i needs to minus 1 to avoid out of index bound
            UI_health_container.transform.GetChild(i-1).gameObject.SetActive(false);
        }
        for (int i = 5; i > characterdata.Strength; i--)
        {
            UI_strength_container.transform.GetChild(i-1).gameObject.SetActive(false);
        }
        for (int i = 5; i > characterdata.Sanity; i--)
        {
            UI_sanity_container.transform.GetChild(i-1).gameObject.SetActive(false);
        }
        for (int i = 5; i > characterdata.Luck; i--)
        {
            UI_luck_container.transform.GetChild(i-1).gameObject.SetActive(false);
        }
    }

    private void ResetCharacterUI()
    {
        for (int i = 0; i < 5; i++)
        {
            UI_health_container.transform.GetChild(i).gameObject.SetActive(true);
            UI_strength_container.transform.GetChild(i).gameObject.SetActive(true);
            UI_sanity_container.transform.GetChild(i).gameObject.SetActive(true);
            UI_luck_container.transform.GetChild(i).gameObject.SetActive(true);
        }
        
    }

    // public void ChangeOKToCommingSoon()
    // {
    //     ok.GetComponent<TextMeshProUGUI>().SetText("Comming Soon");
    //     ok.interactable = false;
    //     Debug.Log("commingsoon");
    // }
    //
    // public void ResetOKUI()
    // {
    //     ok.GetComponent<TextMeshProUGUI>().SetText("I Want You!");
    //     ok.interactable = true;
    //     Debug.Log("ok");
    // }
    
    
}
