using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedBackPrefab : MonoBehaviour
{
    public GameObject oText;
    public string mText;
    private float delayRewind;
    // Start is called before the first frame update
    void Start()
    {
        oText.GetComponent<TextMeshProUGUI>().text = mText;
    }

    // Update is called once per frame
    void Update()
    {
        delayRewind += Time.deltaTime;
        if (delayRewind >= 3) Destroy(this.gameObject);
    }
}
