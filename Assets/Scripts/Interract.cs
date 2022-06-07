using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour
{
    public GameObject go = null;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.tag == "interractable" || hit.transform.gameObject.tag == "interractableHistory")
            {
                go = hit.transform.gameObject;
                go.GetComponent<Outline>().enabled = true;
            }
            else
            {
                if(go != null && go.GetComponent<Outline>())
                {
                    go.GetComponent<Outline>().enabled = false;
                    go = null;
                }
            }
        }
       
    }
}
