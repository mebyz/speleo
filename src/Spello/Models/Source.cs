using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spello.Models.Source
{

    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public class AccessKeyIdConfig
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public string[] android { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public string[] ios { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public string[] winphone { get; set; }
    }



    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public class Version
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public VersionItem[] versions { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public class VersionItem
        {
            /// <summary>
            /// todo
            /// </summary>
            /// <remarks>todo</remarks>     
            public string versionName { get; set; }
            /// <summary>
            /// todo
            /// </summary>
            /// <remarks>todo</remarks>     
            public string minSystemVersion { get; set; }
            /// <summary>
            /// todo
            /// </summary>
            /// <remarks>todo</remarks>     
            public bool mandatory { get; set; }
        }
    }



  

}
