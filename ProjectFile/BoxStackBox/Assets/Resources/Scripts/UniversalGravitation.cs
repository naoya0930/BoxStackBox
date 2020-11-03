using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour
{
    public static float G = 120.0f; //万有引力定数の定義
    Rigidbody rocket_body;
    public GameObject planet; //Unity上でロケットにあたるものをドラッグ＆ドロップ
    Rigidbody planet_body;
    Vector3 normal;
    //常に惑星から見て上を向くか
    public bool setHorizonal;//
    // Start is called before the first frame update
    void Start()
    {
        rocket_body = this.GetComponent<Rigidbody>(); //
        planet_body = planet.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec_direction = planet.transform.position - this.transform.position; //ロケットから見た惑星の位置
        Vector3 Univ_gravity = G * vec_direction.normalized * (planet_body.mass * rocket_body.mass) / (vec_direction.sqrMagnitude); //万有引力の計算
        rocket_body.AddForce(Univ_gravity); //ロケットに万有引力を掛ける
        if(setHorizonal){
            normal = this.transform.position-planet.transform.position;         //上向きベクトルを設定
            transform.rotation = Quaternion.FromToRotation(Vector3.up, normal); //キャラを上向きに固定
        }
    }
}
