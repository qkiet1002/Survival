using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedUI : MonoBehaviour
{
    private SelectedPlayer characterSelector; 

    public Button[] characterButtons; 
    public Button spawnButton; 
    private int selectedCharacterIndex = -1; 

    void Start()
    {

      
        characterSelector = FindObjectOfType<SelectedPlayer>();
        for (int i = 0; i < characterButtons.Length; i++)
        { 
            int index = i; 
            characterButtons[i].onClick.AddListener(() => OnCharacterButtonClicked(index));
        }

        spawnButton.onClick.AddListener(OnSpawnButtonClicked);
        spawnButton.interactable = false;
    }
    void OnCharacterButtonClicked(int index)
    {
        selectedCharacterIndex = index;
        characterSelector.SetSelectedCharacter(index); 
        spawnButton.interactable = true;
    }
    void OnSpawnButtonClicked()
    {
        if (selectedCharacterIndex != -1)
        {
            characterSelector.SpawnSelectedCharacter(); 
        }
    }
    void Update()
    {
        // Check for number key presses
        if (Input.GetKeyDown(KeyCode.F1))
        {
            OnCharacterButtonClicked(0);
            OnSpawnButtonClicked();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            OnCharacterButtonClicked(1);
            OnSpawnButtonClicked();
        }
    }
}
