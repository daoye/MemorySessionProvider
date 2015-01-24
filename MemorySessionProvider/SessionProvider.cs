using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;

namespace MemorySessionProvider
{
    /// <summary>
    /// The customer SessionState store provider.
    /// </summary>
    public class SessionProvider : SessionStateStoreProviderBase
    {
        private TimeSpan _sessionTimeout;
        private SessionKeyHelper keyHelper = null;

        public override void Initialize(string name, NameValueCollection config)
        {
            // Get timeout value.
            var objConfig = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            _sessionTimeout = objConfig.Timeout;

            keyHelper = new SessionKeyHelper();
        }

        /// </summary>
        public override void InitializeRequest(HttpContext context)
        {

        }

        public override void EndRequest(HttpContext context)
        {
        }

        public override void Dispose()
        {

        }

        public override SessionStateStoreData GetItemExclusive(
            HttpContext context, string id,
            out bool locked, out TimeSpan lockAge, out object lockId,
            out SessionStateActions actions)
        {
            return GetSessionItem(context, id, out locked, out lockAge, out lockId, out actions);
        }

        public override SessionStateStoreData GetItem(HttpContext context, string id, out bool locked,
            out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            return GetSessionItem(context, id, out locked, out lockAge, out lockId, out actions);
        }

        private SessionStateStoreData GetSessionItem(
            HttpContext context,
            string id,
            out bool locked,
            out TimeSpan lockAge,
            out object lockId,
            out SessionStateActions actions)
        {
            locked = false;     // Do not use lock.
            lockAge = TimeSpan.Zero;
            lockId = DateTime.UtcNow.Ticks;
            actions = SessionStateActions.None;

            string sessionid = keyHelper.GetRrimaryKey(id);

            SessionData data = MemoryCache.Get(sessionid);
            if (data == null)
            {
                return null;
            }

            SessionStateStoreData sessionData = data.StateData;
            actions = data.Actions;

            return sessionData;
        }

        public override void SetAndReleaseItemExclusive(
            HttpContext context,
            string id,
            SessionStateStoreData item,
            object lockId,
            bool newItem)
        {
            string sessionid = keyHelper.GetRrimaryKey(id);

            DateTime expries = DateTime.Now.AddMinutes(item.Timeout);

            SessionData cacheItem = new SessionData(SessionStateActions.None, expries);
            cacheItem.StateData = item;

            MemoryCache.Set(sessionid, cacheItem, expries);
        }

        public override void ReleaseItemExclusive(HttpContext context, string id, object lockId)
        {
            //no lock to release
        }

        public override void RemoveItem(HttpContext context, string id, object lockId, SessionStateStoreData item)
        {
            string sessionid = keyHelper.GetRrimaryKey(id);

            MemoryCache.Remove(sessionid);
        }

        public override void CreateUninitializedItem(HttpContext context, string id, int timeout)
        {
            string sessionid = keyHelper.GetRrimaryKey(id);
            DateTime expries = DateTime.Now.AddMinutes(timeout);
            var cacheItem = new SessionData(SessionStateActions.InitializeItem, expries);

            MemoryCache.Set(sessionid, cacheItem, expries);
        }

        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            return new SessionStateStoreData(
                new SessionStateItemCollection(),
                SessionStateUtility.GetSessionStaticObjects(context),
                timeout);
        }

        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            return false;
        }

        public override void ResetItemTimeout(HttpContext context, string id)
        {
            string sessionid = keyHelper.GetRrimaryKey(id);

            var obj = MemoryCache.Get(sessionid);

            if (obj != null)
            {
                DateTime expries = DateTime.Now.Add(_sessionTimeout);
                obj.Expries = expries;

                MemoryCache.Set(sessionid, obj, expries);
            }
        }
    }
}