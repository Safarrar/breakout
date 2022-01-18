using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public TMP_InputField nameInputField;   // Reference the name input field

    /// <summary>
    /// Start the game
    /// </summary>
    public void StartGame()
    {
        // Set the player name
        GameData.Instance.Name = nameInputField.text;

        // Load the scene
        SceneManager.LoadScene(1);
    }
}
