using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPortal : MonoBehaviour
{
    /*
     * 
     * 
     * Pulled from "https://www.youtube.com/watch?v=3q4WlAdW2ZQ"
     *
     * 
     */

    public bool activateTrigger = false;

    public GameObject text0; //Play Info Card
    public GameObject text1; //Stop Info Card
    public GameObject sound; //Target Audio

    public float textTime = 2f;


    // Use this for initialization
    void Start()
    {
        text0.SetActive(false);
        sound.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (activateTrigger && Input.GetKey(KeyCode.E))
        {
            //text0.SetActive(false);
            //text1.SetActive(false);
            this.sound.SetActive(true);
            //Destroy(this.gameObject);

        }
        else if (Input.GetKey(KeyCode.Q))
        {
            //text0.SetActive(false);
            //text1.SetActive(true);
            this.sound.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            text0.SetActive(true);
            text1.SetActive(false);
            activateTrigger = true;

        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            activateTrigger = false;
            text0.SetActive(false);
            text1.SetActive(true);

            StartCoroutine(TextFade());
        }

    }

    IEnumerator TextFade()
    {
        yield return new WaitForSeconds(textTime);
        text1.SetActive(false);
    }

}
