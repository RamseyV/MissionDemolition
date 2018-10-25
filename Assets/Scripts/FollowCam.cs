using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    static public GameObject POI; //point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f;


    [Header("Set Dynamically")]
    public float camZ;


    void Awake()
    {
        camZ = this.transform.position.z;

    }

    void FixedUpdate()
    {
        if(POI==null){
            return;
        }


        //Get POI position
        Vector3 destination = POI.transform.position;

        //Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        //force destination.z to be camZ to keep camera far enough away
        destination.z = camZ;

        //set the camera to the destination
        transform.position = destination;

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
