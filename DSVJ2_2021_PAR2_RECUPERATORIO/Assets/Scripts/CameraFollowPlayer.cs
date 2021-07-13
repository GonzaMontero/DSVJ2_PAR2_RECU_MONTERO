using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float offset;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
