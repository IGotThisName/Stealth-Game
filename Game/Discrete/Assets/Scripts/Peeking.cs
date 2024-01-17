using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeking : MonoBehaviour
{
    public KeyCode m_leftPeek;
    public KeyCode m_rightPeek;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftPeek(getTransform());
        RightPeek(getTransform());
    }

    Transform getTransform()
    {
        return transform;
    }

    private bool rotated = false;

    // Left Peek
    void LeftPeek(Transform transform)
    {
        if (Input.GetKeyDown(m_leftPeek) && rotated == false)
        {
            transform.Rotate(0, 0, 20);
            rotated = true;
        }
        else if (Input.GetKeyUp(m_leftPeek))
        {
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
            rotated = false;
        }
    }

    // Right Peek

    void RightPeek(Transform transform)
    {
        if (Input.GetKeyDown(m_rightPeek) && rotated == false)
        {
            transform.Rotate(0, 0, -20);
            rotated = true;
        }
        else if (Input.GetKeyUp(m_rightPeek))
        {
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
            rotated = false;
        }
    }
}
