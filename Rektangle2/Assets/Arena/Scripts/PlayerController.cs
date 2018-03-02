using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 0.01f;
    private const float Restitution = 0.98f;
    private Vector3 _velocity;
    private int sidesNumber = 3;

    private Mesh mesh;

    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().mesh;
    }

    void FixedUpdate()
    {
        _velocity *= Restitution;

        Vector3 acceleration = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) { acceleration.z += 1; }
        if (Input.GetKey(KeyCode.A)) { acceleration.x -= 1; }
        if (Input.GetKey(KeyCode.S)) { acceleration.z -= 1; }
        if (Input.GetKey(KeyCode.D)) { acceleration.x += 1; }

        _velocity += acceleration.normalized * Speed;

        transform.position += _velocity;

        if (Input.GetKey(KeyCode.E)) { sidesNumber += 1; }
        if (Input.GetKey(KeyCode.Q)) { sidesNumber -= 1; }

        mesh = CreateMesh(sidesNumber, 1);
    }


    private Mesh CreateMesh(int sides, float radius)
    {
        if (sides < 3)
            throw new System.ArgumentException("Polygon must have 3 sides or more.");

        List<Vector3> points = new List<Vector3>();
        float step = 360.0f / sides;

        float angle = 0;
        for (double i = 0; i < 360.0; i += step) //go in a full circle
        {
            Vector2 temp = DegreesToXY(angle, radius);
            points.Add(new Vector3(temp.x, 0, temp.y)); //code snippet from above
            angle += step;
        }

        return points.ToArray();
    }

    private Vector2 DegreesToXY(float degrees, float radius)
    {
        Vector2 xy = new Vector2();
        double radians = degrees * Math.PI / 180.0;

        xy.x = (float)Math.Cos(radians) * radius;
        xy.y = (float)Math.Sin(-radians) * radius;

        return xy;
    }
}
