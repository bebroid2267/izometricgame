using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform target;
    Vector3 targetPos;
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float smooth = 0.2f;
    private Vector3 velocity = Vector3.zero;

    public bool isNeed = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isNeed)
        {
            MoveWithTarget();
        }
    }
    void MoveWithTarget()
    {
        targetPos = target.transform.position + offsetPos;
        //transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime* smooth);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smooth);
    }
}
