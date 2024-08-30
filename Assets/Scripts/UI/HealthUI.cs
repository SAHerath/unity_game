using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // public GameObject heart;
    private List<Image> hearts = new List<Image>();

    // PlayerHealth playerHealth;

    public void SetMaxHearts(int maxHearts)
    {
        foreach(Image heart in hearts)
        {
            Destroy(heart.gameObject);
        }

        hearts.Clear();

        for(int i=0; i<maxHearts; i++)
        {
            Image newHeart = Instantiate(heart, transform);
            newHeart.sprite = fullHeart;
            hearts.Add(newHeart);
        }
    }


    public void UpdateHearts(int currentHealth)
    {
        for(int i=0; i<hearts.Count; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptyHeart;
            }
        }

    }

}
