using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeechBubble : MonoBehaviour
{
    //If Bubble is Perspective then size will decrease as player moves away from camera.
    //If Bubble is not Perspective than size will be similar to below variable "standardSize" regardless of distance with Camera.
    private bool isPerspective = true;

    //maximum width of bubble.
    private int fixedWidth = 200;

    //minimum distance from camera.. if player is nearer than this distance bubble will not be visible.. 
    //I have kept this variable so that any bubble does not cover whole screen.
    private float minDistanceFromCamera = 3f;

    private Texture2D PopUpBG, DownArrow;
    private GUISkin BubbleSkin;

    //point at which buuble will be pointing. Normally character's top of the head.
    private GameObject pivotForBubble;
    private List<Msg> currMsgs;
    private float multiplier, lerpingOffset, lerpStartTime;
    private bool isLerping;
    private Vector3 prevPos;

    //temporary messages for demo.
    private string[] msgs;

    //if its Bot then automatically moves. if its not Bot then movement control will be in user's hand. and user can also type message.
    public bool isBot;

    //Input message for user.
    private string nextmsg;

    //This size is refernced size of bubble proportional to its distance. Depend on this size, bubble size will be created dynamically.
    private float standardSize = 10f;

    //Time for bubble fade in Animation
    private float easeInAnimationTime = 1f;

    //Time for bubble fade out Animation
    private float easeOutAnimationTime = 1f;
    
    //Time that bubble stays in screen.
    private float bubbleLife = 5f;

    public struct Msg
    {
        public string msg;
        public float msgTime;
        public float msgAlpha;

        public Msg(string _msg, float _msgTime, float _msgAlpha)
        {
            msg = _msg;
            msgTime = _msgTime;
            msgAlpha = _msgAlpha;
        }
    }

    void Start()
    {
        foreach (Transform t in transform)
        {
            if (t.tag == "bubblePivot")
            {
                pivotForBubble = t.gameObject;
            }
        }

        PopUpBG = (Texture2D)Resources.Load("Textures/PopUpBG");
        DownArrow = (Texture2D)Resources.Load("Textures/DownArrow");
        BubbleSkin = (GUISkin)Resources.Load("Skin/BubbleSkin");

        currMsgs = new List<Msg>();
        lerpingOffset = 1;
        isLerping = false;
        lerpStartTime = 0;
        nextmsg = "";

        msgs = new string[10];
        msgs[0] = "Hi";
        msgs[1] = "Hello Developer How are you there?";
        msgs[2] = "Enjoy Speech Bubble. Hope this is helpful to you. Don't Forget to rate it if you like it.Thank You";
        msgs[3] = "Hello There!";
        msgs[4] = "Make awsome Games in Unity! This is an Awesome Game Engine.";

        if (isBot)
        {
            StartCoroutine(generateNewMsg());
        }
    }


    void OnGUI()
    {
        if (currMsgs.Count == 1)
        {
            Vector3 currPos = Camera.main.WorldToScreenPoint(pivotForBubble.transform.position);
            currPos = Vector3.Lerp(prevPos, currPos, 0.6f);
            prevPos = currPos;
            currPos.y = Screen.height - currPos.y;
            if (isPerspective)
            {
                multiplier = standardSize / currPos.z;
            }
            else
            {
                multiplier = standardSize / 10f;
            }
            if (currPos.x > 0 && currPos.x < Screen.width && currPos.y > 0 && currPos.y < Screen.height)
            {
                if (currPos.z > minDistanceFromCamera)
                {
                    GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(1.0f * multiplier, 1.0f * multiplier, 1));
                    GUI.depth = (int)currPos.z * 10;
                    float currWidth = 0, currheight = 0; ;
                    Vector2 mySize = BubbleSkin.customStyles[0].CalcSize(new GUIContent(currMsgs[0].msg));
                    if (mySize.x < fixedWidth)
                    {
                        currWidth = mySize.x + 10f;
                    }
                    else
                    {
                        currWidth = fixedWidth;
                    }
                    currheight = BubbleSkin.customStyles[0].CalcHeight(new GUIContent(currMsgs[0].msg), currWidth);
                    Rect r = new Rect(currPos.x / multiplier - currWidth / 2f, currPos.y / multiplier - 10 - currheight, currWidth, currheight);
                    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, currMsgs[0].msgAlpha);
                    GUI.DrawTexture(r, PopUpBG);
                    GUI.Label(r, currMsgs[0].msg, BubbleSkin.customStyles[0]);
                    GUI.DrawTexture(new Rect(currPos.x / multiplier - 5, currPos.y / multiplier - 10, 10, 10), DownArrow);
                }
            }
        }
        else if (currMsgs.Count >= 2)
        {
            Vector3 currPos = Camera.main.WorldToScreenPoint(pivotForBubble.transform.position);
            currPos = Vector3.Lerp(prevPos, currPos, 0.6f);
            prevPos = currPos;
            currPos.y = Screen.height - currPos.y;
            if (isPerspective)
            {
                multiplier = standardSize / currPos.z;
            }
            else
            {
                multiplier = standardSize / 10f;
            }
            if (currPos.x > 0 && currPos.x < Screen.width && currPos.y > 0 && currPos.y < Screen.height)
            {
                if (currPos.z > minDistanceFromCamera)
                {
                    GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(1.0f * multiplier, 1.0f * multiplier, 1));
                    GUI.depth = (int)currPos.z * 10;
                    float currWidth = 0, currheight = 0;
                    Vector2 mySize = BubbleSkin.customStyles[0].CalcSize(new GUIContent(currMsgs[1].msg));
                    if (mySize.x < 200)
                    {
                        currWidth = mySize.x + 10f;
                    }
                    else
                    {
                        currWidth = fixedWidth;
                    }
                    currheight = BubbleSkin.customStyles[0].CalcHeight(new GUIContent(currMsgs[1].msg), currWidth);
                    Rect r = new Rect(currPos.x / multiplier - currWidth / 2f, currPos.y / multiplier - 10 - currheight, currWidth, currheight);
                    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, currMsgs[1].msgAlpha);
                    GUI.DrawTexture(r, PopUpBG);
                    GUI.Label(r, currMsgs[1].msg, BubbleSkin.customStyles[0]);
                    GUI.DrawTexture(new Rect(currPos.x / multiplier - 5, currPos.y / multiplier - 10, 10, 10), DownArrow);
                    float currWidth1 = 0, currheight1 = 0;
                    Vector2 mySize1 = BubbleSkin.customStyles[0].CalcSize(new GUIContent(currMsgs[0].msg));
                    if (mySize1.x < 200)
                    {
                        currWidth1 = mySize1.x + 10f;
                    }
                    else
                    {
                        currWidth1 = fixedWidth;
                    }
                    currheight1 = BubbleSkin.customStyles[0].CalcHeight(new GUIContent(currMsgs[0].msg), currWidth1);
                    Rect r2 = new Rect(currPos.x / multiplier - currWidth1 / 2f, currPos.y / multiplier - 30 - currheight * lerpingOffset - currheight1, currWidth1, currheight1);
                    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, currMsgs[0].msgAlpha);
                    GUI.DrawTexture(r2, PopUpBG);
                    GUI.Label(r2, currMsgs[0].msg, BubbleSkin.customStyles[0]);
                    GUI.DrawTexture(new Rect(currPos.x / multiplier - 5, currPos.y / multiplier - 30 - currheight * lerpingOffset, 10, 10), DownArrow);
                }
            }
        }
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 1);

        //bubble fade out animation
        if (currMsgs.Count > 0)
        {
            if (Time.time - currMsgs[0].msgTime > bubbleLife)
            {
                //if (Time.time - currMsgTime[currMsgTime.Count - 1] < 6)
                {
                    if (Time.time - currMsgs[0].msgTime >= (bubbleLife + easeOutAnimationTime))
                    {
                        currMsgs.RemoveAt(0);
                    }
                    else
                    {
                        Msg mTemp = currMsgs[0];
                        mTemp.msgAlpha = Mathf.Lerp(1, 0, (Time.time - currMsgs[0].msgTime - bubbleLife) / easeOutAnimationTime);
                        currMsgs[0] = mTemp;
                    }
                }
            }
        }

        //bubble fade in animation
        if (isLerping)
        {
            if (Time.time - lerpStartTime <= easeInAnimationTime)
            {
                lerpingOffset = Mathf.Lerp(0, 1, (Time.time - lerpStartTime) / easeInAnimationTime);
                if (currMsgs.Count > 0)
                {
                    Msg mTemp = currMsgs[currMsgs.Count - 1];
                    mTemp.msgAlpha = Mathf.Lerp(0, 1, (Time.time - lerpStartTime) / easeInAnimationTime);
                    currMsgs[currMsgs.Count - 1] = mTemp;
                }
            }
            else
            {
                isLerping = false;
                lerpingOffset = 1;
            }
        }
        if (!isBot)
        {
            GUI.matrix = Matrix4x4.identity;
            Event e = Event.current;
            if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Return && nextmsg != "")
            {
                addNewMessage(nextmsg);
                nextmsg = "";
            }
            nextmsg = GUI.TextField(new Rect(10, Screen.height - 50f, Screen.width - 150f, 40f), nextmsg, 100);
            if (GUI.Button(new Rect(Screen.width - 120, Screen.height - 50f, 100, 40), "add") && nextmsg != "")
            {
                addNewMessage(nextmsg);
                nextmsg = "";
            }
        }
    }

    IEnumerator generateNewMsg()
    {
        yield return new WaitForSeconds(Random.Range(1f,8f));
        addNewMessage(msgs[Random.Range(0, 5)]);
        StartCoroutine(generateNewMsg());
    }

    public void addNewMessage(string msg)
    {
        Msg newMsg = new Msg(msg, Time.time, 1);
        currMsgs.Add(newMsg);
        prevPos = Camera.main.WorldToScreenPoint(pivotForBubble.transform.position);
        if (currMsgs.Count > 2)
        {
            currMsgs.RemoveAt(0);
        }
        if (currMsgs.Count > 1)
        {
            isLerping = true;
            lerpStartTime = Time.time;
            lerpingOffset = 0;
        }
    }
}
