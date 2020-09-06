using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> targetPoints;
    GameObject nextTarget;
    private int currentTargetPointIndex;
    [SerializeField] float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        if(targetPoints.Count > 0){
            nextTarget = targetPoints[0];
            currentTargetPointIndex=0;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(nextTarget != null){
            MoveToPosition(nextTarget);
        }
    }

    private void MoveToPosition(GameObject moveToTarget){
        
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.fixedDeltaTime);
        if(gameObject.transform.position == moveToTarget.transform.position) {
            ChangeTarget();
        }   
    }

    private void ChangeTarget(){
        currentTargetPointIndex++;
        if(currentTargetPointIndex >= targetPoints.Count){
            currentTargetPointIndex = 0;
        }
        
        while(targetPoints[currentTargetPointIndex] == null){
            currentTargetPointIndex++;
            if(currentTargetPointIndex >= targetPoints.Count){
                currentTargetPointIndex = 0;
            }
        }
        nextTarget = targetPoints[currentTargetPointIndex];
        
    }
}
