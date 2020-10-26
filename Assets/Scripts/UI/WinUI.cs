using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField] Button nextButton;
    [SerializeField] Button quitButton;
    
    private void Start()
    {
        nextButton.onClick.AddListener(NextLevel);
        quitButton.onClick.AddListener(Quit);
        this.gameObject.SetActive(false);
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
}
