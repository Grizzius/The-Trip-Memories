using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float movementSpeed;

    public Vector2 playerPosClamp;

    public float damageImunityDuration;

    bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Move();
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        
    }

    private void Move()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        transform.position += new Vector3(inputDirection.x, inputDirection.y, 0) * movementSpeed * Time.deltaTime;

        //Déplace le joueur dans une position clampée
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(transform.position.x, -playerPosClamp.x, playerPosClamp.x);
        clampedPosition.y = Mathf.Clamp(transform.position.y, -playerPosClamp.y, playerPosClamp.y);

        transform.position = clampedPosition;

        //Oriente l'avion selon s'il monte ou descent
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            Debug.Log("down");
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0.1f, 0, 0, 1), 10f*Time.deltaTime);
        } 
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            Debug.Log("Up");
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(-0.1f, 0, 0, 1), 10f*Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, 0, 0, 1), 1f * Time.deltaTime);
        }
    }

    public void TakeDamage()
    {
        if (canTakeDamage)
        {
            EventSystem.current.PlaneCollision();
            print("Damage");
            StartCoroutine(DamageEffect());
        }
        
    }

    IEnumerator DamageEffect()
    {
        canTakeDamage = false;

        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        for(float f = 0; f < damageImunityDuration; f += 0.075f)
        {
            meshRenderer.enabled = false;
            yield return new WaitForSeconds(0.075f);
            meshRenderer.enabled = true;
            yield return new WaitForSeconds(0.075f);
        }

        canTakeDamage = true;
    }
}
