using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Vector3 leftPosition;
    public Vector3 midlePosition;
    public Vector3 rightPosition;

    public float transitionSpeed;

    Vector3 currentPosition;
    Vector3 aimPosition;

    // Start is called before the first frame update
    void Start()
    {
        aimPosition = midlePosition;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(aimPosition);
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if (currentPosition == midlePosition)
                {
                    aimPosition = leftPosition;
                }
                else if (currentPosition == rightPosition)
                {
                    aimPosition = midlePosition;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if (currentPosition == midlePosition)
                {
                    aimPosition = rightPosition;
                }
                else if (currentPosition == leftPosition)
                {
                    aimPosition = midlePosition;
                }
            }
        }
        
    }

    void MovePlayer(Vector3 newPosition)
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * transitionSpeed);
        currentPosition = newPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(leftPosition, 1);
        Gizmos.DrawWireSphere(midlePosition, 1);
        Gizmos.DrawWireSphere(rightPosition, 1);
    }
}
