using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

        //HingeJointコンポーネントを入れる
        private  HingeJoint myHingeJoint;

        //初期の傾き　
　　　　　private float defaultAngle = 20;
       //弾いたときの傾き
　　　　  private float flickAngle = -20;
        //左フリッパーを上げた時のfingerId
        private int leftId;
        //右フリッパーを上げた時のfingetId
        private int rightId;
        
	// Use this for initialization
	void Start () {
	       //HingeJointコンポーネント取得
               this.myHingeJoint = GetComponent<HingeJoint>();

               //フリッパーの傾き設定
               SetAngle(this.defaultAngle);
               
              	
	}
	
	// Update is called once per frame
	void Update (){
　　　　　　　　　　

               //左矢印キーを押した時左フリッパーを動かす
               if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
               SetAngle (this.flickAngle);
               }
               //右矢印キーを押した時右フリッパーを動かす
　　　　　　　　　 if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
               SetAngle (this.flickAngle);
               }

               //矢印キー離された時フリッパーを元に戻す
               if (Input.GetKeyUp(KeyCode.LeftArrow) && tag  == "LeftFripperTag"){
               SetAngle (this.defaultAngle);
               }
               if (Input.GetKeyUp(KeyCode.RightArrow) && tag  == "RightFripperTag"){
               SetAngle (this.defaultAngle);
               }
 
                 //画面の左半分をタッチしたら左のフリッパーを上げる
              for (int i = 0; i <Input.touchCount; i++)                                                   
              {
　　　　　　　　　if (Input.touches[i].phase==TouchPhase.Began&&Input.touches[i].position.x<=Screen.width/2 && tag == "LeftFripperTag")
              {
                    leftId = Input.touches[i].fingerId;
            　　　　var pos = Input.touches[i].position;
              　　 SetAngle (this.flickAngle);
               　　Debug.LogFormat("左上げ{0} - x:{1}, y:{2}", leftId, pos.x, pos.y);
              }

               //タッチした指を離したら左フリッパーを下げ
                 if (Input.touches[i].phase == TouchPhase.Ended && Input.touches[i].position.x <= Screen.width / 2 && tag == "LeftFripperTag")
                 {
                    SetAngle(this.defaultAngle);
                    Debug.Log("左下げ");

                 }
              }
　　　　　　　　　//画面右半分をタッチしたら右のフリッパーを上げる
              for (int i = 0; i <Input.touchCount; i++)
              {
              if (Input.touches[i].phase==TouchPhase.Began&&Input.touches[i].position.x>=Screen.width/2&& tag ==  "RightFripperTag")  
              {
                  rightId = Input.touches[i].fingerId;
            　  　var pos = Input.touches[i].position;
                  SetAngle (this.flickAngle);
                 Debug.LogFormat("右上げ{0} - x:{1}, y:{2}", rightId, pos.x, pos.y);
               }
　　　　　　　　　//タッチした指を離したら右フリッパーを下げる
                 if( Input.touches[i].phase == TouchPhase.Ended && Input.touches[i].position.x >= Screen.width / 2 && tag == "RightFripperTag")
                  {    
                       SetAngle (this.defaultAngle);
　　　　　　　　　　　　      Debug.Log("右下げ");
                          
                   }
              }

　　　　　　　　
     　　}


          
        //フリッパーの傾き設定
        public void SetAngle (float angle)
　　　　　{
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        } 
}





