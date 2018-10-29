using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
    static private Slingshot S;

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 10f;
    public AudioClip slingShotClip;
    public AudioSource slingShotSource;
    public LineRenderer leftBand;
    public LineRenderer rightBand;
    public GameObject leftArm;
    public GameObject rightArm;

    [Header("Set Dynaically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public static bool aimingMode;
    private Rigidbody projectileRigidbody;


    static public Vector3 LAUNCH_POS{
        get{
            if(S == null){
                return Vector3.zero;
            }
            return S.launchPos;
        }
    }

	// Use this for initialization
	void Start () {
        leftBand.SetPosition(0, leftArm.transform.position);
        rightBand.SetPosition(0, rightArm.transform.position);

        leftBand.enabled = false;
        rightBand.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!aimingMode)
            return;
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude){
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if(Input.GetMouseButtonUp(0)){
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            //Play sling shot noise
            slingShotSource.Play();
            leftBand.enabled = false;
            rightBand.enabled = false;

            //Set POI of camera to projectile
            FollowCam.POI = projectile;
            projectile = null;

            MissionDemolition.ShotFired();
            ProjectileLine.S.poi = projectile;
        }



	}

    void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;


    }

    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }
    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseDown()
    {
        //the player presssed mouse button while over slingshot
        aimingMode = true;
        //instantiate projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //start projectile at launchpoint
        projectile.transform.position = launchPos;
        //set it to iskinematic 
        //projectile.GetComponent<Rigidbody>().isKinematic = true;

        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
        leftBand.enabled = true;
        rightBand.enabled = true;
        leftBand.SetPosition(0, leftArm.transform.position);
        rightBand.SetPosition(0, rightArm.transform.position);
        leftBand.SetPosition(1, projectile.transform.position);
        rightBand.SetPosition(1, projectile.transform.position);


    }

}
