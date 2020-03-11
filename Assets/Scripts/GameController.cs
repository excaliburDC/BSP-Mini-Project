using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonManager<GameController>
{
    public EnemyStateController stateController;
    public List<Transform> wayPoints;


    private void Awake()
    {
        wayPoints = new List<Transform>();
        stateController = GetComponent<EnemyStateController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stateController.SetupAI(true, wayPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
