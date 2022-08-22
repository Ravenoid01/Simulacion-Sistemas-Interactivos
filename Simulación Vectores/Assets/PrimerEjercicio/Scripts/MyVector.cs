
using UnityEngine;
using System.Reflection;

[System.Serializable]
public class MyVector 
{
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;

    }
    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(x, y, 0), color);
    }
    public void Draw(Color color, MyVector origin)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x+ origin.x, y+ origin.y, 0), color);
    }

    public static MyVector operator+(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y);
    }
    public static MyVector operator-(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y);
    }
    public static MyVector operator*(MyVector a, float b)
    {
        return new MyVector(a.x * b, a.y * b);
    }
    public static MyVector operator *(float b, MyVector a)
    {
        return new MyVector(b * a.x, b * a.y);
    }
    public MyVector Mix (MyVector b, float c)
    {
        return this + (b - this) * c;
    }

    //Actividad 2
    public static implicit operator Vector3(MyVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }
    public static implicit operator MyVector(Vector3 a)
    {
        return new MyVector(a.x, a.y);
    }
    public static MyVector operator /(MyVector a, float b)
    {
        return new MyVector(a.x / b, a.y / b);
    }

}
