using UnityEngine;

public class SparrowControllerD : MonoBehaviour {

    [Range(-180, 180)]
    [Tooltip("Meter per second")]
    public float rotationSpeed = 90;
    public GameObject bird;
    bool turned = false;

    void OnValidate() {
       
        if ((rotationSpeed < 0) && (!turned)) {
            bird.transform.Rotate(0, -180, 0);
            turned = true;
        }

        if ((rotationSpeed >= 0) && (turned)) {
            bird.transform.Rotate(0, 180, 0);
            turned = false;
        }
    }
}