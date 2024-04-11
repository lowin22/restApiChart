using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TaskOne.Models
{
    public partial class TbUserCredential
    {
        public int IdCredential { get; set; }
        public string? CardCredential { get; set; }
        public string? PasswordCredential { get; set; }

        [JsonIgnore]
        public virtual TbUser? CardCredentialNavigation { get; set; }
    }
}
