using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMnager : MonoBehaviour {
    public Image FadeImage,RotationImageSet,Rotationimage1, Rotationimage2, Rotationimage3, Rotationimage4, Rotationimage5, Rotationimage6;
    public int itemcount = 0;
    public int item1count, item2count, item3count;
    private float fade1 = 0;
    private float fade2 = 1;
    private float fade3 = 0;
    private bool isPlaying = false;
    public Text KAISOU;
    public int kaisou,finishikaisou,rememberkaisou;
    //public System.DateTime PlayTime;
    public GameObject SIRO;
    public GameObject Mainpanel,Panel1,Panel2,Panel3,Panel4,Panel5,Gamepanel,Resultpanel;
    public GameObject ItemPanel,BukiItemPanel,MonsterItemPanel,JobPanel;
    public GameObject storyscroll,kaisouscroll;
    private bool Itempanelopen,Bukiitempanelopen,Monsteritempanelopen;
    public GameObject prevpanel;
    public int PanelNumber;
    public GameObject Stage1, Stage2, Stage3, Stage4;
    private Vector3 Stage1setposition, Stage2setposition, Stage3setposition, Stage4setposition;
    public bool directionChosen;
    public bool gamemode, Timer, fight, takara,Actionmode,attack,damage, MainPANEL = true;
    public ItemManager ResultInventory,ItemInventory,BukiItemInventory,MonsterItemInventory;
    private float itemruting = 0f, actiontime = 0f, kaisoutime = 0f, saveimagerotation, nextimagerotation;
    //private float touchspeed = 0;
    public GameObject itemmana1, itemmana2, itemmana3;
    public GameObject Playerset;
    float test = 0;
    public SpriteRenderer PlayerRenderer;
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
        JobPanel.SetActive(true);
        JobPanel.GetComponent<CanvasGroup>().alpha = 0;
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
        storyscroll.SetActive(false);
        kaisouscroll.SetActive(false);
        PlayerRenderer.enabled = false;
        //ItemPanel.SetActive(false);
        Itempanelopen = false;
        Bukiitempanelopen = false;
        Monsteritempanelopen = false;
        prevpanel = Mainpanel;
        PanelNumber = 0;
        gamemode = false;
        Timer = false;
        fight = false;
        Actionmode = false;
        attack = false;
        damage = false;
        Stage1setposition = Stage1.transform.position;
        Stage2setposition = Stage2.transform.position;
        Stage3setposition = Stage3.transform.position;
        Stage4setposition = Stage4.transform.position;
        saveimagerotation = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        if (MainPANEL)
        {
            SIRO.SetActive(true);
        }
        else
        {
            SIRO.SetActive(false);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
           nextimagerotation += 60.0f;
           
           iTween.RotateTo(RotationImageSet.gameObject, iTween.Hash("z", nextimagerotation, "islocal", true));
           if(nextimagerotation >= 360)
            {
                nextimagerotation = 0;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            nextimagerotation -= 60.0f;
            iTween.RotateTo(RotationImageSet.gameObject, iTween.Hash("z", nextimagerotation, "islocal", true));
            if (nextimagerotation <= -360)
            {
                nextimagerotation = 0;
            }
        }


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
        /*
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
        
        if (Input.GetKey(KeyCode.A))
        {
            //Inventory.AddItem(itemmana.GetComponent<Item>());
            Debug.Log("aa");
        }*/
        KAISOU.text = kaisou.ToString();
        Debug.Log(finishikaisou);
        
        if(gamemode == true && kaisou != finishikaisou)
        {
            Timer = true;
            kaisoutime += Time.deltaTime;
            if(kaisoutime >= 5+kaisou * 3)
            {
                kaisou+=1;
                kaisoutime = 0;
                rememberkaisou = kaisou;
            }
        }
        else if(gamemode == true && kaisou <= finishikaisou)
        {
            Timer = false;
            kaisoutime = 0;
            Resultpanel.GetComponent<CanvasGroup>().alpha = 1;
        }
        if (gamemode == true && Timer == true && itemruting + actiontime < Time.time && Actionmode == false)
        {

            float actioncount = Random.Range(0, 29);
            if(actioncount <= 15)
            {
                itemruting = Time.time;
                actiontime = Random.Range(5, 10);
                float rand = Random.Range(0, 99);
                if (rand <= 33)
                {
                    ResultInventory.AddItem(itemmana1.GetComponent<Item>());
                    item1count++;
                }
                else if (rand >= 34 && rand <= 67)
                {
                    ResultInventory.AddItem(itemmana2.GetComponent<Item>());
                    item2count++;
                }
                else
                {
                    ResultInventory.AddItem(itemmana3.GetComponent<Item>());
                    item3count++;
                }
                itemcount++;
            }
            else
            {
                actiontime = Random.Range(5, 10);
                itemruting = Time.time;
                Actionmode = true;
                test = Random.Range(0, 10);
                Invoke("TEST",1f);
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
                PlayerRenderer.enabled = false;
                prevpanel.GetComponent<CanvasGroup>().alpha = 0;
                Mainpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = false;
                MainPANEL = true;
                break;
            case 1:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                MainPANEL = false;
                break;
            case 2:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                MainPANEL = false;
                break;
            case 3:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                Panel3.SetActive(true);
                storyscroll.SetActive(false);
                kaisouscroll.SetActive(false);
                Stage1.transform.position = Stage1setposition;
                Stage2.transform.position = Stage2setposition;
                Stage3.transform.position = Stage3setposition;
                Stage4.transform.position = Stage4setposition;
                MainPANEL = false;
                break;
            case 4:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                MainPANEL = false;
                break;
            case 5:
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                MainPANEL = false;
                break;
            case 6:
                Panel3.SetActive(false);
                //panel3open = false;
                Mainpanel.GetComponent<CanvasGroup>().alpha = 0;
                prevpanel.GetComponent<CanvasGroup>().alpha = 1;
                prevpanel.GetComponent<Image>().raycastTarget = true;
                PlayerRenderer.enabled = true;
                MainPANEL = false;
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
            fade3 += Time.deltaTime;
            color.a = Mathf.Lerp(fade2, fade1, fade3 *2);
            FadeImage.color = color;
            yield return null;
        }
        isPlaying = false;
        FadeImage.enabled = false;
    }
    public void StoryScroll()
    {
        storyscroll.SetActive(true);
    }
    public void KaisouScroll()
    {
        kaisouscroll.SetActive(true);
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
        //panel3open = false;
        actiontime = Random.Range(5, 10);
    }
    public void resultOK()
    {
        PanelNumber = 0;
        gamemode = false;
        PlayerRenderer.enabled = false;
        for (int i = itemcount; i != 0; i--)
        {
            if (item1count != 0)
            {
                item1count--;
                BukiItemInventory.AddItem(itemmana1.GetComponent<Item>());
            }
            else if (item2count != 0)
            {
                item2count--;
                BukiItemInventory.AddItem(itemmana2.GetComponent<Item>());
            }
            else
            {
                item3count--;
                BukiItemInventory.AddItem(itemmana3.GetComponent<Item>());
            }
        }
        //BukiItemInventory.AddItem(ResultInventory.GetComponent<Item>());
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
    public void TEST()
    {

        if (test <= 4)
        {
            attack = true;
        }
        else
        {
            damage = true;
        }
        float rand = Random.Range(0, 99);
        if (rand <= 33)
        {
            ResultInventory.AddItem(itemmana1.GetComponent<Item>());
            item1count++;
        }
        else if (rand >= 34 && rand <= 67)
        {
            ResultInventory.AddItem(itemmana2.GetComponent<Item>());
            item2count++;
        }
        else
        {
            ResultInventory.AddItem(itemmana3.GetComponent<Item>());
            item3count++;
        }
        itemcount++;
    }
}
