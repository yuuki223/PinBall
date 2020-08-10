using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointText : MonoBehaviour
{
        private GameObject scoreText;
　　　　　private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
         this.scoreText = GameObject.Find("ScoreText");
         score = 0;
         SetScore();
 
  }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
         string tag = collision.gameObject.tag;

　　　　　　if (tag == "SmallStarTag")
             {
                score += 5;
             }
         if (tag == "SmallCloudTag")
             {
                score += 10;
             }
         if (tag == "LargeStarTag")
             {
                score += 15;
             }
         if (tag == "LargeCloudTag")
             {
                score += 20;
             }
         SetScore();
    }

    void SetScore()
    {
         this.scoreText.GetComponent<Text>().text=string.Format("Score:{0}",score);
    }
}
