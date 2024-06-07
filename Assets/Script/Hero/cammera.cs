using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammera : MonoBehaviour
{

    public static bool cursorlocked = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Updatecursorlocked();

    }
    private void Updatecursorlocked()
    {
        if (cursorlocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.H))
            {
                cursorlocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.H))
            {
                cursorlocked = true;
            }
        }
    }

}
