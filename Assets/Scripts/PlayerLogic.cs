using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] new private Camera camera;
    [SerializeField] private float Speed;
    private string groundTag = "Ground";
    private NavMeshAgent agent;
    private RaycastHit hit;
    

    // Called when a script is enabled
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
    }

    // Called once every frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition); // Draw a ray from the camera to where the mouse clicked.

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point); // Walk to where the mouse clicked if it hit the ground.
                }
            }
        }
    }
}
