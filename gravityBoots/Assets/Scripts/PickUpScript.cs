using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    [SerializeField]
    Rigidbody hands;
    [SerializeField]
    float range = 5;

    bool holding = false;
    Transform objectHeld;
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray;
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E)){
            ray = new Ray(cam.position, cam.forward);

            if (Physics.Raycast(ray, out hit, range) && hit.transform.CompareTag("PickUp") && !holding)
            { // interactable object?
                objectHeld = hit.transform;
                objectHeld.position = hands.position;
                //objectHeld.GetComponent<Rigidbody>().useGravity = false;
                objectHeld.gameObject.AddComponent<FixedJoint>();
                objectHeld.gameObject.GetComponent<FixedJoint>().connectedBody = hands.GetComponent<Rigidbody>();
                holding = true;
            }
            else if (holding)
            {
                //objectHeld.GetComponent<Rigidbody>().useGravity = true;
                Destroy(objectHeld.gameObject.GetComponent<FixedJoint>());
                holding = false;

            }
        }
    }
}
