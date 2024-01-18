using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManageView : MonoBehaviour
{

    public enum ViewType { normal, thermal, viewzones, paths }
    public ViewType currentView;

    [SerializeField] private Material enemyMat;
    [SerializeField] private Material enemyViewZone;
    [SerializeField] private Material detectionZoneOn;
    [SerializeField] private Material detectionZoneOff;
    [SerializeField] private Material lineMat;

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

                Color viewZone = enemyViewZone.color;
                viewZone.a = 0.5f;
                enemyViewZone.color = viewZone;

                Color eVZ = detectionZoneOn.color;
                eVZ.a = 0.5f;
                detectionZoneOn.color = eVZ;

                Color dVZ = detectionZoneOff.color;
                dVZ.a = 0.5f;
                detectionZoneOff.color = dVZ;

                break;

            case ViewType.paths:

                Color lineColor = lineMat.color;
                lineColor.a = 1f;
                lineMat.color = lineColor;

                lineMat.shader = Shader.Find("lineThroughWall");

                break;

            default:
                Debug.LogError("Invalid Input for currentView switch case. Debug immediately!");
                break;
        }
    }

    private void ResetMaterials()
    {

        enemyMat.shader = Shader.Find("Standard");

        Color viewZone = enemyViewZone.color;
        viewZone.a = 0;
        enemyViewZone.color = viewZone;

        Color eVZ = detectionZoneOn.color;
        eVZ.a = 0;
        detectionZoneOn.color = eVZ;

        Color dVZ = detectionZoneOff.color;
        dVZ.a = 0;
        detectionZoneOff.color = dVZ;

        Color lineColor = lineMat.color;
        lineColor.a = 0f;
        lineMat.color = lineColor;

        lineMat.shader = Shader.Find("Standard");

    }
}
