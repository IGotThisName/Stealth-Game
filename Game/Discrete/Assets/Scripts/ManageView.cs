using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManageView : MonoBehaviour
{

    public enum ViewType { normal, thermal, viewzones }
    public ViewType currentView;

    [SerializeField] private Material enemyMat;
    [SerializeField] private Material enemyViewZone;
    [SerializeField] private Material detectionZoneOn;
    [SerializeField] private Material detectionZoneOff;

    // Start is called before the first frame update
    void Start()
    {
        currentView = ViewType.normal;
        UpdateView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateView()
    {

        ResetMaterials();

        switch (currentView)
        {
            case ViewType.normal:

                // do nothing lmao

                break;

            case ViewType.thermal:

                enemyMat.shader = Shader.Find("EnemyVision");

                break;

            case ViewType.viewzones:
                break;

            default:
                Debug.LogError("Invalid Input for currentView switch case. Debug immediately!");
                break;
        }
    }

    private void ResetMaterials()
    {

        enemyMat.shader = Shader.Find("Standard");


    }
}
