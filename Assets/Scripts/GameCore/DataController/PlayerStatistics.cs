using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerStatistics
{
    public int sequenceID;
    //public float PositionX, PositionY, PositionZ;
    public float[] totalTime = new float[100];
    public float[] reactionTime = new float[100];
    public int[] orderErrors = new int[100];

    public PlayerStatistics()
    {
        Array.Clear(totalTime, 0, totalTime.Length);
        Array.Clear(reactionTime, 0, reactionTime.Length);
        Array.Clear(orderErrors, 0, orderErrors.Length);
    }

    public void SetPlayerStatistics(int sequenceID, float totalTime,
        float reactionTime, int orderErrors)
    {
        this.sequenceID = sequenceID;
        this.totalTime[sequenceID] = totalTime;
        this.reactionTime[sequenceID] = reactionTime;
        this.orderErrors[sequenceID] = orderErrors;
    }

    public float GetTotalTime(int id)
    {
        return this.totalTime[id];
    }

    public float GetReactionTime(int id)
    {
        return this.reactionTime[id];
    }

    public float GetOrderErrors(int id)
    {
        return this.orderErrors[id];
    }
}
