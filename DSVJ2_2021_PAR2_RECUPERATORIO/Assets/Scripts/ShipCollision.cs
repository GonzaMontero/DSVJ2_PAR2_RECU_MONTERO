using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D),typeof(ShipMovement))]
public class ShipCollision : MonoBehaviour
{
    [SerializeField] float angleThreshold;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Landing Zone")
        {
            float currentSpeedX = Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x);
            float currentSpeedY = Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y);
            bool isLowOnSpeed = (currentSpeedY < 0.5f) && (currentSpeedX < 0.5f);

            float angledifference = Mathf.Abs(Vector2.Angle(Vector2.up, transform.up));
            bool isAngledCorrectly = angledifference < angleThreshold;

            if (isLowOnSpeed && isAngledCorrectly)
            {
                GameObject levelChanger = GameObject.FindGameObjectWithTag("Level");
                levelChanger.GetComponent<LevelChanger>().WinLevel();
            }
            else
            {
                GameObject levelChanger = GameObject.FindGameObjectWithTag("Level");
                levelChanger.GetComponent<LevelChanger>().Explode();
            }
        }
        else
        {
            GameObject levelChanger = GameObject.FindGameObjectWithTag("Level");
            levelChanger.GetComponent<LevelChanger>().Explode();
        }
    }
}
