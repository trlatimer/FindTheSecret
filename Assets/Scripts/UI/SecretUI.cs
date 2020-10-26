using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretUI : MonoBehaviour
{
    [SerializeField] string[] hints;
    [SerializeField] float timeToComplete = 120f;
    [SerializeField] float timeBetweenHints = 60f;
    [SerializeField] float hintDisplayTime = 10f;
    [SerializeField] Text score;
    [SerializeField] Text hintOutput;
    [SerializeField] Canvas loseUI;

    float timeLeft;
    float timeUntilNextHint = 0;
    int currentHintIndex = 0;
    float displayLeft = 0;

    private void Start()
    {
        timeLeft = timeToComplete;
        hintOutput.text = "";
        score.text = Mathf.Round(timeLeft).ToString();
        Time.timeScale = 1f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeUntilNextHint -= Time.deltaTime;
        displayLeft -= Time.deltaTime;

        score.text = Mathf.Round(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            loseUI.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

        if (timeUntilNextHint <= 0)
        {
            SetHintAndDisplay();
        }

        if (displayLeft <= 0)
        {
            hintOutput.text = "";
        }
    }

    private void SetHintAndDisplay()
    {
        // Display hint
        displayLeft = hintDisplayTime;
        hintOutput.text = hints[currentHintIndex];
        if (currentHintIndex + 1 < hints.Length)
        {
            currentHintIndex++;
        }
        timeUntilNextHint = timeBetweenHints;
    }
}
