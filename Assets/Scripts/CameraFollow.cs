using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothness = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            var pos = target.position;
            pos.z = transform.position.z;
            pos.y += 1;

            transform.position = Vector3.Lerp(transform.position, pos, 1 - smoothness);
            
        }
    }
}
