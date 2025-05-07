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
    private Boolean clockwise = true;

    public Boolean getIsRotating() {
        return isRotating;
    }

    public void toggleRotating() {
        isRotating = !isRotating;
    }

}
