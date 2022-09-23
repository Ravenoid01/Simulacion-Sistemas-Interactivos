using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperimentV2 : MonoBehaviour
{
    [SerializeField] private float angularSpeed = 5;
    [SerializeField] private float radiusSpeed = 5;
    [SerializeField] private float radiusAcceleration = 5;
    [SerializeField] private float angularAcceleration = 5;
    private MyVector polarCord;


    void Start()
    {
        polarCord = new MyVector(0, 0);
    }

    void Update()
    {
        MyVector cartesianpoint = polartocartesian(polarCord);

        radiusSpeed += radiusAcceleration * Time.deltaTime;
        polarCord.radius += radiusSpeed * Time.deltaTime;

        angularSpeed += angularAcceleration * Time.deltaTime;
        polarCord.angle += angularSpeed * Time.deltaTime;

        if(Mathf.Abs(polarCord.radius) >= 5)
        {
            if (Mathf.Abs(radiusAcceleration) > 0)
            {
                radiusAcceleration = -radiusAcceleration;
            }
            else
            {
                radiusSpeed = -radiusSpeed;
            }
        }

        Debug.DrawLine(Vector3.zero, cartesianpoint);
        transform.position = cartesianpoint;
    }

    private MyVector polartocartesian(MyVector polar)
    {
        return polar.FromPolarToCartesian();

    }
}

