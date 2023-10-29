using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charcter_ : MonoBehaviour
{
    public  GameObject[] charcter;
    [SerializeField] Sprite[] sprite;
    [SerializeField] Image image;
    public void addnumber(bool isnext)
    {
        charcter_spawoner.index = isnext ? charcter_spawoner.index + 1 : charcter_spawoner.index - 1;
        if (charcter_spawoner.index >= charcter.Length)
        {
            charcter_spawoner.index = 0;
        }
        else if(charcter_spawoner.index < 0)
        {
            charcter_spawoner.index = charcter.Length - 1;
        }
    }
    public void image_change()
    {
        image.sprite = sprite[charcter_spawoner.index];
    }
    public void loadscene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
