using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TaskOne.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbUserCredentials = new HashSet<TbUserCredential>();
        }

        public int IdUser { get; set; }
        public string? NameCompleteUser { get; set; }
        public string? LastNameUser { get; set; }
        public string CardUser { get; set; } = null!;
        public string? PhoneNumberUser { get; set; }
        public string? DirectionUser { get; set; }

        [JsonIgnore]
        public virtual ICollection<TbUserCredential> TbUserCredentials { get; set; }
    }
}
