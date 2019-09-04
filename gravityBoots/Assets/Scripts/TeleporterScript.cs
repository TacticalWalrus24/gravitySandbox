﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    [SerializeField]
    Transform teleObject;
    [SerializeField]
    Transform exit;

    private bool isOverlapping = false;
    // Update is called once per frame
    void Update()
    {
        if (isOverlapping)
        {
            Vector3 portalToPlayer = teleObject.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log(dotProduct);
            if (dotProduct < 0)
            {
                float rotDiff = -Quaternion.Angle(transform.rotation, exit.rotation);
                rotDiff += 180;
                teleObject.Rotate(teleObject.up, rotDiff);

                Vector3 posOffset = Quaternion.Euler(0, rotDiff, 0) * portalToPlayer;
                teleObject.position = exit.position + posOffset;

                isOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        teleObject = other.transform;
        isOverlapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        teleObject = null;
        isOverlapping = false;
    }
}
