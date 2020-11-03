using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject planet;
    // Start is called before the first frame update
    Rigidbody character_body;    //キャラの重力
    float jumpspeed=25.0f;    //ジャンプのスピード
    float walkspeed=60.0f;      //歩くはさや
    float throwspeed=30.0f;    //投げる強さ
    public GameObject deadStateObject;//死んだ後のオブジェクト
    public bool isLive =true;  //生きているかどうか
    GameObject carryCollider;   //アイテム持ち上げコライダの起動
    public bool isHaveItem = false;    //アイテムを持っているかどうか
    int jumpCountMax = 1;  //ジャンプの最大回数
    int jumpCount =1;   //ジャンプの可能回数
    private GameObject holdingObject;
    void Start()
    {
        float x = Input.GetAxisRaw("Horizontal");
        character_body=this.GetComponent<Rigidbody>();
        carryCollider=transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        //ジャンプ処理
        if(Input.GetKeyDown(KeyCode.W)){
            if(jumpCount>0){
            jumpCount--;
            character_body.velocity +=this.transform.up*jumpspeed;
            }
            Debug.Log(jumpCount);
        }
        //移動
        if(Input.GetKey(KeyCode.D)){
            character_body.AddForce(this.transform.right*walkspeed);
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(Input.GetKey(KeyCode.A)){
            
            character_body.AddForce((-1)*this.transform.right*walkspeed);
            this.transform.localScale=new Vector3(1,1,1);;
        }
        //速度調整
        if(character_body.velocity.magnitude>20.0f){
            character_body.velocity=character_body.velocity.normalized*20.0f;
        }


        //アイテムを拾う・投げる
        carryCollider.SetActive(false);
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isHaveItem){
                //投げる
                if(holdingObject.GetComponent<BoxCollider>()!=null){
                    holdingObject.GetComponent<BoxCollider>().enabled=true;;
                }else if(holdingObject.GetComponent<CapsuleCollider>()!=null){
                    holdingObject.GetComponent<CapsuleCollider>().enabled=true;
                } 
                transform.GetChild(1).gameObject.GetComponent<Rigidbody>().velocity 
                    = (-1.0f)*this.transform.right*this.transform.localScale.x*(throwspeed+character_body.velocity.magnitude/4.0f);
                transform.GetChild(1).gameObject.transform.parent=null;
                isHaveItem=false;
                holdingObject= null;
            }else{
                //拾う
                carryCollider.SetActive(true);

            }
        }
        //持てる数を一つにする
        if(this.transform.childCount>=3){
            while(this.transform.childCount>=2){
                transform.GetChild(2).gameObject.transform.parent=null;
            }
        }
        //持ったオブジェクトを頭上に構える
        if(this.transform.childCount>=2){
            holdingObject= transform.GetChild(1).gameObject;
            if(holdingObject.GetComponent<BoxCollider>()!=null){
                holdingObject.GetComponent<BoxCollider>().enabled=false;
            }else if(holdingObject.GetComponent<CapsuleCollider>()!=null){
                holdingObject.GetComponent<CapsuleCollider>().enabled=false;;
            } 
            holdingObject.transform.position
                =  this.transform.position + this.transform.up*1.4f;
        }
        //死亡処理
        if(!isLive){
            Instantiate(deadStateObject, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision col) {
        if(!col.gameObject.CompareTag("Player"))
		jumpCount=jumpCountMax;
    }
}
