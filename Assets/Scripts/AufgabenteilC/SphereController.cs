using UnityEngine;

public class SphereController : MonoBehaviour
{

    public GameObject bird;
    private SparrowControllerC controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        controller = bird.GetComponent<SparrowControllerC>();
    }

    // Update is called once per frame
    void Update() {
        //rotate around the vertical axis by 90 degrees and within one second
        transform.Rotate(Vector3.up * controller.rotationSpeed * Time.deltaTime);
    }
}
