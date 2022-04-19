using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System;

public class EnemyMoveAgent : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float moveSpeed = 10f;
    private Vector3 beginPosition;

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
    };

    public override void OnEpisodeBegin()
    {
        Tuple<float, float>newEnemyPos = respawnEnemy[UnityEngine.Random.Range(0,6)];
        Tuple<float, float>newPlayerPos = respawnPlayer[UnityEngine.Random.Range(0,6)];

        targetTransform.localPosition = new Vector3(newPlayerPos.Item1, 0, newPlayerPos.Item2);
        transform.localPosition = new Vector3(newEnemyPos.Item1, 0, newEnemyPos.Item2);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        transform.localPosition += (new Vector3(moveX, 0, moveZ)).normalized * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continousActions = actionsOut.ContinuousActions;
        continousActions[0] = Input.GetAxisRaw("Horizontal");
        continousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void Start()
    {
        beginPosition = transform.localPosition;
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            SetReward(+1f);
        }
        else if(other.gameObject.tag == "Wall")
        {
            SetReward(-1f);
        }
        EndEpisode();
    }
}
