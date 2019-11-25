using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Rendering;

public class CubeDots : MonoBehaviour
{
    [SerializeField]
    Mesh mesh;
    [SerializeField]
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype
            (
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(2, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = mat
            });
        }

        entityArray.Dispose();
    }
}
