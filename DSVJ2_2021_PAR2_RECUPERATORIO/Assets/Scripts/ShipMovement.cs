using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float rotateSpeed;
    [SerializeField] float gravityScale;
    [SerializeField] float fuelConsumptionPerFrame;
    [SerializeField] GameObject particleSystem;
    float fuel;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = CalculateGravity();
        fuel = 1000;
    }

    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpForce);
                if (particleSystem.activeSelf)
                {
                    particleSystem.GetComponent<ParticleSystem>().Play();
                }
                else
                {
                    particleSystem.SetActive(true);
                }
                fuel -= fuelConsumptionPerFrame;
            }
            else
            {
                particleSystem.SetActive(false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(rotateSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(-rotateSpeed);
            }
        }
    }

    float CalculateGravity()
    {
        return (1 * gravityScale) / 9.81f;
    }

    public float ReturnFuel()
    {
        return fuel;
    }
}
