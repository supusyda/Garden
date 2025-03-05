using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : Spawner
{
    public static CountdownManager Instance;
    private Dictionary<int, CountdownData> countdowns = new Dictionary<int, CountdownData>();
    private int idCounter = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {



        float deltaTime = Time.deltaTime;
        foreach (var key in new List<int>(countdowns.Keys))
        {
            CountdownData data = countdowns[key];
            data.TimeLeft -= deltaTime;
            if (data.TimeLeft <= 0)
            {
                data.OnComplete?.Invoke();
                countdowns.Remove(key);
            }
            else
            {
                data.OnUpdate?.Invoke(Mathf.CeilToInt(data.TimeLeft));
            }
        }

    }

    public void SpawnCountdown(Vector2 spawnPos, int time)
    {
        Vector2 offSetY = spawnPos;
        offSetY.y += 0.5f;
        Countdown countdown = base.SpawnThing(offSetY, Quaternion.identity, "CountdownPrefab").GetComponent<Countdown>();
        countdown.SetCountdown(time);
        countdown.gameObject.SetActive(true);
    }
    public void OnBeginCountdown(Component sender, object data)
    {
        if (data is OnBeginCountdownParamData onBeginCountdownParamData)
        {
            SpawnCountdown(onBeginCountdownParamData.Position, onBeginCountdownParamData.Time);
        }
    }
    public int StartCountdown(float duration, Action<int> onUpdate, Action onComplete = null)
    {
        idCounter++;
        countdowns[idCounter] = new CountdownData { TimeLeft = duration, OnUpdate = onUpdate, OnComplete = onComplete };
        return idCounter;
    }

    public void StopCountdown(int id)
    {
        if (!countdowns.ContainsKey(id)) return;


        countdowns.Remove(id);
    }

    private class CountdownData
    {
        public float TimeLeft;
        public Action<int> OnUpdate;
        public Action OnComplete;

    }
}
public class OnBeginCountdownParamData
{
    public Vector2 Position;
    public int Time;
}