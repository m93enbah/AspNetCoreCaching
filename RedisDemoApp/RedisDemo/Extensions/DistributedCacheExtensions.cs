using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisDemo.Extensions
{
    //we have two method , one for get item and one for set item
    public static class DistributedCacheExtensions
    {

        //recordId must be unique , T data is generic so it can anything , 
        //there are two different timespans:-
        //A-absoluteExpireTime = null which is means that is not expired while redius is not reset
        //B-unusedExpireTime = null which is persist but its un accessable
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,string recordId,T data,
                                 TimeSpan? absoluteExpireTime = null,TimeSpan? unusedExpireTime = null) 
        {
            var options = new DistributedCacheEntryOptions();
            //it will set default value 60 second , 1 minute life time for the item after that it will deleted by Redis
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            //it will say that after the unusedExpireTime for this item go and get data again from database
            options.SlidingExpiration = unusedExpireTime;
            
            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId) 
        {
            var jsonData = await cache.GetStringAsync(recordId);
            //to return generic type 
            if (jsonData is null) 
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
