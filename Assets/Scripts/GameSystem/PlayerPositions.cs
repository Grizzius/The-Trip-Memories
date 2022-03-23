using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerPositions : MonoBehaviour
{
    public static PlayerPositions current;
    public List<Vector3> playerPositionList;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        int i = 0;
        foreach(Vector3 position in playerPositionList)
        {
            Gizmos.DrawWireSphere(position, 0.1f);
            GUI.color = Color.cyan;
            Handles.Label(position, i.ToString());

            i++;
        }
    }

    public void MovePlayer(int positionID)
    {
        Vector3 vector3 = playerPositionList[positionID];

        if (PlayerScript.current)
        {
            PlayerScript.current.transform.position = vector3;
        }
        else
        {
            PlayerScript playerScript = FindObjectOfType<PlayerScript>();
            if (playerScript)
            {
                playerScript.transform.position = vector3;
            }
            
        }
        
        DefaultMode.playerPositionID = positionID;
    }
}
