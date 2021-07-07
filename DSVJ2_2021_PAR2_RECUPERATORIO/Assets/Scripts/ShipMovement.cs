using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float rotateSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateShip(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateShip(-rotateSpeed);
        }
    }

    void RotateShip(float rotateSpeed)
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }
}
