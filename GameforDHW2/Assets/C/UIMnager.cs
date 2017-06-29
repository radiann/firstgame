using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMnager : MonoBehaviour {
    public Image FadeImage;
    private float fade1 = 0;
    private float fade2 = 1;
    private float fade3 = 0;
    private bool isPlaying = false, panel3open = false;
    public Text systemtime;
    public System.DateTime PlayTime;
    public GameObject Mainpanel,Panel1,Panel2,Panel3,Panel4,Panel5,Gamepanel,Resultpanel;
    public GameObject ItemPanel,BukiItemPanel,MonsterItemPanel;
    private bool Itempanelopen,Bukiitempanelopen,Monsteritempanelopen;
    public GameObject prevpanel;
    private int PanelNumber;
    public GameObject Stage1, Stage2, Stage3, Stage4;
    private Vector3 Stage1setposition, Stage2setposition, Stage3setposition, Stage4setposition;
    public bool directionChosen;
    private bool gamemode, Timer;
    public ItemManager ResultInventory,ItemInventory,BukiItemInventory,MonsterItemInventory;
    private float itemruting = 0f;
    //private float touchspeed = 0;
    public GameObject itemmana1, itemmana2, itemmana3;
    // Use this for initialization
    void Start () {
        //GetComponent<Canvas>().enabled = false;
        FadeImage.enabled = false;
        Mainpanel.SetActive(true);
        Mainpanel.GetComponent<CanvasGroup>().alpha = 1;
        //Panel1.GetComponent<GameObject>().
        Panel1.SetActive(true);
        Panel1.GetComponent<CanvasGroup>().alpha = 0;
        Panel2.SetActive(true);
        Panel2.GetComponent<CanvasGroup>().alpha = 0;
        Panel3.SetActive(false);
        //Panel3.GetComponent<CanvasGroup>().alpha = 0;
        Panel4.SetActive(true);
        Panel4.GetComponent<CanvasGroup>().alpha = 0;
        Panel5.SetActive(true);
        Panel5.GetComponent<CanvasGroup>().alpha = 0;
        Gamepanel.SetActive(true);
        Gamepanel.GetComponent<CanvasGroup>().alpha = 0;
        Resultpanel.SetActive(true);
        Resultpanel.GetComponent<CanvasGroup>().alpha = 0;
        ItemPanel.SetActive(true);
        ItemPanel.GetComponent<CanvasGroup>().alpha = 0;
        BukiItemPanel.SetActive(true);
        BukiItemPanel.GetComponent<CanvasGroup>().alpha = 0;
        MonsterItemPanel.SetActive(true);
        MonsterItemPanel.GetComponent<CanvasGroup>().alpha = 0;

        //ItemPanel.SetActive(false);
        Itempanelopen = false;
        Bukiitempanelopen = false;
        Monsteritempanelopen = false;
        prevpanel = Mainpanel;
        PanelNumber = 0;
        gamemode = false;
        Timer = false;

        Stage1setposition = Stage1.transform.position;
        Stage2setposition = Stage2.transform.position;
        Stage3setposition = Stage3.transform.position;
        Stage4setposition = Stage4.transform.position;
    }

    // Update is called once per frame
    void Update () {
       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    touchspeed = 0;
                    break;
                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    //direction = touch.position - startPos;
                    touchspeed = 50f;
                    break;                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    touchspeed = 0;
                    break;
            }
        }*/
        if (directionChosen)
        {
            // Something that uses the chosen direction...
        }
        Debug.Log(PlayTime.Minute + " : " + PlayTime.Second);
        if (PlayTime.Minute>0&&gamemode== true)
        {
            Timer = true;
            PlayTime = PlayTime.AddSeconds(-Time.deltaTime);
        }
        else if(PlayTime.Second>0 && gamemode == true)
        {
            PlayTime = PlayTime.AddSeconds(-Time.deltaTime);
            Timer = true;
        }
        else if (PlayTime.Minute == 0 && PlayTime.Second == 0 && gamemode == true)
        {
            Resultpanel.GetComponent<CanvasGroup>().alpha = 1;
            Timer = false;
        }
        systemtime.text = PlayTime.Hour.ToString()+" : "+PlayTime.Minute.ToString() + " : " + PlayTime.Second.ToString();
        if (Input.GetKey(KeyCode.A))
        {
            //Inventory.AddItem(itemmana.GetComponent<Item>());
            Debug.Log("aa");
        }
            if (gamemode== true && Timer==true && itemruting + 5f < Time.time)
        {
            itemruting = Time.time;
            float rand = Random.Range(0, 99);
            if (rand <= 33)
            {
                ResultInventory.AddItem(itemmana1.GetComponent<Item>());
            }
            else if (rand >= 34 && rand <= 67)
            {
                ResultInventory.AddItem(itemmana2.GetComponent<Item>());
            }
            else
            {
                ResultInventory.AddItem(itemmana3.GetComponent<Item>());
            }
        }
}
    public void FadeAnim()
    {
        if (isPlaying == true)
            return;
        FadeImage.enabled = true;
        StartCoroutine("playFadeOut");
    }
    IEnumerator playFadeOut()
    {
        isPlaying = true;
        Color color = FadeImage.color;
        fade3 = 0f;
        color.a = Mathf.Lerp(fade1, fade2, fade3);

        while (color.a < 1f)
        {
            fade3 += Time.deltaTime;
            color.a = Mathf.Lerp(fade1, fade2, fade3 *2);
            FadeImage.color = color;
            yield return null;
        }
        switch (PanelNumber)
        {
            case 0:
                    Panel3.SetActive(false);
                    Mainpanel.GetComponent<CanvasGroup>().alpha = 1;
                    prevpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<Image>().raycastTarget = false;
                break;
            case 1:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                break;
            case 2:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                break;
            case 3:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                Panel3.SetActive(true);
                Stage1.transform.position = Stage1setposition;
                Stage2.transform.position = Stage2setposition;
                Stage3.transform.position = Stage3setposition;
                Stage4.transform.position = Stage4setposition;
                break;
            case 4:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                break;
            case 5:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                break;
            case 6:
                Panel3.SetActive(false);
                panel3open = false;
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                break;
            default:
                break;
        }
        StartCoroutine("playFadeIn");
    }
    IEnumerator playFadeIn()
    {

        Color color = FadeImage.color;
        fade3 = 0f;
        color.a = Mathf.Lerp(fade2, fade1, fade3);

        while (color.a > 0f)
        {
            fade3 += Time.deltaTime;;
            color.a = Mathf.Lerp(fade2, fade1, fade3 *2);
            FadeImage.color = color;
            yield return null;
        }
        isPlaying = false;
        FadeImage.enabled = false;
    }
    public void panel1()
    {
            PanelNumber = 1;
            prevpanel = Panel1;
    }
    public void panel2()
    {
            PanelNumber = 2;
            prevpanel = Panel2;
    }
    public void panel3()
    {
        if (gamemode == false)
        {
            PanelNumber = 3;
            prevpanel = Panel3;
            Resultpanel.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            PanelNumber = 6;
            prevpanel = Gamepanel;
        }

    }
    public void panel4()
    {
        PanelNumber = 4;
        prevpanel = Panel4;
    }
    public void panel5()
    {
        PanelNumber = 5;
        prevpanel = Panel5;
    }
    public void gamepanel()
    {
        gamemode = true;
        PanelNumber = 6;
        prevpanel = Gamepanel;
        PlayTime = PlayTime.AddMinutes(1);
        panel3open = false;
    }
    public void resultOK()
    {
        PanelNumber = 0;
        gamemode = false;
        BukiItemInventory.AddItem(ResultInventory.GetComponent<Item>());
    }
    public void BackPanel()
    {
        PanelNumber = 0;
    }
    public void Itempanel()
    {
        if (Itempanelopen==false || Bukiitempanelopen== true||Monsteritempanelopen==true)
        {
            ItemPanel.GetComponent<CanvasGroup>().alpha = 1;
            BukiItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            MonsterItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            Itempanelopen = true;
            Bukiitempanelopen = false;
            Monsteritempanelopen = false;
        }
        else
        {
            ItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            Itempanelopen = false;
        }
    }
    public void BukiItempanel()
    {
        if (Itempanelopen == true || Bukiitempanelopen == false || Monsteritempanelopen == true)
        {
            ItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            BukiItemPanel.GetComponent<CanvasGroup>().alpha = 1;
            MonsterItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            Itempanelopen = false;
            Bukiitempanelopen = true;
            Monsteritempanelopen = false;
        }
        else
        {
            BukiItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            Bukiitempanelopen = false;
        }
    }
    public void MonsterItempanel()
    {
        if (Itempanelopen == true || Bukiitempanelopen == true || Monsteritempanelopen == false)
        {
            ItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            BukiItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            MonsterItemPanel.GetComponent<CanvasGroup>().alpha = 1;
            Itempanelopen = false;
            Bukiitempanelopen = false;
            Monsteritempanelopen = true;
        }
        else
        {
            MonsterItemPanel.GetComponent<CanvasGroup>().alpha = 0;
            Monsteritempanelopen = false;
        }
    }
}
