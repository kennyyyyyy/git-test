using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    private Text text;                      //文本框
    public float timeGap = 0.2f;            //单个字符显示时间间隔
    [TextArea]public string str;

    private bool isPrint = false;           //是否正在打印
    private bool isPlayBGM = false;         //音频是否播放
    private float timer;                    //计算时间间隔的计时器
    private int curIndex = 0;               //当前下标

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        isPrint = true;
        text = GetComponent<Text>();
        //audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        StartPrint();
        if(Input.GetMouseButtonDown(0) && !isPrint)
        {
            //场景跳转或进入下一段文字
        }
    }

    private void StartPrint()
    {
        
        if (isPrint)
        {
            if(!isPlayBGM)
            {
                audioSource.Play();
                isPlayBGM = true;
            }
            if (Input.GetMouseButtonDown(0))//答应过程中按下鼠标左键跳过过程
            {
                endPrint();
            }
            timer += Time.deltaTime;
            if(timer >= timeGap)
            {
                timer = 0;
                curIndex++;
                text.text = str.Substring(0, curIndex) + '_';
                
                Debug.Log(text.text);
                if(curIndex >= str.Length)
                {
                    endPrint();
                }
            }
        }
    }

    private void endPrint()                     //结束打印
    {
        audioSource.Stop();
        isPlayBGM = false;
        timer = 0;
        curIndex = 0;
        text.text = str;
        isPrint = false;
    } 
}
