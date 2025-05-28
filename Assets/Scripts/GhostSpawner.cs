using System.Collections;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    public GameObject ghostPrefab;
    public GameManager gameManager;
    
    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset = -1.5f;
    
    
    void Start()
    {
        StartCoroutine(SpawnGhostsCoroutine());
    }

    private IEnumerator SpawnGhostsCoroutine()
    {
        while (gameManager.ghostsActive > 0)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnGhost();
            gameManager.ghostsActive--;                        
        }
    }

    private void SpawnGhost()
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
                Instantiate(ghostPrefab, randomPosition, Quaternion.identity);
                return;
            }
            else
            {
                currentTry++;
            }
        }
    }
    
}
