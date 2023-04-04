using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class horse_anim : MonoBehaviour
{
    public GameObject player;
    private board Boardscript;
    public GameObject main_object;
    private Animator anim_control;

    //public float anim;
    // Start is called before the first frame update
    void Start()
    {
        anim_control = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Boardscript = main_object.GetComponent<board>();
        anim_control.SetBool("move", Boardscript.move);
        if (Boardscript.done == true)
        {
            if (Boardscript.markers == 0)
            {

                if (Boardscript.score != 64)
                {
                    anim_control.SetBool("lost", true);
                }
                else
                {
                    anim_control.SetBool("won", true);
                }
            }
        }
    }
}
