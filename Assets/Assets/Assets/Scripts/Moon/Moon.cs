using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{

    public GameObject moon;
    // Start is called before the first frame update
    void Start()
    {
        moon = GameObject.FindGameObjectWithTag("Moon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        moon.transform.RotateAround(moon.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
