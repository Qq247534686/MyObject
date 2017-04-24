using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class MyRedis
    {
        //"localhost", 6379
        private static RedisClient client;
        public static string Host { get; set; }
        public static int Port { get; set; }
        public MyRedis()
        {

        }
        public MyRedis(string host, int port)
        {
            Host = host;
            Port = port;
            if (client == null)
            {
                client = new RedisClient(Host, Port);
                client.FlushAll();
            }
        }
        public  RedisClient GetRedisClient()
        {
            return client;
        }
        #region Set Add 添加
        public  void RedisMethodTo_Set<T>(string key, T value)
        {
            client.Set<T>(key, value);
        }
        public  void RedisMethodTo_Set<T>(string key, T value, DateTime expires)
        {
            client.Set<T>(key, value, expires);
        }
        public  void RedisMethodTo_Add<T>(string key, T value)
        {
            client.Add<T>(key, value);
        }
        public  void RedisMethodTo_Add<T>(string key, T value, DateTime expires)
        {
            client.Add<T>(key, value, expires);
        }
        #endregion

        #region Set Add 查找
        public  T RedisMethodTo_Get<T>(string key)
        {
            return client.Get<T>(key);
        }
        #endregion


        #region Hash 增加 查找
        public  void RedisMethodTo_Hash(string GropsName,string key,string value)
        {
            client.SetEntryInHash(GropsName, key, value);
        }
        public  List<string> RedisMethodTo_HashKeys(string GropsName)
        {
           return client.GetHashKeys(GropsName);
        }
        public  List<string> RedisMethodTo_HashValus(string GropsName)
        {
            return client.GetHashValues(GropsName);
        }
        #endregion

        #region List 增加 查找
        public  void RedisMethodTo_List(string key, string value)
        {
            client.EnqueueItemOnList(key, value);
        }
        
        /// <summary>
        /// 出队(队列先进先出)
        /// </summary>
        /// <param name="GropsName"></param>
        /// <returns></returns>
        public  List<string> RedisMethodToDeq_ListValues(string GropsName)
        {
            List<string> listArray = new List<string>();
            int count= client.GetListCount(GropsName);
            for (int i = 0; i < count; i++)
            {
                listArray.Add(client.DequeueItemFromList(GropsName));   //出队(队列先进先出)
            }
            return listArray;
        }
        /// <summary>
        /// 出栈(栈先进后出)
        /// </summary>
        /// <param name="GropsName"></param>
        /// <returns></returns>
        public  List<string> RedisMethodToPop_HashValus(string GropsName)
        {
            List<string> listArray = new List<string>();
            int count = client.GetListCount(GropsName);
            for (int i = 0; i < count; i++)
            {
                listArray.Add(client.PopItemFromList(GropsName));   //出队(队列先进先出)
            }
            return listArray;
        }
        #endregion

        #region 删除
        public  void RedisMethodToDelete(string name)
        {
            client.Del(name);
        }
        #endregion
    }
   
}
