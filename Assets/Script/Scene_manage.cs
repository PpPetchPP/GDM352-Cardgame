using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manage : MonoBehaviour
{
    static int coin = 5;
    static bool Got_Reward = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bb() 
    {
        SceneManager.LoadScene(0);
    }
    public void Set_Coin(int value) 
    {
        coin = value;
    }
    public int Get_Coin()
    {
        return coin;
    }
    public void GoGo() 
    {
        SceneManager.LoadScene(1);
    }
    public bool Get_Reward()
    {
        return Got_Reward;
    }
    public void Set_Reward(bool value)
    {
        Got_Reward = value;
    }
}
