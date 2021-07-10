using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI verticalVelocityText;
    [SerializeField] TextMeshProUGUI horizontalVelocityText;

    [SerializeField] GameObject player;

    void Start()
    {
        levelText.text = "Level: " + player.GetComponent<Player>().GetLevel();
        scoreText.text = "Score: " + player.GetComponent<Player>().GetScore();
    }

    void LateUpdate()
    {
        verticalVelocityText.text = "Vertical Velocity: " + player.GetComponent<Rigidbody2D>().velocity.y;
        horizontalVelocityText.text = "Horizontal Velocity: " + player.GetComponent<Rigidbody2D>().velocity.x;
    }
}
