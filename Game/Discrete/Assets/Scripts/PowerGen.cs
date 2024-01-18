using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGen : MonoBehaviour
{

    private EnemyManager enemyManager;
    private bool enabled = true;

    public Material OperationalMat;
    public Material ShutDownMat;
    public GameObject trip;

    public float enableTime;
    public GameObject inside;

    // Start is called before the first frame update

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            // red
            inside.GetComponent<Renderer>().material = OperationalMat;
        }
        else
        {
            // green
            inside.GetComponent<Renderer>().material = ShutDownMat;
        }
    }
    
    public void Disable()
    {
        enabled = false;

        Invoke("Enable", enableTime);
    }

    public void Enable()
    {
        enabled = true;
    }
}