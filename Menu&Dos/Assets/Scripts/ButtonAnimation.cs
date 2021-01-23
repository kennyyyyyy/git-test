using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField]public List<Button> ButtonList;         //按钮
    [SerializeField]private int Button_index = 0;           //记录当前按钮下标
    [SerializeField]private float LerpRate = 0.2f;          //
    public float buttonAlpha = 0.4f;                        //选中时的按钮透明度
    public int largeSize = 80;                              //选中后的字体大小
    public int normalSize = 60;                             //正常字体大小
    private int ButtonNum = 5;                              //按钮数量

    public string buttonName = "Start";                     //记录选中的按钮

    public GameObject OptionsObj;
    private bool isOptionActive = false;

    void Start()
    {
        EnterButton(Button_index);
    }

    void Update()
    {
        Choose();
        Selected();
        ShutOption();
    }

    private void Choose()                                   //选择按钮
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ExitButton(Button_index);
            if (Button_index - 1 < 0)
            {
                Button_index = ButtonNum;
            }
            EnterButton(--Button_index);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ExitButton(Button_index);
            if (Button_index + 1 > ButtonNum - 1)
            {
                Button_index = -1;
            }
            EnterButton(++Button_index);
        }
    }
    private void Selected()                                 //选中按钮
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(buttonName)
            {
                case "Start":
                    {
                        StartGame();
                        break;
                    }
                case "Continue":
                    {
                        ContinueGame();
                        break;
                    }
                case "Options":
                    {
                        Options();
                        break;
                    }
                case "About":
                    {
                        About();
                        break;
                    }
                case "Exit":
                    {
                        ExitGame();
                        break;
                    }
            }
        }
    }                               

    private void StartGame()
    {
        Debug.Log("Start");
    }                             //开始
    private void ContinueGame()
    {
        //if(有存档){balabala}
        //else {balabala}
        Debug.Log("Continue");
    }                          //继续
    private void Options()
    {
        OptionsObj.SetActive(true);
        isOptionActive = true;
        Debug.Log("Options");
    }                               //设置
    private void About()
    {
        Debug.Log("About0000");
    }                                 //关于
    private void ExitGame()
    {
        Application.Quit();
    }                              //退出

    private void EnterButton(int _index)                    //当按钮被选中
    {
        Button go = ButtonList[_index];
        buttonName = go.name;
        Color clr = go.image.color;
        go.GetComponent<Image>().color = new Color(clr.r, clr.g, clr.b, buttonAlpha);
        go.transform.GetChild(0).GetComponent<Text>().fontSize = (int)Mathf.Lerp(largeSize, normalSize, LerpRate);
    }

    private void ExitButton(int _index)                     //当离开选中按钮
    {
        Button go = ButtonList[_index];
        Color clr = go.image.color;
        go.GetComponent<Image>().color = new Color(clr.r, clr.g, clr.b, 0);
        go.transform.GetChild(0).GetComponent<Text>().fontSize = (int)Mathf.Lerp(normalSize, largeSize, LerpRate);
    }

    private void ShutOption()                               //关闭设置界面
    {
        if(isOptionActive && Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsObj.SetActive(false);
            isOptionActive = false;
        }
    }
}
