using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followWP : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;

    void Start()
    {

    }


    void Update()
    {

        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
        {
            currentWP++;
        }

        if (currentWP >= waypoints.Length)
        {
            currentWP = 0;
        }

        this.transform.LookAt(waypoints[currentWP].transform);
        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
