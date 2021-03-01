using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGames : MonoBehaviour
{
    public GameObject MooveControllPlayer;

    private Vector3 PosPlayer;

    void Start()
    {
        PosPlayer = MooveControllPlayer.transform.position;      
    }

    
    void Update()
    {
        if(PosPlayer.y < -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
