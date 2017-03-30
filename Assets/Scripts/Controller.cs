using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller: MonoBehaviour
{
    public OVRInput.Controller controller;

    private Vector3 grabDelta;
    private GameObject hoveredObject, grabbedObject;

    public float springConstant = 500f;
    public float friction = 100f;

    private void OnTriggerEnter(Collider collider)
    {
        if (hoveredObject == null)
            hoveredObject = collider.gameObject;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (hoveredObject == collider.gameObject)
            hoveredObject = null;
    }

    private void Start()
    {
        transform.position = OVRInput.GetLocalControllerPosition(controller);
    }

    private void Update()
    {
        transform.position = OVRInput.GetLocalControllerPosition(controller);
        transform.rotation = OVRInput.GetLocalControllerRotation(controller);

        //float trigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        //transform.localScale = Vector3.one * (0.05f + 0.1f * trigger);

        float grip = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        GetComponent<Renderer>().material.color = Color.red * grip + (1 - grip) * Color.blue;

        LogButtons();

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            GrabObject(hoveredObject);

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
            ReleaseObject();

        UpdateGrabbedObject();
    }

    private void UpdateGrabbedObject()
    {
        if (grabbedObject)
        {
            Vector3 dx = transform.position + grabDelta - grabbedObject.transform.position; 
            Rigidbody rigidbody = grabbedObject.GetComponent<Rigidbody>();
            Vector3 force = dx * springConstant - rigidbody.velocity * friction;
            rigidbody.velocity += force * rigidbody.mass * Time.deltaTime;
        }
    }

    private void LogButtons()
    {
        foreach (var button in Enum.GetValues(typeof(OVRInput.Button)))
        {
            if (OVRInput.GetDown((OVRInput.Button)button, controller))
                Debug.Log(controller.ToString() + " button down: " + button.ToString());

            if (OVRInput.GetUp((OVRInput.Button)button, controller))
                Debug.Log(controller.ToString() + " button up: " + button.ToString());
        }
    }

    private void GrabObject(GameObject obj)
    {
        grabbedObject = obj;
        if (obj)
            grabDelta = obj.transform.position - transform.position;
    }

    private void ReleaseObject()
    {
        grabbedObject = null;
        grabDelta = Vector3.zero;
    }
}
