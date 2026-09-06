using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public float panSpeed = 30f;
     public float panBorderThickness = 10f;
     public float scrollSpeed = 5f;
     public float minY = 10f;
     public float maxY = 80f;

     private bool doMovement = true;

     private void Update()
     {
          if (Input.GetKeyDown(KeyCode.Escape))
          {
               doMovement = !doMovement;
          }
          
          if (!doMovement)
          {
               return;
          }
          
          if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
          {
               // Using Space.World to make sure the camera moves in world space, not local space.
               transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
          }
          if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
          {
               // Using Space.World to make sure the camera moves in world space, not local space.
               transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
          }
          if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
          {
               // Using Space.World to make sure the camera moves in world space, not local space.
               transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);
          }
          if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
          {
               // Using Space.World to make sure the camera moves in world space, not local space.
               transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
          }

          float scroll = Input.GetAxis("Mouse ScrollWheel");

          Vector3 position = transform.position;

          position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
          position.y = Mathf.Clamp(position.y, minY, maxY);

          transform.position = position;
     }
}
