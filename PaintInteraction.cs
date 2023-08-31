using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintInteraction : MonoBehaviour
{
    // Variables for left hand
    public GameObject lefthand;
    private Vector3 LHandRot;

    // Variables for right hand
    public GameObject righthand;

    public Controllers controller_scipt;
    public GameObject colorTarget;

    public GameObject currentColor;

    private float calcDistance;
    public float armMax;
    public float armMin;
    public float LeftHandRotRight;
    public float LeftHandRotLeft;

    public bool activate;
    public bool pull;

    private GameObject[] canvasCubes;

    // Start is called before the first frame update
    void Start()
    {
        activate = false;
        pull = false;
    }

    // Update is called once per frame
    void Update()
    {
        colorTarget = controller_scipt.colorTarget;

        calcDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("mixamoLeftArm").transform.position, GameObject.FindGameObjectWithTag("mixamoLeftHand").transform.position);

        LHandRot = lefthand.transform.eulerAngles;

        wipeBoard();

        if (calcDistance > armMax && colorTarget != null)
        {
            activate = true;
            ShowActivation();
        }
        if (calcDistance < armMin && activate)
        {
            pull = true;
        }
        if (pull)
        {
            if (colorTarget.name == "OrangeCube")
            {
                currentColor.GetComponent<Renderer>().material.color = new Color32(255, 127, 0, 255);
            }
            else if (colorTarget.name == "YellowCube")
            {
                currentColor.GetComponent<Renderer>().material.color = new Color32(245, 245, 0, 255);
            }
            else if (colorTarget.name == "GreenCube")
            {
                currentColor.GetComponent<Renderer>().material.color = new Color32(0, 220, 0, 255);
            }
            else if (colorTarget.name == "BlueCube")
            {
                currentColor.GetComponent<Renderer>().material.color = new Color32(0, 0, 220, 255);
            }
            else if (colorTarget.name == "PurpleCube")
            {
                currentColor.GetComponent<Renderer>().material.color = new Color32(127, 0, 255, 255);
            }
            else if (colorTarget.name == "RedCube")
            {
                currentColor.GetComponent<Renderer>().material.color = new Color32(220, 0, 0, 255);
            }
            activate = false;
            pull = false;
        }
    }

    void wipeBoard()
    {
        if (calcDistance > armMax && LHandRot.z > LeftHandRotRight)
        {
            canvasCubes = GameObject.FindGameObjectsWithTag("canvas");
            foreach (GameObject cube in canvasCubes)
            {
                cube.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
            }
        }
    }


    void ShowActivation()
    {
        if (colorTarget.name == "OrangeCube")
        {
            colorTarget.GetComponent<Outline>().enabled = true;
        }
        else if (colorTarget.name == "YellowCube")
        {
            colorTarget.GetComponent<Outline>().enabled = true;
        }
        else if (colorTarget.name == "GreenCube")
        {
            colorTarget.GetComponent<Outline>().enabled = true;
        }
        else if (colorTarget.name == "BlueCube")
        {
            colorTarget.GetComponent<Outline>().enabled = true;
        }
        else if (colorTarget.name == "PurpleCube")
        {
            colorTarget.GetComponent<Outline>().enabled = true;
        }
        else if (colorTarget.name == "RedCube")
        {
            colorTarget.GetComponent<Outline>().enabled = true;
        }
    }
}

