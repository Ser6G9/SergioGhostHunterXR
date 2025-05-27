using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public int health = 3;

    public GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            gameManager.orbsActive--;
            Destroy(gameObject);
        }
    }
}
