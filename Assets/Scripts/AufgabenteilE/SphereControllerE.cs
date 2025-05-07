using UnityEngine;

public class SphereControllerE : MonoBehaviour
{
    public GameObject bird;
    private SparrowControllerE birdController;

    private GameObject targetTree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        birdController = bird.GetComponent<SparrowControllerE>();
        
    }

    public void setTargetTree(GameObject tree) {
        targetTree = tree;
    }

    // Update is called once per frame
    void Update() {

        //move to tree
        if (targetTree != null) {

            //check if target is reached, then start rotating around it; else move towards it
            if (
                Mathf.Abs(transform.position.x - targetTree.transform.position.x) < 0.1 &&
                Mathf.Abs(transform.position.z - targetTree.transform.position.z) < 0.1
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
        if (birdController.getIsRotating() == true) {
            birdController.toggleRotating();
        }
        
        //pos of target without changing Y
        Vector3 zielPositionOhneY = new Vector3(
            targetTree.transform.position.x,
            transform.position.y,
            targetTree.transform.position.z
        );
        //where to go
        Vector3 direction = (zielPositionOhneY - transform.position).normalized;
        //move
        transform.position += direction * birdController.flySpeed * Time.deltaTime;

    }

    void circleTarget() {
        
        //toggle rotation once
        if (birdController.getIsRotating() == false) {
            birdController.toggleRotating();
        }

        //rotate around the vertical axis by 90 degrees and within one second
        //to circle the tree which is at the same spot
        transform.Rotate(Vector3.up * birdController.rotationSpeed * Time.deltaTime);
    }

}
