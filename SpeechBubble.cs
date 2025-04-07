using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBubble : MonoBehaviour{
Vector3 trans1;//记录原位置
Vector2 trans2;//简谐运动变化的位置，计算得出
public float zhenFu = 10f;//振幅
public float HZ = 1f;//频率
public GameObject talkUI;// Start is called before the first frame update
private IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(3f);
        talkUI.SetActive(false);
    }

    void Start()
    {
        talkUI.SetActive(true);
        trans1 = talkUI.transform.position;
        StartCoroutine(WaitAndReset());
    }

    // Update is called once per frame
    void Update()
    {
        trans2 = trans1;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans1.y;
        talkUI.transform.position = trans2;
        
    }
}
