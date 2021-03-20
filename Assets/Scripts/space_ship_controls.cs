using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_ship_controls : MonoBehaviour
{
    // Variables
    public Rigidbody2D rigid_body;
    public float vertical_speed = 10; // for defining the speed
    public float horizontal_speed = 10;
    private float veritcal_input; // for applying the speed
    private float horizontal_input;
    public float screen_top;
    public float screen_bottom;
    public float screen_left;
    public float screen_right;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input from keyboard // Uses Edit -> Project Settings -> Input Manager
        veritcal_input = Input.GetAxis("Vertical");
        horizontal_input = Input.GetAxis("Horizontal");

        // Screen wraping
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

    private void FixedUpdate() // A Unity function - dedicated physics updater
    {
        // rigid_body.AddRelativeForce(Vector2.up * input_forward); // applied Y axis force

        //update the position
        transform.position = transform.position + new Vector3(horizontal_input * horizontal_speed * Time.deltaTime, veritcal_input * vertical_speed * Time.deltaTime, 0);

    }
}
