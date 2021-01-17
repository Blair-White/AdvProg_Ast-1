using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPrefabEffect : MonoBehaviour
{
    private int destroyCount;
    public bool isMining;
    private int delaysound;
    private void Awake()
    {
 
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        delaysound++;
        if(delaysound == 2)
        {
            if (isMining)
                SFXController.instance.PlayMining();
            else { SFXController.instance.PlayScanning(); }
        }
        destroyCount++;
        if (destroyCount > 520) GameObject.Destroy(this.gameObject);
        this.transform.Rotate(0, 0, this.transform.rotation.z + 1);
    }
}
