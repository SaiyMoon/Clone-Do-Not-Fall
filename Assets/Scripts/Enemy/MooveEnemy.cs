using UnityEngine;

public class MooveEnemy : MonoBehaviour
{
    public float SpeedEnemy = 15.0f;
    public float JumpForce = 5.0f;
    public float Distans = 20.0f;
    public string TagGround = "Ground";
    public string TagPlayer = "Player";

    private GameObject Player;
    private bool IsGround;
    private Vector3 MooveVector;
    private Rigidbody RbEnemy;

    private void Start()
    {
        RbEnemy = transform.GetComponent<Rigidbody>();
        ///RbEnemy.freezeRotation = true;
        Player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagGround)
        {
            IsGround = true;
        }

        if (collision.gameObject.tag == TagPlayer)
        {
            Rigidbody pl = collision.transform.GetComponent<Rigidbody>();            
            Vector3 directionForce = transform.position.x > pl.position.x ? Vector3.right : Vector3.left;
            pl.AddForce(directionForce * 80, ForceMode.Impulse);
        }
    }
       

    private void MooveLogic()
    {
        MooveVector = new Vector3(Player.transform.position.x - transform.position.x, 0.0f, Player.transform.position.z - transform.position.z);
        
        if (Mathf.Abs(MooveVector.x) < Distans || Mathf.Abs(MooveVector.z) < Distans)
        {
            Vector3 pos = transform.position;
            RbEnemy.velocity = MooveVector * SpeedEnemy * Time.deltaTime;                
        }
        else
        {
            RbEnemy.velocity = new Vector3(Random.Range(0, MooveVector.x), 0.0f, Random.Range(0, MooveVector.z)) * SpeedEnemy * Time.deltaTime;
        }
    }
    
    private void FixedUpdate()
    {
        MooveLogic();        
    }
}
