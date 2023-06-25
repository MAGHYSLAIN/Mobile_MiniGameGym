using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class DeleteObject : MonoBehaviour
    {
    
        public GameObject prefab;
    
        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            DestroyIfBehindCamera(prefab);
        }
    
        void DestroyIfBehindCamera(GameObject obj)
        {
            if (obj != null)
            {
                // Get the main camera
                Camera mainCam = Camera.main;
                // Get the position of the object in world space
                Vector3 objectPos = obj.transform.position;
                // Get the position of the object in viewport space
                Vector3 viewportPos = mainCam.WorldToViewportPoint(objectPos);
                // Check if the object is behind the camera (viewport x, y values are between 0 and 1)
                if (viewportPos.z < 0)
                {
                    // Object is behind the camera, destroy it
                    DestroyImmediate(obj, true);
                }
            }
        }
    }
    
}
