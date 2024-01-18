using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapView : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode swapViewKey;

    [SerializeField] private ManageView viewManager;
    private int cvAsInt;

    void Start()
    {

        cvAsInt = 0;

    }

    /* 
     * VIEW TYPE INDEX
     * 0 = normal
     * 1 = thermal
     * 2 = viewzones
     * 3 = paths
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(swapViewKey))
        {
            switch(cvAsInt)
            {
                case 0:
                    viewManager.currentView = ManageView.ViewType.normal;
                    cvAsInt++;
                    break;
                case 1:
                    viewManager.currentView = ManageView.ViewType.thermal;
                    cvAsInt++;
                    break;
                case 2:
                    viewManager.currentView = ManageView.ViewType.viewzones;
                    cvAsInt++;
                    break;
                case 3:
                    viewManager.currentView = ManageView.ViewType.paths;
                    cvAsInt = 0;
                    break;
            }

            viewManager.UpdateView();
        }
    }
}
