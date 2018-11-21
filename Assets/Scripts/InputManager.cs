using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class InputManager : MonoBehaviour
{


    private bool hasTaped;
    private bool rightTap;
    //private bool doubleTap;
    //private float timeSingleTap;
    //private float timeDoubleTap;
    //private float timeDown;
    //private float timeUp;
    [SerializeField]
    private float timer;
    private bool hasLongTaped;

    private LongPressGestureRecognizer longTap;

    private TapGestureRecognizer simpleTap;

    //private float doubleClickTimeLimit = 0.25f;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        hasTaped = false;
        hasLongTaped = false;
        rightTap = true;
        SetupGesture();
        //StartCoroutine(InputListener());
        //StartCoroutine(UpdatesInput());
    }

    // Update is called once per frame
    void Update()
    {


    }
    //

    void SetupGesture()
    {
        longTap = new LongPressGestureRecognizer();

        simpleTap = new TapGestureRecognizer();

        longTap.Updated += LongTap_Updated;

        FingersScript.Instance.AddGesture(longTap);

        simpleTap.Updated += SimpleTap_Updated;

        FingersScript.Instance.AddGesture(simpleTap);
    }

    void SimpleTap_Updated(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0f)
            {
                rightTap = true;
            }
            else
            {
                rightTap = false;
            }
            hasTaped = true;
            Invoke("UpdatesInput", 0.5f);
        }

    }


    void LongTap_Updated(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    {
       


        if (gesture.State == GestureRecognizerState.Executing)
        {
            if (timer < 0.3f)
            {
                timer += 0.1f * Time.deltaTime;
            }
        }
        if(gesture.State == GestureRecognizerState.Ended)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0f)
            {
                rightTap = true;
            }
            else
            {
                rightTap = false;
            }
            hasLongTaped = true;
            hasTaped = true;
            Invoke("UpdatesInput", 0.7f);
        }

    }

    void UpdatesInput()
    {
        if (hasTaped == true)
        {
            hasTaped = false;
        }
        if (hasLongTaped == true)
        {
            hasLongTaped = false;
        }
        if (timer > 0f)
        {
            timer = 0f;
        }
    }

//    // Update is called once per frame
//    private IEnumerator InputListener()
//    {
//        while (true)
//        { //Run as long as this is activ
//#if !UNITY_ANDROID
            //if (Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0f)
            //{
            //    rightTap = true;
            //    hasTaped = true;
            //    timeDown = Time.time;
            //    yield return new WaitForSeconds(0.5f);
            //    if (hasTaped && !doubleTap)
            //    {
            //        hasTaped = false;
            //    }
            //    //yield return ClickEvent();
            //}
            //else if (Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0f)
            //{
            //    rightTap = false;
            //    hasTaped = true;
            //    timeDown = Time.time;
            //    //yield return ClickEvent();
            //    yield return new WaitForSeconds(0.5f);
            //    if(hasTaped && !doubleTap)
            //    {
            //        hasTaped = false;
            //    }
            //}

            //if (Input.GetMouseButtonDown(1))
            //{
            //    timeUp = Time.time;
            //    //hasTaped = false;
            //    float tst = timeUp - timeDown;
            //    Debug.Log(tst);
            //    if (tst > 2f)
            //    {
            //        Debug.Log("LONGTAP");
            //        doubleTap = true;
            //        hasTaped = true;
            //    }
            //}

            //if(hasTaped && doubleTap) {
            //    yield return new WaitForSeconds(0.9f);
            //    hasTaped = false;
            //    doubleTap = false;
            //}
//#elif UNITY_ANDROID
//            foreach(Touch touch in Input.touches)
//            {
//                if (touch.phase == TouchPhase.Began && 
//                    Camera.main.ScreenToWorldPoint(touch.position).x > 0f)
//                {
//                    rightTap = true;
//                    hasTaped = true;
//                    yield return new WaitForSeconds(0.5f);
//                    if (hasTaped && !doubleTap)
//                    {
//                        hasTaped = false;
//                    }
//                }
//                else if (touch.phase == TouchPhase.Began &&
//                    Camera.main.ScreenToWorldPoint(touch.position).x < 0f)
//                {
//                    rightTap = false;
//                    hasTaped = true;
//                    yield return new WaitForSeconds(0.5f);
//                    if (hasTaped && !doubleTap)
//                    {
//                        hasTaped = false;
//                    }
//                }

//                if (touch.phase == TouchPhase.Stationary)
//                {
//                    yield return new WaitForSeconds(2f);

//                    hasTaped = true;

//                    doubleTap = true;

//                    yield return new WaitForSeconds(2f);

//                    if (hasTaped && doubleTap)
//                    {
//                        hasTaped = false;
//                        doubleTap = false;
//                    }
//                }

//                if (touch.phase == TouchPhase.Ended)
//                {
//                    yield return new WaitForSeconds(0.5f);
//                    hasTaped = false;
//                    doubleTap = false;
//                }
               
//            }
//#endif
    //        yield return null;
    //    }
    //}

    //private IEnumerator ClickEvent()
    //{
    //    //pause a frame so you don't pick up the same mouse down event.
    //    yield return new WaitForEndOfFrame();

    //    hasTaped = true;

    //    float count = 0f;
    //    while (count < doubleClickTimeLimit)
    //    {

    //        if (Input.GetMouseButtonUp(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0f)
    //        {
    //            rightTap = true;
    //            doubleTap = true;
    //            yield return new WaitForSeconds(0.5f);

    //            doubleTap = false;
    //            hasTaped = false;
    //        }
    //        else if (Input.GetMouseButtonUp(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0f)
    //        {
    //            rightTap = false;
    //            doubleTap = true;
    //            yield return new WaitForSeconds(0.5f);

    //            doubleTap = false;
    //            hasTaped = false;
    //        }
    //        else {

    //        }
           
    //        count += Time.deltaTime;// increment counter by change in time between frames
          
    //        yield return null; // wait for the next frame
    //    }
    //    hasTaped = false;
    //}

    public float GetLongTapTimer() {
        return timer;
    }
    public bool GetLongTap() {
        return hasLongTaped;
    }

    public bool GetRightTap()
    {
        return rightTap;
    }

    public bool GetHasTaped() {
        return hasTaped;
    }
}
