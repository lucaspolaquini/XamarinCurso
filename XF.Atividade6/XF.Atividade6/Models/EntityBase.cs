using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace XF.Atividade6.Models
{
    public class EntityBase
    {
        string id;
        DateTime createdAt;
        DateTime updatedAt;
        bool deleted;
        Version version;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

        [Version]
        public Version Version
        {
            get { return version; }
            set { version = value; }
        }
    }
}
