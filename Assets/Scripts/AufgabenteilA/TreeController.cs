using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float frequence = 1;

    public float maxScale = 1.1f;

    private Vector3 origScale;

    void Start() {
        origScale = transform.localScale;
    }

    void Update() {
        float sinusValue = Mathf.Sin(2 * Mathf.PI * frequence * Time.time);
        float factor = Mathf.Lerp(1f, maxScale, (sinusValue + 1f) * 0.5f);
        transform.localScale = origScale * factor;
    }
}