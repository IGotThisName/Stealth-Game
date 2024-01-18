using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManageView : MonoBehaviour
{

    public enum ViewType { normal, thermal, viewzones }

    public ViewType currentView;

    // Start is called before the first frame update
    void Start()
    {
        currentView = ViewType.normal;
        updateView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateView()
    {
        switch (currentView)
        {
            case ViewType.normal:
                break;

            case ViewType.thermal:
                break;

            case ViewType.viewzones:
                break;

            default:
                Debug.LogError("Invalid Input for currentView switch case. Debug immediately!");
                break;
        }
    }
}
