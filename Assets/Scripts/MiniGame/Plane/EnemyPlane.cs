using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    Vector2 normalizedDirection;

    // Start is called before the first frame update
    void Start()
    {
        normalizedDirection = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(normalizedDirection.x, normalizedDirection.y, 0) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaneController player = other.transform.GetComponent<PlaneController>();
        player.TakeDamage();
    }
}
