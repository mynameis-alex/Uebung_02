using UnityEngine;

public class SphereControllerD : MonoBehaviour
{
    public GameObject bird;
    private SparrowControllerD controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        controller = bird.GetComponent<SparrowControllerD>();
        
        //rotate bird depending on direction
        if (controller.rotationSpeed < 0) {
            bird.transform.Rotate(0, 180, 0);
        }

    }

    // Update is called once per frame
    void Update() {

        //rotate around the vertical axis by 90 degrees and within one second
        transform.Rotate(Vector3.up * controller.rotationSpeed * Time.deltaTime);
        
    }
}
