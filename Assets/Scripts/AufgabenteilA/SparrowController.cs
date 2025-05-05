using UnityEngine;

public class SparrowController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //rotate around the vertical axis by 90 degrees and within one second
        transform.Rotate(Vector3.up * 90 * Time.deltaTime);
    }
}
