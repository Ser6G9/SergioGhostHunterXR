using System.Collections;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab;
    public GameManager gameManager;
    
    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset = -1.5f;
    
    
    void Start()
    {
        MRUK.Instance.RegisterSceneLoadedCallback(SpawnOrbs);
        
    }

    private void SpawnOrbs()
    {
        for (int i = 0; i < gameManager.orbsActive; i++)
        {
            MRUKRoom room = MRUK.Instance.GetCurrentRoom();
                 
            int currentTry = 0;
            while (currentTry < 100)
            {
                bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);
                if (hasFoundPosition)
                {
                    Vector3 randomPosition = pos + norm * normalOffset;
                    //randomPosition.y = 0f;
                    Instantiate(orbPrefab, randomPosition, Quaternion.identity);
                    return;
                }
                else
                {
                    currentTry++;
                }
            }
        }
        
    }
}
