using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlueCircle : MonoBehaviour
{
    public GameObject target;
    public Canvas myCanvas;
    
    public static float moveSpeed;
    public static int BlockCount;
    public static int success;
    public static float ballx;
    public static float bally;

    public static Vector3 currentVector;
    public static Vector2 currentRadius;
    public static Vector2 currentPosition;
    
    public Rigidbody2D ball;
    public CircleCollider2D CirCollider;

    public static bool ClickSuccess = false;



    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector3(x, y);
    }

    private Vector2 RandomSize(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = x;
        return new Vector2(x, y);
    }

     private Vector2 RandomPosition(float width, float height)
    {
        var x = Random.Range(0, width);
        var y = Random.Range(0, height);
        return new Vector2(x, y);
    }

    public void NextTargetSet()
    {
        ClickSuccess = false;
        ball = GetComponent<Rigidbody2D>();

        //random target velocity
        ball.velocity = RandomVector(-500, 500);
        currentVector = ball.velocity;

        //random target size
        RectTransform rt = target.GetComponent<RectTransform>();
        rt.sizeDelta = RandomSize(50, 200);
        currentRadius = rt.sizeDelta;

        //Circle collider should be changed together
        CirCollider = GetComponent<CircleCollider2D>();
        CirCollider.radius = rt.sizeDelta.x / 2 / 10 * 9;

        //random target position (Circle collider is attached to target so that don't need to reset the collider's position) 
        rt.position = RandomPosition(Screen.width, Screen.height);
        currentPosition = rt.position;
        
    }

    private void OnPointerDown(PointerEventData data)
    {
        ClickSuccess = true;
        Debug.Log("PointerDown");
        NextTargetSet();
        success += 1;
    }

    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.isKinematic = false; //for making a bouncing ball (if this is true, a ball will go out of the canvas)
        NextTargetSet();

        EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);
        
    }

    


    void Update()
    {

        //Debug.Log(Input.mousePosition);
        //Debug.Log(Time.deltaTime);

        ballx = ball.position.x;
        bally = ball.position.y;
        
    }
}
