using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controllers : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserStartWidth = 0.05f;
    public float laserEndWidth = 0f;
    public float laserMaxLength;

    public bool triggerRight;
    public bool triggerLeft;

    public GameObject colorTarget;

    public GameObject orangeCube;
    public GameObject yellowCube;
    public GameObject greenCube;
    public GameObject purpleCube;
    public GameObject blueCube;
    public GameObject redCube;

    private GameObject objectHit;

    // Start is called before the first frame update
    void Start()
    {
        laserLineRenderer = this.GetComponent<LineRenderer>();
        laserLineRenderer.startWidth = laserStartWidth;
        laserLineRenderer.endWidth = laserEndWidth;
        laserMaxLength = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        triggerRight = OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        triggerLeft = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

        RaycastHit hitt;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitt, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitt.distance, Color.yellow);
            if (hitt.collider.tag == "orangeCube")
            {
                colorTarget = orangeCube;
            }
            else if (hitt.collider.tag == "yellowCube")
            {
                colorTarget = yellowCube;
            }
            else if (hitt.collider.tag == "greenCube")
            {
                colorTarget = greenCube;
            }
            else if (hitt.collider.tag == "blueCube")
            {
                colorTarget = blueCube;
            }
            else if (hitt.collider.tag == "purpleCube")
            {
                colorTarget = purpleCube;
            }
            else if (hitt.collider.tag == "redCube")
            {
                colorTarget = redCube;
            }
            else if (hitt.collider.tag == "canvas" && triggerRight)
            {
                objectHit = hitt.transform.gameObject;
                objectHit.GetComponent<Renderer>().material.color = colorTarget.GetComponent<Renderer>().material.color;
            }
            else if (hitt.collider.tag == "environment")
            {
                yellowCube.GetComponent<Outline>().enabled = false;
                orangeCube.GetComponent<Outline>().enabled = false;
                greenCube.GetComponent<Outline>().enabled = false;
                blueCube.GetComponent<Outline>().enabled = false;
                purpleCube.GetComponent<Outline>().enabled = false;
                redCube.GetComponent<Outline>().enabled = false;
                colorTarget.GetComponent<Outline>().enabled = false;
            }
        }   

        if (triggerRight)
        {
            ShootLaserFromTargetPosition(transform.position, transform.TransformDirection(Vector3.forward), laserMaxLength);
            laserLineRenderer.enabled = true;
        }
        else { laserLineRenderer.enabled = false; }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
