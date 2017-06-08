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
    public System.DateTime PlayTime;
    public GameObject Mainpanel,Panel1,Panel2,Panel3,Panel4,Panel5,Gamepanel,Resultpanel;
    private int PanelNumber;
    public GameObject prevpanel;
    public GameObject Stage1, Stage2, Stage3, Stage4;
    public GameObject AroundPoint;
    public GameObject target;
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;
    private bool gamemode;
    
    // Use this for initialization
    void Start () {
        FadeImage.enabled = false;
        Mainpanel.SetActive(true);
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
        Panel5.SetActive(false);
        Gamepanel.SetActive(false);
        Resultpanel.SetActive(false);
        prevpanel = Mainpanel;
        PanelNumber = 0;
        gamemode = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;
                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            // Something that uses the chosen direction...
        }
        Debug.Log(PlayTime.Minute + " : " + PlayTime.Second);
        if (PlayTime.Minute>0&&gamemode== true)
        {
            PlayTime = PlayTime.AddSeconds(-Time.deltaTime);
        }
        else if(PlayTime.Second>0 && gamemode == true)
        {
            PlayTime = PlayTime.AddSeconds(-Time.deltaTime);
        }
        else if (PlayTime.Minute == 0 && PlayTime.Second == 0 && gamemode == true)
        {
            Resultpanel.SetActive(true);
        }
        else
        {
            return;
        }
        systemtime.text = PlayTime.Hour.ToString()+" : "+PlayTime.Minute.ToString() + " : " + PlayTime.Second.ToString();
        Vector3 UPAxis = AroundPoint.transform.TransformDirection(Vector3.up);
        Vector3 DOWNAxis = AroundPoint.transform.TransformDirection(Vector3.down);
        // Stage1.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
        Stage1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        // Stage2.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
        Stage2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        // Stage3.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
        Stage3.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        // Stage4.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
        Stage4.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        if (startPos.x > direction.x) { 
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;{
            Stage1.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
            Stage2.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
            Stage3.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
            Stage4.transform.RotateAround(target.transform.position, UPAxis, 50f * Time.deltaTime);
           // Debug.Log(startPos.x);
           // Debug.Log(direction.x);
        }
        else if (startPos.x < direction.x)
        {
            Stage1.transform.RotateAround(target.transform.position, DOWNAxis, 50f * Time.deltaTime);
            Stage2.transform.RotateAround(target.transform.position, DOWNAxis, 50f * Time.deltaTime);
            Stage3.transform.RotateAround(target.transform.position, DOWNAxis, 50f * Time.deltaTime);
            Stage4.transform.RotateAround(target.transform.position, DOWNAxis, 50f * Time.deltaTime);
           // Debug.Log(startPos.x);
           // Debug.Log(direction.x);
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
            case 6:
                Mainpanel.SetActive(false);
                Panel3.SetActive(false);
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
        if (gamemode == false)
        {
            PanelNumber = 3;
            prevpanel = Panel3;
            Resultpanel.SetActive(false);
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
    }
    public void resultOK()
    {
        PanelNumber = 0;
        gamemode = false;
    }
    public void BackPanel()
    {
        PanelNumber = 0;
    }
}
