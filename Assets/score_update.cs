using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_update : MonoBehaviour
{
    private board Boardscript;
    public GameObject main_object;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Boardscript = main_object.GetComponent<board>();
        text.SetText("{0}",Boardscript.score);
    }
}
