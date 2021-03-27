using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_ship_script : MonoBehaviour
{
    // Variables
    public Rigidbody2D rigid_body;
    // for defining the speed
    public float vertical_speed = 10; 
    public float horizontal_speed = 10;
    // for applying the speed
    private float veritcal_input; 
    private float horizontal_input;
    // for screen wrap
                                // make values flexible, maybe based on camera
    public float screen_top;
    public float screen_bottom;
    public float screen_left;
    public float screen_right;
    // bullets
    public GameObject bullet;
    Vector2 direction_value;
    public float bullet_speed = 10;


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

        // // Teleports ship to the opposite end of the screen
        screen_wrap();

        // Rotates the ship towards the cursro
        face_cursor();

        // Fires bullets
        fire_primary(direction_value);
    }

    private void FixedUpdate() // A Unity function - dedicated physics updater
    {
        // Moves ship along x / y based on input
        move_ship();


    }

    void move_ship() // Moves ship along x / y based on input
    {
        transform.position = transform.position + new Vector3(horizontal_input * horizontal_speed * Time.deltaTime, veritcal_input * vertical_speed * Time.deltaTime, 0);
    }

    void screen_wrap() // Teleports ship to the opposite end of the screen
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

    void face_cursor() // Rotates the ship towards the cursro
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction_cursor = new Vector2
        (
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        transform.up = direction_cursor;

        // Stores where the ship is pointing, used to fire in the same direction
        direction_storage(direction_cursor);
    }

    void direction_storage(Vector2 direction_cursor)
    {
        direction_value = direction_cursor;
    }

    void fire_primary(Vector2 direction_value)
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject new_bullet = Instantiate(bullet, transform.position, transform.rotation);
            new_bullet.GetComponent<Rigidbody2D>().velocity = direction_value.normalized * bullet_speed;
            Destroy(new_bullet, 4.0f);
        }
    }
}
