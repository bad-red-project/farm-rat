using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public float smoothing = 0.5f;
    public Transform target;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void LateUpdate() {
        if (target == null && transform.position != target.position) { return; }

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    }
}