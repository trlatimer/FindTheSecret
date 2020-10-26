using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button displayPanel;

    bool showingCredits = false;

    private void Start()
    {
        startButton.onClick.AddListener(NextLevel);
        quitButton.onClick.AddListener(Quit);
        creditsButton.onClick.AddListener(ToggleCredits);
    }

    private void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void ToggleCredits()
    {
        if (showingCredits)
        {
            displayPanel.GetComponentInChildren<Text>().text = "Instructions:\n\nClick on the world to move the character\n\nFollow the hints until your character collides with the secret object!\n\nFind the secret before the time runs out!";
            showingCredits = false;
        } else
        {
            displayPanel.GetComponentInChildren<Text>().text = "Credits\n\nMusic by Eric Matyas\nwww.soundimage.org\n\nArt by Synty Studios\nhttps://www.syntystudios.com/";
            showingCredits = true;
        }
        
    }
}
