﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids_script : MonoBehaviour
{
    // Variables
    public Rigidbody2D rigid_body;
    public float max_thrust;
    public float max_torque;   
    // for screen wrap
    // make values flexible, maybe based on camera
    public float screen_top;
    public float screen_bottom;
    public float screen_left;
    public float screen_right;


    // Start is called before the first frame update
    void Start()
    {
        // Adds thrust
        Vector2 thrust = new Vector2(Random.Range(-max_thrust, max_thrust), Random.Range(-max_thrust, max_thrust));
        rigid_body.AddForce(thrust);

        // Adds torque
        float torque = Random.Range(-max_torque, max_torque);
        rigid_body.AddTorque(torque);

    }

    // Update is called once per frame
    void Update()
    {
        screen_wrap();
    }

    void screen_wrap() // Teleports asteroid to the opposite end of the screen
    {
        if (transform.position.y > screen_top)
        {
            Vector2 current_position = transform.position;
            current_position.y = screen_bottom;
            transform.position = current_position;
        }
        if (transform.position.y < screen_bottom)
        {
            Vector2 current_position = transform.position;
            current_position.y = screen_top;
            transform.position = current_position;
        }
        if (transform.position.x > screen_right)
        {
            Vector2 current_position = transform.position;
            current_position.x = screen_left;
            transform.position = current_position;
        }
        if (transform.position.x < screen_left)
        {
            Vector2 current_position = transform.position;
            current_position.x = screen_right;
            transform.position = current_position;
        }
    }
}