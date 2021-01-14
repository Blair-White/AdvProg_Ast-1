using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class IntroController : MonoBehaviour
{
    private void Awake()
    {
       
        DOTween.SetTweensCapacity(500,50);
    }
    public void MoveToGame()
    {
        SceneManager.LoadScene(1);
    }
}
