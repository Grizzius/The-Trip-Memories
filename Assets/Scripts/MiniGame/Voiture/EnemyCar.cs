using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);

        if(transform.position.z < 10)
        {
            print("Destroy car");
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        CarController carController = other.GetComponent<CarController>();
        if (carController)
        {
            if (carController.canCollide)
            {
                EventSystem.current.CarCollision();
            }
        }
    }
}
