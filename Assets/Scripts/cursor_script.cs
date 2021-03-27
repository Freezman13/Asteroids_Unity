using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor_script : MonoBehaviour
{
    // initializing the cursor
    public Texture2D cursor;

    private void change_cursor(Texture2D cursor_type)
    {
        Vector2 hotspot = new Vector2(cursor_type.width / 2, cursor_type.height / 2);
        Cursor.SetCursor(cursor_type, hotspot, CursorMode.Auto);
    }

  //  private void Awake()
    //{
        
  //  }

    // Start is called before the first frame update
    void Start()
    {
        change_cursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
