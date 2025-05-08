using System;
using UnityEngine;

public class TreeControllerE : MonoBehaviour
{

    private float frequence = 1;
    private float maxScale = 10;
    private Vector3 origScale;

    private Boolean isGrowing = false;

    void Start() {
        origScale = transform.localScale;
    }

    public void startGrowing(float speed, float maxSize) {
        frequence = speed;
        maxScale = maxSize;
        isGrowing = true;
    }

    void Update() {

       if (!isGrowing) {
           return;
       }

        float sinusValue = Mathf.Sin(2 * Mathf.PI * frequence * Time.time);
        float factor = Mathf.Lerp(1f, maxScale, (sinusValue + 1f) * 0.5f);
        transform.localScale = origScale * factor;

        //check if max scale is reached (including a threshold of 0.05) and deactivate tree then
         if (transform.localScale.x >= (maxScale * origScale.x * 0.95)) {
            gameObject.SetActive(false);
            isGrowing = false;
        }

    }
}