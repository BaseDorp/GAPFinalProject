using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Test : MonoBehaviour
{
    public int NumberofEntities = 1;
    [SerializeField]
    private Mesh mesh;
    [SerializeField]
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // Manager that looks over all the entities
        EntityManager entityManager = World.Active.EntityManager;

        // Attributes that the Entities have
        EntityArchetype entityArchetype = entityManager.CreateArchetype( 
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(NumberofEntities, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            // Spawns each entity in a random location
            entityManager.SetComponentData(entity, new Translation { Value = new float3(UnityEngine.Random.Range(-8, 8), UnityEngine.Random.Range(-5, 5), 0) });

            // Assigns the mesh and material to each entity
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = mat,
            });
        }

        //Empty the native array
        entityArray.Dispose();
    }
}
