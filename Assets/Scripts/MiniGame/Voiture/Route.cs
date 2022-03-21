using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public float speed;
    bool canDuplicate = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        if(transform.position.z <= 100 && canDuplicate)
        {
            Route newRoad = Instantiate(this);
            newRoad.transform.position = new Vector3(transform.position.x, transform.position.y, 690);
            canDuplicate = false;
        }
        if(transform.position.z < -300)
        {
            Destroy(this.gameObject);
        }
    }
}
