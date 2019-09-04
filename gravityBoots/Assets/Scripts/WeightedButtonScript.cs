using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedButtonScript : MonoBehaviour
{
    [SerializeField]
    float weightLimit = 1;

    float impulseTrigger;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (weightLimit <= impulseTrigger)
        {
            if (!activated)
            {
                StartCoroutine("Activate");
            }

        }
        else if (activated)
        {
            StartCoroutine("Deactivate");
        }
        impulseTrigger = 0;
    }

    private void OnCollisionStay(Collision collision)
    {
        impulseTrigger = collision.impulse.y;
    }

    private void OnCollisionExit(Collision collision)
    {
        impulseTrigger = collision.impulse.y;
    }

    IEnumerator Activate()
    {
        activated = true;
        while (transform.localPosition.y > -1)
        {
            transform.GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, -1 * Time.deltaTime, transform.position.x));

            yield return new WaitForFixedUpdate();
        }
        Debug.Log("trigger");
        Debug.Log(impulseTrigger);
    }

    IEnumerator Deactivate()
    {
        activated = false;
        while (transform.localPosition.y < 0)
        {
            transform.GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, 1 * Time.deltaTime, transform.position.x));

            yield return new WaitForFixedUpdate();
        }
        Debug.Log("untrigger");
        Debug.Log(impulseTrigger);
    }

}
