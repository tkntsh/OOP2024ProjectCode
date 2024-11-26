using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastManager : MonoBehaviour
{
    //gameobjects needed to manager raycasting
    public Camera arCam;
    public GameObject radioBtn;
    public float raycastDist = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = arCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDist))
        {
            if(hit.collider.CompareTag("radio"))
            {
                radioBtn.SetActive(true);
            }
            else
            {
                radioBtn.SetActive(false);
            }
        }
        else
        {
            radioBtn.SetActive(false);
        }
    }
}
