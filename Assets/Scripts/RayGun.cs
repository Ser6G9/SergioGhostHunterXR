using UnityEngine;

public class RayGun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public Transform shootPoint;
    public float maxLineDistance = 5f;
    public float lineShowTimer = 0.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            // Debug.Log("Shoot");
            LineRenderer line = Instantiate(linePrefab);
            line.positionCount = 2;
            line.SetPosition(0, shootPoint.position);
            Vector3 endPoint = shootPoint.position + shootPoint.forward * maxLineDistance;
            line.SetPosition(1, endPoint);
            Destroy(line.gameObject, lineShowTimer);
        }
    }
}
