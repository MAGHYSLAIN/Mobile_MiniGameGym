using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class FollowPlayer : MonoBehaviour
    {
    
        public Transform player;
        public Vector3 offset;
    
       
        void Update()
        {
            transform.position = player.position + offset;
        }
    }
    
}
