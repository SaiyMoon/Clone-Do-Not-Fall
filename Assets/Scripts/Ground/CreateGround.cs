using UnityEngine;
using System.Collections;


public class CreateGround : MonoBehaviour
{
    public string TagGround = "Ground";
    public int Height = 200; 
    public int Width = 200;  
    public int maxTimer = 10;
    public Transform StartPos;
    public GameObject Prefab;
   
    [SerializeField]
    public GameObject[] CellPrefab;    
    
    private void Awake()
    {
        GeneratorGround();
    }

    private void GeneratorGround()
    {        
        for (int z = 0; z < Height; ++z)
        {           
            for (int x = 0; x < Width; x++)
            {                
                GameObject ground = Instantiate(Prefab, StartPos.position, Quaternion.identity);
                ground.transform.position = new Vector3(x, 0, z);                
            }
        }        
    }

    private void Start()
    {
        CellPrefab = GameObject.FindGameObjectsWithTag(TagGround);
    }


    private IEnumerator SwitchGround()
    {
        for (; ; )
        {            
            var a = Random.Range(0, CellPrefab.Length);
            if (CellPrefab[a].activeSelf)
            {
                Destroy(CellPrefab[a]);
            }
            yield return new WaitForSeconds(Random.Range(1, maxTimer));
        }
    }

    private void Update()
    {
        StartCoroutine("SwitchGround");
    }
}
