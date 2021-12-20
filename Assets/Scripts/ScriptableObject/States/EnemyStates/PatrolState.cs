using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : ScriptableState
{
    [SerializeField] protected float minDistance = 5f;
    public float MinDistance { get => minDistance; set => minDistance = value; }
    public override void OnEnterState(Enemy enemy)
    {
        enemy.Animancer.Play(enemy.ScriptableClips.RunClip);
        enemy.Agent.isStopped = false;
    }

    public override void OnUpdateState(Enemy enemy)
    {

        if (!enemy.Agent.pathPending  && enemy.Agent.remainingDistance<0.5f)// == NavMeshPathStatus.PathComplete)
        {
            //if (enemy.IA.Positions.Contains(enemy.DestinationPoint))
            //{
            //enemy.IA.Positions[enemy.DestinationPoint + 1] ;
            Vector3 nextDestination;
            //if(enemy.IA.Positions.Count >= enemy.DestinationPoint-1)
            //{
            try { 
                nextDestination = enemy.IA.Positions[enemy.DestinationPoint + 1];
                enemy.DestinationPoint++;
            }
            catch
            {
                nextDestination = enemy.IA.Positions[0];
                enemy.DestinationPoint = 0;
            }
            enemy.Agent.destination = nextDestination;
            /*var nextDestination = enemy.IA.Positions.Count >= enemy.DestinationPoint?
                (enemy.IA.Positions[enemy.DestinationPoint + 1]) : enemy.IA.Positions[0];

                        Debug.Log("next destination " + nextDestination);
            Debug.Log("IA Count " + enemy.IA.Positions.Count);
            Debug.Log("Destination count " + enemy.DestinationPoint);
            
            enemy.DestinationPoint= enemy.IA.Positions.Count>= enemy.DestinationPoint? enemy.DestinationPoint+1 : 0;*/




            /*enemy.Agent.destination = nextPoint >= enemy.IA.Positions.Count ?
                enemy.IA.Positions[nextPoint] : enemy.IA.Positions[0];*/
            /* }
             }
         }
         /*protected void OnValidate()
         {
             for (int i = 0; i < IA.Positions.Count; i++)
                 _patrolPoints[i] = IA.Positions[i];
         }*/
        }
    }

    public override void OnExitState(Enemy enemy)
    {
    }
}
