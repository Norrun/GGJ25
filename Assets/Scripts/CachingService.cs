using System;
using UnityEngine;

public class CachingService<T>
{
    T Cache;
    float time;
    float lastTime;

    Func<T, T, bool> cacheCondition;

    public CachingService(float time, Func<T, T, bool> cacheCondition)
    {
        this.time = time;
        this.cacheCondition = cacheCondition;
    }

    public T Check(T value)
    {
        if (Time.time <= lastTime + time)
        {
            return Cache;
        }

        if (cacheCondition(value, Cache))
        {
            Cache = value;
            lastTime = Time.time;
        }
        return value;
    }

}
