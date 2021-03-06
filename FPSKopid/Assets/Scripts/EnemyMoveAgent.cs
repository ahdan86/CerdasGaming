using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System;

public class EnemyMoveAgent : Agent
{
    public Transform targetTransform;
    [SerializeField] private float moveSpeed = 10f;

    List<Tuple<float, float>> respawnEnemy = new List<Tuple<float, float>>{
        new Tuple<float, float>(22, 34),
        new Tuple<float, float>(5, 34),
        new Tuple<float, float>(40, 34),
        new Tuple<float, float>(40, 30),
        new Tuple<float, float>(40, -1),
        new Tuple<float, float>(5, -1),
        new Tuple<float, float>(5, 30),
    };

    List<Tuple<float, float>> respawnPlayer = new List<Tuple<float, float>>{
        new Tuple<float, float>(22.297f, 16.83f),
        new Tuple<float, float>(4.58f, 16.83f),
        new Tuple<float, float>(40.15f, 16.83f),
        new Tuple<float, float>(22.02f, -0.11f),
        new Tuple<float, float>(5.18f, -0.11f),
        new Tuple<float, float>(14.24f, 17.23f),
        new Tuple<float, float>(31.08f, 17.23f),
        new Tuple<float, float>(22.2f, 9.5f),
        new Tuple<float, float>(22.2f, -0.63f),
        new Tuple<float, float>(22.2f, 25.33f),
        new Tuple<float, float>(22.2f, 34.48f),
        new Tuple<float, float>(12.94f, 27.63f),
        new Tuple<float, float>(12.94f, 35f),
        new Tuple<float, float>(12.94f, 18.27f),
        new Tuple<float, float>(12.94f, 8.56f),
        new Tuple<float, float>(12.94f, 0.82f),
        new Tuple<float, float>(30.15f, 17f),
        new Tuple<float, float>(30.15f, 2.95f),
        new Tuple<float, float>(30.15f, 26.63f),
        new Tuple<float, float>(13.38f, 25.4f),
        new Tuple<float, float>(33.22f, 25.4f),
        new Tuple<float, float>(33.22f, 9.17f),
        new Tuple<float, float>(13.14f, 9.17f),
    };

    /*
    public override void OnEpisodeBegin()
    {
        Tuple<float, float>newEnemyPos = respawnEnemy[UnityEngine.Random.Range(0,6)];
        Tuple<float, float>newPlayerPos = respawnPlayer[UnityEngine.Random.Range(0,22)];

        targetTransform.localPosition = new Vector3(newPlayerPos.Item1, 1.2f, newPlayerPos.Item2);
        transform.localPosition = new Vector3(newEnemyPos.Item1, 1.3f, newEnemyPos.Item2);
    }
    */

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        transform.localPosition += new Vector3(moveX, 0, moveZ)* Time.deltaTime * moveSpeed;
        //AddReward(-1f / MaxStep);
    }

    /*
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continousActions = actionsOut.ContinuousActions;
        continousActions[0] = Input.GetAxisRaw("Horizontal");
        continousActions[1] = Input.GetAxisRaw("Vertical");
    }
    */

    /*
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            SetReward(+2f);
            EndEpisode();
        }
        
        
        else if(other.gameObject.tag == "Wall")
        {
            SetReward(-1f);
            EndEpisode();
        }
    }
    */
    
}
