using System;
using UnityEngine;

public class SparrowControllerE : MonoBehaviour {

    [Range(-180, 180)]
    [Tooltip("Meter per second")]
    public float rotationSpeed = 12;

    [Range(1, 5)]
    [Tooltip("Meter per second")]
    public float flySpeed = 2;

    private Boolean isRotating = false;

    private GameObject targetTree;



    public void setTargetTree(GameObject tree) {
        targetTree = tree;
    }

    void Update() {

        //move to tree
        if (targetTree != null) {

            lookAt(targetTree);

            //check if target is reached, then start rotating around it; else move towards it
            if (
                Mathf.Abs(transform.position.x - targetTree.transform.position.x) < 3.54 &&
                Mathf.Abs(transform.position.z - targetTree.transform.position.z) < 3.54
            ) {
                circleTarget();
            } else {
                moveToTarget();
            }

        }
        
    }

    //called when sphere isn't at same spot as wanted tree and therefore starts moving there
    void moveToTarget() {

        //set rotation towards the sphere (only if it is switching to this function; not always!)
        if (isRotating == true) {
            isRotating = false;
        }
        
        //pos of target without changing Y
        Vector3 targetPos = new Vector3(
            targetTree.transform.position.x,
            transform.position.y, //keep y of bird, not of tree
            targetTree.transform.position.z
        );
        //where to go
        Vector3 direction = (targetPos - transform.position).normalized;
        //move
        transform.position += direction * flySpeed * Time.deltaTime;

    }

    void circleTarget() {
        
        //toggle rotation once
        if (!isRotating) {
            isRotating = true;
        }

        //rotate around the vertical axis by 90 degrees and within one second
        //to circle the tree which is at the same spot
        transform.RotateAround(
            targetTree.gameObject.transform.position,
            Vector3.up,
            rotationSpeed * Time.deltaTime
        );
    }

    void lookAt(GameObject target) {
        //smooth transition cause lookAt rotates object directly
        //source: https://discussions.unity.com/t/smooth-look-at/394528
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed / 10 * Time.deltaTime);
    }

}
