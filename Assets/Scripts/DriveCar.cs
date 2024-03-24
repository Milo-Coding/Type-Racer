using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    // Update is called once per frame
    public void MoveCar(float ratio)
    {
        transform.Translate(0f, -ratio, 0f);
    }

    public void flip()
    {
        transform.Rotate(0, 0, 180);
    }
}
