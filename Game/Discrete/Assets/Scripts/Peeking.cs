using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeking : MonoBehaviour
{
    public KeyCode m_leftPeek;
    public KeyCode m_rightPeek;

    public GameObject player;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftPeek();
    }

    private bool rotated = false;
    private Vector3 axis;

    // Left Peek
    void LeftPeek()
    {
        if (Input.GetKeyDown(m_leftPeek) && rotated == false)
        {
            Vector3 rotatePoint = transform.position;
            rotatePoint.y -= 1;

            //axis = new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z);

            axis = Vector3.forward;

            Debug.Log(axis.ToString());

            transform.RotateAround(rotatePoint, axis, 15);
            rotated = true;
        }
        else if (Input.GetKeyUp(m_leftPeek))
        {
            Debug.Log("unpeeked");
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
            rotated = false;
        }
    }

    // Right Peek
}
