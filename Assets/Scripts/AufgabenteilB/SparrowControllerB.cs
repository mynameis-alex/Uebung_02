using UnityEngine;

public class SparrowControllerB : MonoBehaviour
{

    [Range(-180, 180)]
    [Tooltip("Meter per second")]
    public float rotationSpeed = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //rotate around the vertical axis by 90 degrees and within one second
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
