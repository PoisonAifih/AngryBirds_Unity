using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject YouWinUI;
    public GameObject YouLoseUI;
    public int totalPig;
    public float taim = 2f;
    public GameObject[] peluru;
    public int totalPeluru;
    public Text sisaPeluru;
    public int index = 0;



    // Start is called before the first frame update
    void Start()
    {
        totalPig = FindObjectsOfType<pig>().Length;
        totalPeluru = FindObjectsOfType<red>().Length;
        sisaPeluru.text = "X" + totalPeluru;
        YouWinUI.SetActive(false);
        YouLoseUI.SetActive(false);
        foreach(GameObject bird in peluru)
        {
            bird.SetActive(false);
        }
        peluru[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void killCount()
    {
        totalPig -= 1;
        if(totalPig == 0)
        {
            StartCoroutine(YouWin());      
        }

    }

    IEnumerator YouWin()
    {
        yield return new WaitForSeconds(taim);
        YouWinUI.SetActive(true);
    }

    IEnumerator YouLose()
    {
        yield return new WaitForSeconds(taim);
        YouLoseUI.SetActive(true);
    }
    public void reload()
    {
        if(index < peluru.Length -1)
        {
            totalPeluru -= 1;
            index += 1;
            sisaPeluru.text = "X" + totalPeluru;
            peluru[index].SetActive(true);
        }
    }
        
}
