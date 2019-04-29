﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform Player;
    static Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.position, this.transform.position) < 10)
        {
            Vector3 direction = Player.position - this.transform.position;
            direction.y = 0; 

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


            anim.SetBool("isIdle", false);
            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);

            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);

            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);



        }

    }
}
