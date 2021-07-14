﻿using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI verticalVelocityText;
    [SerializeField] TextMeshProUGUI horizontalVelocityText;
    [SerializeField] TextMeshProUGUI fuelText;

    [SerializeField] GameObject player;
    void Start()
    {
        levelText.text = "Level: " + GameManager.instance.data.currentLevel;
        scoreText.text = "Score: " + GameManager.instance.data.playerScore;
    }

    void LateUpdate()
    {
        verticalVelocityText.text = "Vertical Velocity: " + System.Math.Round(player.GetComponent<Rigidbody2D>().velocity.y, 2);
        horizontalVelocityText.text = "Horizontal Velocity: " + System.Math.Round(player.GetComponent<Rigidbody2D>().velocity.x, 2);
        fuelText.text = "Fuel: " + System.Math.Round(player.GetComponent<ShipMovement>().ReturnFuel(), 2);
    }
}
