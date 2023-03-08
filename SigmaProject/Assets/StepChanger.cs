using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepChanger : MonoBehaviour
{
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;
    AudioSource audiosource;
    Rigidbody2D rb;
    bool isplaying;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.transform.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((rb.velocity.x != 0f || rb.velocity.y !=0f)&&isplaying == false)
        {
            int i = Random.Range(1, 4);
            switch (i)
            {
                case 1:
                    audiosource.clip = step1;
                    audiosource.Play();
                    break;
                case 2:
                    audiosource.clip = step2;
                    audiosource.Play();
                    break;
                case 3:
                    audiosource.clip = step3;
                    audiosource.Play();
                    break;
            }
            isplaying = true;
            StartCoroutine(letTheStepFinish());
        }
    }
    IEnumerator letTheStepFinish()
    {
        yield return new WaitForSeconds(.45f);
        isplaying = false;
    }
}
