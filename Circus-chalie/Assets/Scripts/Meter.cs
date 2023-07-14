using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Meter : MonoBehaviour
{
    public TMP_Text meter;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        meter.text = "" + GameManager.instance.meter;
    }
}
