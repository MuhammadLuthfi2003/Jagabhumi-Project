using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoMove : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] Vector3 cameraMoveDistance;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += (cameraSpeed * Time.deltaTime) / 30;

        Camera.main.transform.position += new Vector3(cameraMoveDistance.x * timer, cameraMoveDistance.y * timer, cameraMoveDistance.z * timer);
    }
}
