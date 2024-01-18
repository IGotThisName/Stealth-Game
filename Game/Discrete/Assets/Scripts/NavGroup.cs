using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGroup : MonoBehaviour
{
    public Material lineMat;

    private List<GameObject> navPoints = new List<GameObject>();
    private List<Vector3> groundPoints = new List<Vector3>();

    private RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
        foreach (Transform childTransform in transform)
        {
            navPoints.Add(childTransform.gameObject);
        }

        foreach (GameObject point in navPoints)
        {
            if (Physics.Raycast(point.transform.position, Vector3.down, out hit))
            {

                groundPoints.Add(hit.point);

            }
        }
        

        

        for (int i = 0; i < groundPoints.Count; i++)
        {

            LineRenderer lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
            lineRenderer.useWorldSpace = true;

            Vector3 currentPoint = groundPoints[i];
            Vector3 nextPoint;

            if (i < groundPoints.Count - 1)
            {
                nextPoint = groundPoints[i + 1];
            }
            else
            {
                nextPoint = groundPoints[0];
            }

            List<Vector3> linePoints = new List<Vector3>();

            linePoints.Add(currentPoint);
            linePoints.Add(nextPoint);

            lineRenderer.SetPositions(linePoints.ToArray());
            
            // VISUALS YIPPEEE
            lineRenderer.startColor = Color.blue;
            lineRenderer.endColor = Color.blue;

            lineRenderer.material = lineMat;
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;

            lineRenderer.enabled = true;

        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
