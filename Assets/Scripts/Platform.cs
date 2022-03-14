using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float moveSpeed;

    Vector3 nextPos;

    void Awake(){
        nextPos = start.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position == start.position)
        {
            nextPos = end.position;
        }
        if(transform.position == end.position)
        {
            nextPos = start.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
        
    }


    private void OnDrawGizmos(){
        Gizmos.DrawLine(start.position,end.position);
    }
}

