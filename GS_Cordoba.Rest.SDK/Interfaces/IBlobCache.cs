﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IBlobCache
    {
        Task<T> GetOrFetchObject<T>(string key, Func<Task<T>> get, DateTimeOffset absoluteExpiration);
        List<string> GetAllKeys();
        void Invalidate(string key);
        void InvalidateAll();
    }
}
