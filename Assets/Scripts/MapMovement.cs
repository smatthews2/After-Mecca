using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

public class MapMovement : MonoBehaviour
{
    [SerializeField] new private Camera camera;
    private string groundTag = "Ground";
    [SerializeField]private GameObject playerIcon;
    private RaycastHit hit;
    private Vector3 destination;

    [Header("Points for line 1")]
    public Vector2 pointA;
    public Vector2 pointB;
    [Header("Points for line 2")]
    public Vector2 pointX;
    public Vector2 pointY;

    // Start is called before the first frame update
    void Start()
    {
        destination = SelectPoint();
    }

    // Update is called once per frame
    void Update()
    {
        playerIcon.transform.position = Vector3.MoveTowards(playerIcon.transform.position, destination, 3.0f);
    }

    private void OnMouseDown()
    {
        destination = SelectPoint();
    }

    Vector3 SelectPoint() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition); // Draw a ray from the camera to where the mouse clicked.

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                return hit.point;
            }
        }

        return playerIcon.transform.position;
    }
}
