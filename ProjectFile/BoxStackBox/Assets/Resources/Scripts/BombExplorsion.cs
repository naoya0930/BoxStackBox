using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombExplorsion : MonoBehaviour
{
    public float explosionSpeed = 20.0f;//爆発する最低速度
    public GameObject obj;
    private Rigidbody rigid;
    private Animator animator;

    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid=gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: 爆発のチェック
        if(active&&this.rigid.velocity.magnitude>=explosionSpeed){
             animator.SetBool("is_fire", true);
        }
    
    }
    public void Explosion(){
        //obj = Instantiate( Resources.Load("Explosion", typeof(GameObject) ) ) as GameObject;
        Instantiate(obj, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    void OnCollisionEnter(Collision col) {
        active = true;
        rigid.velocity=new Vector3(0,0,0);
    }
}
