using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HuntPlayer : MonoBehaviour
{
    [SerializeField] private float TargetDelay = 5f; // seconds between updates
    private Transform player;
    [SerializeField] private NavMeshAgent agent;

    private float timer = 0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set an initial destination
        agent.destination = player.position;
    }

    private void Update()
    {
        if (player == null) return;

        // Add time each frame
        timer += Time.deltaTime;

        // Only update destination if enough time has passed
        if (timer >= TargetDelay)
        {
            agent.destination = player.position;
            timer = 0f; // reset timer
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game Over");
            Debug.Log("Game Over!");
        }
    }
}