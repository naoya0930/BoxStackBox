using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EndExplotion(){
        Destroy(transform.parent.gameObject);
    }
}
