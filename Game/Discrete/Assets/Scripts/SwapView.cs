using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapView : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode swapViewKey;

    private ManageView viewManager;
    private int cvAsInt;
    private ManageView.ViewType[] viewTypes;

    void Start()
    {

        viewManager = FindObjectOfType<ManageView>();

        viewTypes[0] = ManageView.ViewType.normal;
        viewTypes[1] = ManageView.ViewType.thermal;
        viewTypes[2] = ManageView.ViewType.viewzones;

        cvAsInt = 0;

    }

    /* 
     * VIEW TYPE INDEX
     * 0 = normal
     * 1 = thermal
     * 2 = viewzones
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(swapViewKey))
        {
            if (cvAsInt < 2)
            {
                cvAsInt++;
            }
            else
            {
                cvAsInt = 0;
            }

            viewManager.currentView = viewTypes[cvAsInt];
            viewManager.updateView();
        }
    }
}
