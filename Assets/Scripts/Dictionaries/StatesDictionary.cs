using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class StatesDictionary
{

    public static Dictionary<Type, List<Type>> stateTransitions = new Dictionary<Type, List<Type>>()
    {
        {
            typeof(BatAttackState), new List<Type>
            {
                typeof(DieState),
                typeof(BatPatrolState),
                typeof(BatChaseState)
            }
        },
        {
            typeof(BatChaseState), new List<Type>
            {
                typeof(DieState),
                typeof(BatPatrolState),
                typeof(BatAttackState)
            }
        },
        {
            typeof(BeeAttackState), new List<Type>
            {
                typeof(BeePointState),
                typeof(DieState),
                typeof(BeeIddleState),
                typeof(BeePatrolState),
                typeof(BeeChaseState)
            }
        },
        {
            typeof(BeePointState), new List<Type>
            {
                typeof(BeeAttackState),
                typeof(DieState),
                typeof(BeeIddleState),
                typeof(BeePatrolState),
                typeof(BeeChaseState)
            }
        },
        {
            typeof(DieState), new List<Type>
            {
            }
        },
        {
            typeof(BeeIddleState), new List<Type>
            {
                typeof(WakeUpState),
                typeof(BeeChaseState),
                typeof(BeeAttackState),
                typeof(BeePointState),
                typeof(DieState)
            }
        },
        {
            typeof(BatIddleState), new List<Type>
            {
                typeof(WakeUpState),
                typeof(DieState)
            }
        },
        {
            typeof(BatPatrolState), new List<Type>
            {
                typeof(BatAttackState),
                typeof(DieState),
                typeof(BatChaseState)
            }
        },
        {
            typeof(BeePatrolState), new List<Type>
            {
                typeof(BeeAttackState),
                typeof(BeePointState),
                typeof(BeeIddleState),
                typeof(DieState),
                typeof(BeeChaseState)
            }
        },
        {
            typeof(BeeChaseState), new List<Type>
            {
                typeof(BeeAttackState),
                typeof(BeePointState),
                typeof(BeeIddleState),
                typeof(DieState),
                typeof(BeePatrolState)
            }
        },
        {
            typeof(WakeUpState), new List<Type>
            {
                typeof(BatAttackState),
                typeof(BatChaseState),
                typeof(BatPatrolState),
                typeof(DieState)
            }
        }
    };
}
