using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollOn.Scripts{
    
    public class GroundSpawner : MonoBehaviour
    {
        public List<GameObject> grounds;
        private float offset = 250f;
    
        // Start is called before the first frame update
        void Start()
        {
            if(grounds != null && grounds.Count > 0) 
            {
                grounds = grounds.OrderBy(r => r.transform.position.z).ToList();
            }
        }
    
        public void MoveGround()
        {
            GameObject movedGround = grounds[0];
            grounds.Remove(movedGround);
            float newZ = grounds[grounds.Count - 1].transform.position.z + offset;
            movedGround.transform.position = new Vector3(0, 0.5f, newZ);
            grounds.Add(movedGround);
        }
    
        // Update is called once per frame
    
    
        public void SortGroundsAlphabetically()
        {
            if (grounds != null && grounds.Count > 0)
            {
                grounds = grounds.OrderBy(r => r.name).ToList();
            }
        }
    
        void Update()
        {
            
        }
    }
    
}
