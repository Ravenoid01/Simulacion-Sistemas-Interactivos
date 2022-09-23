using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{

    [SerializeField] private float angleDeg;
    [SerializeField] private float radius = 1;
    [SerializeField] private float angularSpeed  = 5;
    [SerializeField] private float radiusSpeed = 5;
    private MyVector polarCord;


    void Start()
    {
        
    }

    void Update()
    {
        //Intento fallido
        //polarCord.radius += radiusSpeed * Time.deltaTime;
        //polarCord.angle += angularSpeed * Time.deltaTime;
        //MyVector cartesianPoint = PolarToCartesian(polarCord);
        //Debug.Drawline(Vector3.zero,cartesinaPoint);
        //transform.position = polarCord;

        Debug.DrawLine(new MyVector(0, 0), PolarToCartesian(angleDeg, radius));
        angleDeg = angleDeg + angularSpeed * Time.deltaTime;
        radius = radius + radiusSpeed * Time.deltaTime;
        transform.position = PolarToCartesian(angleDeg, radius);
    }
    private MyVector PolarToCartesian(float angle, float rad)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);
        return new MyVector(x * rad, y * rad);
    }
    //private MyVector PolarToCartesian(MyVector polar)
    //{ 
    //    return polar.FromPolarToCartesian()

    //}
}
