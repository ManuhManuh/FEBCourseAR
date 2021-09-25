using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DigitalRuby.RainMaker;

public class Forest : MonoBehaviour
{
    public bool raining;
    public TMP_Text forecastText;
    public RainScript rainEffect;
    public List<Animator> treeAnimators = new List<Animator>();

    private void Start()
    {
        raining = false;
    }
    public void ToggleRain()
    {
        // Toggle the rain
        raining = !raining;

        // Update the forecast text
        forecastText.text = raining ? "Forecast: \nRain" : "Forecast: \nCalm";

        // Enable or disable the rain effect
        rainEffect.RainIntensity = raining ? 1f : 0f;

        // For each tree in the forest
        foreach(Animator treeAnimator in treeAnimators)
        {
            // Enable or disable the animator depending on the weather
            treeAnimator.enabled = raining;
        }

    }
}
