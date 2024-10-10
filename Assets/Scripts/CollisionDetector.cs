using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter3D(Collider other)
    {
        Debug.Log("USED");
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
