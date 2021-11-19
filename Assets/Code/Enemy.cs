using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Renderer renderer;
    UnityEngine.AI.NavMeshAgent _navMeshAgent;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player =  GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        print(GlobalVar.Seen);
        _navMeshAgent.enabled = !GlobalVar.Seen;
        if(_navMeshAgent.enabled)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
