using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEffects : MonoBehaviour {

    //public float repeatRatePos;

    /*
     * Fix this for random movement.
    private float xPos;
    private float yPos;
    private float zPos;
    private Vector3 desiredPos;
    private float timer;
    private float currX;
    private float currY;
    private float currZ;

    public float speed = 2;//Used to speed up the animation between points.
    public float timerSpeed;//Used to speed up the action.
    public float timeToMove;//Used to speed up the time between actions.
    */

    //INTENSITY CHANGING
    private float newIntensity;
    private float startInt;
    private float LTTimer;

    public Light light;
    public float LTSmooth = 2f;//Used to speed up the animation between points.
    public float LTTimerSpeed;//Used to speed up the action.
    public float LTTimeToMove;//Used to speed up the time between actions.
    public float maxInt = 100f;

    void Awake()
    {
        light = GetComponent<Light>();
        startInt = light.intensity;

        
    }

    void Start()
    {
        //InvokeRepeating("SetRandomPos", 0, repeatRatePos);

        //xPos = Random.Range(-2f, 2f);
        //yPos = Random.Range(-2f, 2f);
        //zPos = Random.Range(-2f, 2f);

        //desiredPos = new Vector3(currX, currY, currZ);

    }


    void Update ()
    {
        //transform.position = Vector3.Lerp(transform.position, tempPos, Time.deltaTime * smooth);
        /*
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
                if(Vector3.Distance(transform.position, desiredPos) <= 0.01f)
                {
                    xPos = Random.Range(-2f, 2f);
                    yPos = Random.Range(-2f, 2f);
                    zPos = Random.Range(-2f, 2f);

                    desiredPos = new Vector3((currX + xPos), yPos, zPos);
                    timer = 0.0f;
                }
        }
        */

        IntensityChanging();

    }

    /*
    void SetRandomPos()
    {
        Vector3 tempPos = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        transform.position = tempPos;


    }
    */

    void IntensityChanging()
    {

        LTTimer += Time.deltaTime * LTTimerSpeed;
        if (LTTimer >= LTTimeToMove)
        {
            light.intensity = Mathf.Lerp(light.intensity, newIntensity, Time.deltaTime * LTSmooth);
            if (light.intensity <= maxInt)
            {
                newIntensity = Random.Range((startInt * -2), (startInt * 2));
                LTTimer = 0.0f;
            }
        }


        

    }

}
