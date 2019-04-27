// This script is used for the pointer that allows the player to teleport to the different screens.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickAScreen : MonoBehaviour {

    // Shoot from this area.
	public GameObject rayCastStart;
    public LineRenderer myLineRenderer;

    public float laserWidth = 0.1f;
    public float laserMaxLength = 5;

    bool showLine = true;

     void OnEnable()
    {
        ScreenTeleporter.LeaveSecurity += EndShowLine;
        ScreenTeleporter.GoToSecurity += StartShowLine;
    }
    
    
    void OnDisable()
    {
        ScreenTeleporter.LeaveSecurity -= EndShowLine;
        ScreenTeleporter.GoToSecurity -= StartShowLine;
    }

    void Start () {
        Vector3[] intiLaserPositions = new Vector3[2] {Vector3.zero, Vector3.zero};
        myLineRenderer.SetPositions(intiLaserPositions);
        myLineRenderer.SetWidth(laserWidth, laserMaxLength);
    }

    public void StartShowLine () {
        showLine = true;
        myLineRenderer.enabled = true;
    }

    public void EndShowLine () {
        showLine = false;
        myLineRenderer.enabled = false;
    }


	// Update is called once per frame
	void Update () {

        if (showLine) {

            Ray ray = new Ray(rayCastStart.transform.position, rayCastStart.transform.forward);
            
            RaycastHit hit;
            Vector3 endPosition = rayCastStart.transform.position + (rayCastStart.transform.forward * 10f); 

        
        // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            // Shoot a ray.
            if (Physics.Raycast(rayCastStart.transform.position, rayCastStart.transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(rayCastStart.transform.position, rayCastStart.transform.forward * hit.distance, Color.green);
                Debug.Log("Did Hit");
                endPosition = hit.point;
                if (SteamVR_Actions._default.InteractUI.GetState(SteamVR_Input_Sources.Any) ) {
                    if (hit.transform.gameObject.CompareTag("Screen")) {
                        hit.transform.gameObject.SendMessage("Teleport");
                    }
                }
            }
            else
            {
                Debug.DrawRay(rayCastStart.transform.position, rayCastStart.transform.forward * 1000, Color.red);
                Debug.Log("Did not Hit");
            }


            myLineRenderer.SetPosition(0, rayCastStart.transform.position);
            myLineRenderer.SetPosition(1, endPosition);
        }
	}
}
