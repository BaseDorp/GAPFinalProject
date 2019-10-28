using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveSystem : ComponentSystem
{
    float movementSpeed = 4f;

    protected override void OnUpdate()
    {
        // Code executes for entities that contains a translation component
        Entities.ForEach((ref Translation translation) =>
        {
            translation.Value.y += movementSpeed * Time.deltaTime;
            // Changes the entity's direction if it reaches the top or bottom of the screen
            if (translation.Value.y > 3f)
            {
                movementSpeed = -math.abs(movementSpeed);
            }
            if (translation.Value.y < -3f)
            {
                movementSpeed = +math.abs(movementSpeed);
            }
        });
    }
}