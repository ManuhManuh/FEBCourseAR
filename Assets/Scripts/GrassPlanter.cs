using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GrassPlanter : MonoBehaviour
{
    public Transform placeholderGrass;
    public Transform placeholderFlower;
    public float plantingGrassDuration;
    public Button plantGrassButton;
    public float timeBetweenGrassPlants;
    public float plantingRadius;
    public int oddsOfFlower;

    private bool planting;
    private float timeLeftPlantingGrass;
    private float timeLeftUntilNextGrassPlant;

    public void StartPlantingGrass()
    {
        // Mark as planting grass
        planting = true;

        // Reset the time left planting grass
        timeLeftPlantingGrass = plantingGrassDuration;

        // Disable plant grass button
        plantGrassButton.interactable = false;
    }

    private void Update()
    {
        // If we're planting grass
        if (planting)
        {
            // Count down the time left planting grass
            timeLeftPlantingGrass -= Time.deltaTime;

            // If we should stop planting grass (timer has run out)
            if (timeLeftPlantingGrass <= 0f)
            {
                // Stop planting grass
                StopPlantingGrass();
     
            }

            // Countdown the time until we should plant the next grass
            timeLeftUntilNextGrassPlant -= Time.deltaTime;

            // If it is time to plant a new grass
            if(timeLeftUntilNextGrassPlant <= 0f)
            {
                // Determine whether we are going to plant grass or a flower
                if (Random.Range(0, oddsOfFlower) == 0)
                {
                    // Plant a flower
                    PlantFlower();
                }
                // Plant a grass

                PlantGrass();

                // Reset grass planting timer 
                timeLeftUntilNextGrassPlant = timeBetweenGrassPlants;
            }

        }

    }

    private void StopPlantingGrass()
    {
        // Unmark as planting
        planting = false;

        // Enable the plant grass button
        plantGrassButton.interactable = true;
    }
    public void PlantGrass()
    {
        // Calculate a random offset position for the grass
        Vector3 randomOffset = Random.insideUnitSphere * plantingRadius;
        randomOffset.y = 0f;

        // Make a clone of the placeholder grass
        Transform newGrass = Instantiate(placeholderGrass, placeholderGrass.position + randomOffset, placeholderGrass.rotation);
        newGrass.SetParent(null, true);
    }

    public void PlantFlower()
    {
        // Calculate a random offset position for the grass
        Vector3 randomOffset = Random.insideUnitSphere * plantingRadius;
        randomOffset.y = 0f;

        // Make a clone of the placeholder grass
        Transform newFlower = Instantiate(placeholderFlower, placeholderFlower.position + randomOffset, placeholderFlower.rotation);
        newFlower.SetParent(null, true);
    }
}