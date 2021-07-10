using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D),typeof(ShipMovement))]
public class ShipCollision : MonoBehaviour
{
    [SerializeField] float angleThreshold;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Landing Zone")
        {
            float currentSpeedX = gameObject.GetComponent<Rigidbody2D>().velocity.x;
            float currentSpeedY = gameObject.GetComponent<Rigidbody2D>().velocity.y;
            bool isLowOnSpeed = (currentSpeedY < 0.1f && currentSpeedY > -0.1f) && (currentSpeedX < 0.1f && currentSpeedX > -0.1f);

            float angledifference = Vector2.Angle(Vector2.up, transform.up);
            bool isAngledCorrectly = angledifference < angleThreshold;

            if (isLowOnSpeed && isAngledCorrectly)
            {
                //Aca ganas la partida
            }
            else
            {
                //Aca explota el jugador al pingo
            }
        }
        else
        {
            //Aca explota el jugador al pingo
        }
    }
}
