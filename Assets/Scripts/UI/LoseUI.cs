using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;

    private void Start()
    {
        retryButton.onClick.AddListener(RetryLevel);
        quitButton.onClick.AddListener(Quit);
        this.gameObject.SetActive(false);
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
