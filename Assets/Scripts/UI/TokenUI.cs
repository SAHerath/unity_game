using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// namespace Platformer.Gameplay
// {

    public class TokenUI : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;
        public int count = 0;

        // Start is called before the first frame update
        // public void Awake()
        // {
        //     if(!instances)
        //     {
        //         instances = this;
        //     }
        // }

        public void UpdateToken(int tokenValue)
        {
            count += tokenValue;
            textMesh.text = count.ToString();
        }
    }
// }
