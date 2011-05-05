using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;

namespace WowDotNetAPI.Explorers
{
    public interface IRealmExplorer<T> : IExplorer
    {
        string Region { get; set; }

        T GetSingleRealm(string name);
        string GetSingleRealmAsJson(string name);

        IEnumerable<T> GetAllRealms();
        string GetAllRealmsAsJson();

        IEnumerable<T> GetRealmsByType(string type);
        string GetRealmsByTypeAsJson(string type);

        IEnumerable<T> GetRealmsByPopulation(string population);
        string GetRealmsByPopulationAsJson(string population);

        IEnumerable<T> GetRealmsByStatus(bool status);
        string GetRealmsByStatusAsJson(bool status);

        IEnumerable<T> GetRealmsByQueue(bool queue);
        string GetRealmsByQueueAsJson(bool queue);

        IEnumerable<T> GetMultipleRealms(params string[] names);
        string GetMultipleRealmsAsJson(params string[] names);

        IEnumerable<T> GetMultipleRealmsViaQuery(string query);
        string GetRealmsViaQueryAsJson(string query);
    }
}
