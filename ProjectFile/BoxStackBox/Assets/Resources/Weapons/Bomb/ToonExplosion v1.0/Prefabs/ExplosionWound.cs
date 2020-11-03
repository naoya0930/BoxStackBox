using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionWound : MonoBehaviour
{
    public GameObject deadStateObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	}
    void OnTriggerEnter(Collider col) {
		Debug.Log(col.name + " : " + "Trigger");
        if(col.gameObject.CompareTag("Player")){
            CharacterController script =col.GetComponent<CharacterController>();
            script.isLive=!script.isLive;
        }
    }

    void EndExplotion(){
        Destroy(this.gameObject);
    }
}
