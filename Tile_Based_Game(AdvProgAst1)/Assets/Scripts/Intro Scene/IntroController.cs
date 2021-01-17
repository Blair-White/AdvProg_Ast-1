using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class IntroController : MonoBehaviour
{

    float timing;
    bool init;
    AudioSource aud;
    private void Awake()
    {
       
        DOTween.SetTweensCapacity(500,50);
        aud = this.GetComponent<AudioSource>();
    }
    public void Update()
    {
        timing += Time.deltaTime;
        if (timing > 1 && init == false)
        {
            aud.Play();
            init = true;
        }
            
        
    }
    public void MoveToGame()
    {
        SceneManager.LoadScene(1);
    }
}
