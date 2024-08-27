using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;     // stores camera component

    // Start is called before the first frame update
    void Start()
    {
        // gets the GameObject's camera component
        cam = GetComponent<Camera>();

        // hide the mouse cursor at the centre of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;

        // centre of screen and caters for font size
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        // displays "*" in the crentre of screen
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        // on left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // get point in the middle of the screen
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

            // create a ray from the point in the direction of the camera
            Ray ray = cam.ScreenPointToRay(point);

            RaycastHit hit; // stores ray intersection information

            // ray cast will obtain hit information if it intersects anything
            if (Physics.Raycast(ray, out hit))
            {
                // get the GameObject that was hit
                GameObject hitObject = hit.transform.gameObject;

                ChangeColour target = hitObject.GetComponent<ChangeColour>();

                if (target != null)
                {
                    target.SetRandomColor();
                }
                else
                {
                    StartCoroutine(SphereIndicate(hit.point));

                }
            }
        }
    }

    IEnumerator SphereIndicate(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);
        /*while (true)
        {
            yield return new WaitForEndOfFrame();
            yield return null;
        }*/
        

        Destroy(sphere);
    }
}
