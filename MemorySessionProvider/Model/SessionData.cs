using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace MemorySessionProvider
{
    /// <summary>
    /// The session data entity.
    /// </summary>
    public class SessionData
    {
        public SessionData(SessionStateActions actions, DateTime expries)
        {
            this.Actions = actions;
            this.Expries = expries;
        }

        /// <summary>
        /// The relealy session data.
        /// </summary>
        public SessionStateStoreData StateData { get; set; }

        /// <summary>
        /// The data expiry time.
        /// </summary>
        public DateTime Expries { get; set; }

        /// <summary>
        /// The state actions.
        /// </summary>
        public SessionStateActions Actions { get; set; }
    }
}