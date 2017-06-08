using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMnager : MonoBehaviour {
    public Image FadeImage;
    private float fade1 = 0;
    private float fade2 = 1;
    private float fade3 = 0;
    private bool isPlaying = false;
    public Text systemtime;
    public GameObject Mainpanel,Panel1,Panel2,Panel3,Panel4,Panel5;
    private int PanelNumber;
    public GameObject prevpanel;
    // Use this for initialization
    void Start () {
        FadeImage.enabled = false;
        Mainpanel.SetActive(true);
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        prevpanel = Mainpanel;
        PanelNumber = 0;
    }

    // Update is called once per frame
    void Update () {
        System.DateTime now = System.DateTime.Now;
        systemtime.text = now.Hour.ToString()+" : "+now.Minute.ToString();
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
                Mainpanel.SetActive(true);
                prevpanel.SetActive(false);
                break;
            case 1:
                Mainpanel.SetActive(false);
                prevpanel.SetActive(true);
                break;
            case 2:
                Mainpanel.SetActive(false);
                prevpanel.SetActive(true);
                break;
            case 3:
                Mainpanel.SetActive(false);
                prevpanel.SetActive(true);
                break;
            case 4:
                Mainpanel.SetActive(false);
                prevpanel.SetActive(true);
                break;
            case 5:
                Mainpanel.SetActive(false);
                prevpanel.SetActive(true);
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
        PanelNumber = 3;
        prevpanel = Panel3;
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
    public void BackPanel()
    {
        PanelNumber = 0;
    }
}
