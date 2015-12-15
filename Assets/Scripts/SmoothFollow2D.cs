using UnityEngine;

using System.Collections;



public class SmoothFollow2D : MonoBehaviour
{

    public Transform target;
    float smoothTime = 1f;
    private Transform thisTransform;
    private Vector2 velocity;
    float yOffset = 0.3f;
    public bool useSmoothing = true;
    public bool enabled;

    void Start()
    {

        thisTransform = transform;
        velocity = new Vector2(0.5f, 0.5f);

    }



    void Update()
    {
        if (!enabled)
            return;

        Vector2 newPos2D = Vector2.zero;
        if (useSmoothing)
        {
            newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
            newPos2D.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y + yOffset, ref velocity.y, smoothTime);

        }
        else
        {
            newPos2D.x = target.position.x;
            newPos2D.y = target.position.y + yOffset;
        }
        Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
    }

}