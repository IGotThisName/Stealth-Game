using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripWire : MonoBehaviour
{

    private EnemyManager enemyManager;
    private bool enabled = true;

    public Material enabledMat;
    public Material disabledMat;
    public GameObject trip;

    public float enableTime;

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
            trip.GetComponent<Renderer>().material = enabledMat;
        }
        else
        {
            // green
            trip.GetComponent<Renderer>().material = disabledMat;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enabled == true)
        {
            enemyManager.AllEnemyAlert();
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
