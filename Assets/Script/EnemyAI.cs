using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints; 
    public float moveSpeed = 2f; 
    public float detectionRange = 3f; 
    private int currentWaypointIndex = 0;
    private Transform player; 
     private Rigidbody2D rb; 
    private  Animator anim;
    private bool IsMovingforward = true;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol(); 
        CheckForPlayer(); 
    }

    void Patrol()
    {

        if (waypoints.Length == 0)
            return;


        Vector2 target = waypoints[currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        float angle = Mathf.Atan2(target.y , target.x) * Mathf.Rad2Deg;
        angle = (angle+360)%360;
        if (angle > 45 && angle<= 135)
        {
            anim.SetTrigger("forward");
        }
        else if (angle > 135 && angle<= 225)
        {
            anim.SetTrigger("side");
        }
        else if ( angle > 225 && angle<= 315 || (angle >= 0 && angle <= 45))
        {
            anim.SetTrigger("backward");
        }
        //transform.rotation = Quaternion.AngleAxis(angle , Vector3.forward); 
        
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            if (IsMovingforward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length-1)
                {
                    IsMovingforward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex == 0 )
                {
                    IsMovingforward = true;
                }
            }
        }
    }

    void CheckForPlayer()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    
        if (distanceToPlayer < detectionRange)
        {
            Debug.Log("Player Lose!"); // Ganti dengan aksi yang sesuai, misalnya mengakhiri permainan
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnDrawGizmos()
    {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
