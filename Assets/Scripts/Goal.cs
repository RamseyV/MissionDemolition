using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    //A static field accessible by code anywhere
    static public bool goalMet = false;


    private void OnTriggerEnter(Collider other)
    {
        //When the trigger is hit by somehting check to see if its a projectile
        if(other.gameObject.tag == "Projectile"){
            //if so, set goalMet to true
            Goal.goalMet = true;
            //Also set the alpha of the color to hgiher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
