using UnityEngine;

public class MooveConrollPlayer : MonoBehaviour
{
    public float Speed = 10;
    public float JumpForce = 5f;
    public Transform TransformCamera;
    public Vector3 OffsetCamera;
   
    public string TagGround = "Ground";

    private bool IsGround;
    private Vector3 MooveVector;
    private Rigidbody RbPlayer;
    private StikControll StikControll;
  
    private void Start()
    {
        RbPlayer = GetComponent<Rigidbody>();
        RbPlayer.freezeRotation = true;
        StikControll = GameObject.FindGameObjectWithTag("Joystic").GetComponent<StikControll>();
    }

    private void FixedUpdate()
    {
        MooveLogic();
        MooveCam();
    }

    #region MooveLogic
    private void MooveLogic()
    {
        MooveVector = Vector3.zero;
        MooveVector.x = StikControll.Horizontal();
        MooveVector.z = StikControll.Vertical();

        if (IsGround)
        {
            var move = new Vector3(MooveVector.x, 0, MooveVector.z) * Speed * Time.deltaTime;
            RbPlayer.AddForce(move, ForceMode.Impulse);
        }        
    }
    #endregion

    #region OnCollision
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == TagGround)
        {
            IsGround = value;
        }
    }
    #endregion

    private void MooveCam()
    {
        TransformCamera.position = new Vector3(transform.position.x + OffsetCamera.x,
            transform.position.y + OffsetCamera.y,
            transform.position.z + OffsetCamera.z);
    }

    public void JumpLogic()
    {
        if (IsGround && (Input.GetAxis("Jump") > 0))
        {
            RbPlayer.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
