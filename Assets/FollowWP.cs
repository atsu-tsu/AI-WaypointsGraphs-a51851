using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{

    Transform goal;
    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;


    void Start()
    {

        wps = wpManager.GetComponent<WPManager>().waypoints;
        g= wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];

        Invoke("GoToRuin", 3);
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, wps[4]);
        currentWP = 0;
    }

    //Estou a usar os mesmos nomes do tutorial para evitar enganos futuros, apesar de serem localiza��es diferentes no meu exerc�cio.

    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWP == g.pathList.Count)
        {
            return;
        }

        if (Vector3.Distance(g.pathList[currentWP].getId().transform.position, this.transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].getId();
            currentWP++;
        }

        if (currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }


    }
}
