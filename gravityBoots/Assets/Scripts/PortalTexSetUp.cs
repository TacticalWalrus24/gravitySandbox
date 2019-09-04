using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTexSetUp : MonoBehaviour
{
    [SerializeField]
    Camera camA;
    [SerializeField]
    Material camA_Mat;
    [SerializeField]
    Camera camB;
    [SerializeField]
    Material camB_Mat;
    // Start is called before the first frame update
    void Start()
    {
        if (camA.targetTexture != null)
        {
            camA.targetTexture.Release();
        }

        camA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camA_Mat.mainTexture = camA.targetTexture;

        if (camB.targetTexture != null)
        {
            camB.targetTexture.Release();
        }

        camB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camB_Mat.mainTexture = camB.targetTexture;
    }
}
