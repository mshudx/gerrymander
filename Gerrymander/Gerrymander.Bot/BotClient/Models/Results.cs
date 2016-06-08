﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Gerrymander.Bot.Models
{
    public partial class Results
    {
        private int? _votes;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Votes
        {
            get { return this._votes; }
            set { this._votes = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Results class.
        /// </summary>
        public Results()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken votesValue = inputObject["votes"];
                if (votesValue != null && votesValue.Type != JTokenType.Null)
                {
                    this.Votes = ((int)votesValue);
                }
            }
        }
    }
}
