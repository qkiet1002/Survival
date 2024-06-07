using UnityEngine;

public class SelectedPlayer : MonoBehaviour
{
    private int selectedCharacterIndex = -1;
    public GameObject[] player;

    public void SetSelectedCharacter(int index)
    {
        selectedCharacterIndex = index;
        Debug.Log("Selected character index: " + selectedCharacterIndex);
    }

    public void SpawnSelectedCharacter()
    {
        if (selectedCharacterIndex != -1)
        {
            Debug.Log("Spawning character index: " + selectedCharacterIndex);
            if(selectedCharacterIndex == 0)
            {
                player[0].SetActive(true);
                player[1].SetActive(false);
            }
            if(selectedCharacterIndex == 1)
            {
                player[1].SetActive(true);
                player[0].SetActive(false);
            }
        }
        else
        {
            Debug.LogError("No character selected to spawn!");
        }
    }
}
