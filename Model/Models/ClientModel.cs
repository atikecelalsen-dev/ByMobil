using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Model.Models
    {
        public class ClientModel
        {
            [JsonPropertyName("logicalRef")]
            public int LOGICALREF { get; set; }

            [JsonPropertyName("code")]
            public string? CODE { get; set; }

            [JsonPropertyName("definition")]
            public string? DEFINITION_ { get; set; }

            public int ACTIVE { get; set; }
            public int CARDTYPE { get; set; }
        }
    


}
