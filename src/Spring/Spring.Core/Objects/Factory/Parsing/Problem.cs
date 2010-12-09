﻿#if NET_2_0


using System;
using System.Collections.Generic;
using System.Text;
using Spring.Core.IO;
using Spring.Util;

namespace Spring.Objects.Factory.Parsing
{
    public class Problem
    {
        private string _message;

        private Location _location;

        private Exception _rootCause;


        /// <summary>
        /// Initializes a new instance of the <see cref="Problem"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="location">The location.</param>
        public Problem(string message, Location location)
            : this(message, location, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the Problem class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location"></param>
        /// <param name="rootCause"></param>
        public Problem(string message, Location location, Exception rootCause)
        {
            AssertUtils.ArgumentNotNull(message, "message");
            AssertUtils.ArgumentNotNull(location, "resource");

            _message = message;
            _location = location;
            _rootCause = rootCause;
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
        }

        public string ResourceDescription
        {
            get { return _location.Resource != null ? _location.Resource.Description : string.Empty; }
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("Configuration problem: ");
            sb.Append(Message);
            sb.Append("\nOffending resource: ").Append(ResourceDescription);

            return sb.ToString();

        }

    }
}

#endif