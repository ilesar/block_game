using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public class TerrainCollider : MonoBehaviour
    {
        public static Vector3 WorldPosition;
    
        // private void Update()
        // {
        //     if (!Camera.main)
        //     {
        //         throw new Exception("Camera missing");
        //     }
        //
        //     Plane plane = new Plane(Vector3.up, 0);
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     // Debug.Log("Aiming...");
        //     
        //     if (!plane.Raycast(ray, out float distance))
        //     {
        //         return;
        //     }
        //     
        //     // Debug.Log("HIT!!!!");
        //     WorldPosition = ray.GetPoint(distance);
        // }
    }    
}
