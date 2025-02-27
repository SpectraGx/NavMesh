using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine<Entity_Type>
{
    // The pointer that indicate an agent who own this instance
    Entity_Type m_pOwner;

    State<Entity_Type> m_pCurrentState;

    // Trace of last state that this agent constituted.
    State<Entity_Type> m_pPreviousState;

    // This state logic will be called whenever FSM is updated.
    State<Entity_Type> m_pGlobalState;

    public StateMachine(Entity_Type owner)
    {
        m_pOwner = owner;
        m_pCurrentState = null;
        m_pPreviousState = null;
        m_pGlobalState = null;
    }
      
        


    // Use those method to initiate FSM.
    public void SetCurrentState(State<Entity_Type> s) 
    {
        
        if (s == null)
        {
            Debug.Log("<StateMachine::ChangeState>: trying to change to a null state");
        }

        if(m_pPreviousState != null)
        {
            m_pPreviousState = m_pCurrentState;
            m_pCurrentState.Exit(m_pOwner);

        }
        // Maintain previous state


        // Call Exit method of Current state

        
        // Change to new state
        m_pCurrentState = s;

        // Call Enter method of New state
        m_pCurrentState.Enter(m_pOwner);

    }
    public void SetGlobalState(State<Entity_Type> s) { m_pGlobalState = s; }
    public void SetPreviousState(State<Entity_Type> s) { m_pPreviousState = s; }

    // Use this method to uptate FSM
    public void Updating()
    {

        // If static state is existed, call execute method
        if (m_pGlobalState)
            m_pGlobalState.Execute(m_pOwner);
        // Just same as now state
        if (m_pCurrentState)
            m_pCurrentState.Execute(m_pOwner);
    }

    // Chage to New state
    public void ChangeState(State<Entity_Type> pNewState)
    {
        if (pNewState == null)
        {
            Debug.Log("<StateMachine::ChangeState>: trying to change to a null state");
        }

        if (m_pPreviousState != null)
        {
            m_pPreviousState = m_pCurrentState;
            
        }

        m_pCurrentState.Exit(m_pOwner);
        // Change to new state
        m_pCurrentState = pNewState;

        // Call Enter method of New state
        m_pCurrentState.Enter(m_pOwner);
    }

    // Revert the state to Previous State
    public void RevertToPreviousState()
    {
        ChangeState(m_pPreviousState);
    }

    // accessor
    State<Entity_Type> CurrentState()
    {
        return m_pCurrentState;
    }
    State<Entity_Type> GlobalState()
    {
        return m_pGlobalState;
    }
    State<Entity_Type> PreviousState()
    {
        return m_pPreviousState;
    }

    // Return true when argument is same to Now state
    public bool IsInstate(State<Entity_Type> st)
    {
        if (st == CurrentState()) return true;
        else return false;
    }

}