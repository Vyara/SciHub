using System;

namespace SciHub.Services.Web.Contracts
{
    public interface ICacheService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string itemName);
    }
}
