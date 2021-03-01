using UnityEngine;

public class InstEnemy : MonoBehaviour
{
    public GameObject Prefab;
    public int MinEnemy = 1;
    public int MaxEnemy = 10;

    public GameObject Ground;

    private Vector3 Pole;
    private void Start()
    {
        Pole.x = Ground.transform.GetComponent<CreateGround>().Height;
        Pole.z = Ground.transform.GetComponent<CreateGround>().Width;
        for (int i = 0; i < Random.Range(MinEnemy, MaxEnemy); i++)
        {
            Instantiate(Prefab, new Vector3(Random.Range(0, Pole.x), 0.5f, Random.Range(0, Pole.z)), Quaternion.identity);
        }        
    }
}
