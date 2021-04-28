using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Kids : MonoBehaviour
{
    public float flollowSpeed = 1f;
    public float slowdownDistance = 1f;
    Vector3 velocisty = Vector2.zero;
    public Vector3 myPos2;
    public NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targettPosition = gameObject.transform.parent.gameObject.transform.position + new Vector3(Random.Range(0, 4), Random.Range(0, 4), 0);

        Vector3 kidDistance = (targettPosition - (Vector3)transform.position);
        Vector3 desireVelocity = kidDistance * flollowSpeed;
        Vector3 steering = desireVelocity - velocisty;

        velocisty += steering * Time.deltaTime;
        float slowdownFactor = Mathf.Clamp01(kidDistance.magnitude);
        velocisty *= slowdownFactor;
        transform.position += (Vector3)velocisty * Time.deltaTime;

    }
}
