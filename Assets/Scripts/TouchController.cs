using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchController : MonoBehaviour {

    public GameObject Girl;
    public float Speed = 0.1f;

    void Update()
    {
        if (Girl != null)
        {
            //Girl.transform.localPosition=new Vector3(0,-0.063f,0);
        }
#if ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR)

        //Touch
        int touchCount = Input.touchCount;
        
        if (touchCount == 1)
        {
            
            Touch t = Input.GetTouch(0);
            if(EventSystem.current.IsPointerOverGameObject(t.fingerId))return;
            
            switch (t.phase)
            {
            case TouchPhase.Moved:
                
                float xAngle = t.deltaPosition.y * Speed;
                float yAngle = -t.deltaPosition.x * Speed;
                float zAngle = 0;
                
              //  Cube.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
               if (Girl!=null)
            {
                Girl.transform.RotateAround(Girl.transform.position, Girl.transform.up, -yAngle);
            }
                break;
            }
            
        }

#else
        //Mouse
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            float xAngle = Input.GetAxis("Mouse Y") * Speed * 80;
            float yAngle = -Input.GetAxis("Mouse X") * Speed * 80;
            float zAngle = 0;

            // Cube.transform.Rotate (xAngle, yAngle, zAngle, Space.World);
            if (Girl!=null)
            {
                Girl.transform.RotateAround(Girl.transform.position, Girl.transform.up, -yAngle);
            }
        }
#endif
    }
}
