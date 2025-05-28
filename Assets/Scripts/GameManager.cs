using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int orbsActive = 2;
    public int ghostsActive = 20;
    
    public TextMeshProUGUI orbsText;
    public TextMeshProUGUI ghostCountText;

    private void Start()
    {
    }

    private void Update()
    {
        orbsText.text = "Orbes restantes: "+orbsActive;
        ghostCountText.text = "Fantasmas eliminados: "+ghostsActive;
        
        if (ghostsActive <= 0)
        {
            YouWin();
        }
        
        if (orbsActive <= 0)
        {
            YouLoose();
        }
    }

    public void YouWin()
    {
        
    }
    public void YouLoose()
    {
        
    }
}
