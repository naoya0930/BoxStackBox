using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarryableColliderController : MonoBehaviour
{
    public bool flg=false;
    public GameObject carryableObject;
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
        if(col.gameObject.CompareTag("Carryable")){
            flg=true;
            col.gameObject.transform.parent=null;
            col.gameObject.transform.parent=this.gameObject.transform.parent;
            this.gameObject.transform.parent.gameObject.GetComponent<CharacterController>().isHaveItem=true;
        }else{
            flg=false;
        }
    }
}
