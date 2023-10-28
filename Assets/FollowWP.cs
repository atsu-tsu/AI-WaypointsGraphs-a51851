using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{

    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
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


    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }

    //Estou a usar os mesmos nomes do tutorial para evitar enganos futuros, apesar de serem localizações diferentes no meu exercício.

    void Update()
    {
        
    }
}
