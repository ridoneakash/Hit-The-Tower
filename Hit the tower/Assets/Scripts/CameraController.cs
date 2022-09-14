using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool domovment = true;
    public float panSpeed = 30.0f;
    private float panBorder = 10.0f;
    public float scrollSpeed = 5.0f;
    public float minY = 15.0f;
    public float maxY = 80.0f;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            domovment = !domovment;
                    
        }

        if (!domovment)
            return;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }


        if (Input.GetKey("s") || Input.mousePosition.y <=  panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }


        if (Input.GetKey("a") || Input.mousePosition.x <=   panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }


        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 800 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        
    }
}
