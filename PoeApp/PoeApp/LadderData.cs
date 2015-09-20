using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PoeApp
{

    public class LadderData
    {

        public struct Character
        {
            public string name { get; set; }
            public int level { get; set; }
            [JsonProperty("class")]
            public string Class { get; set; }
            public long experience { get; set; }
        }

        public struct Challenges
        {
            public int total { get; set; }
        }

        public struct Account
        {
            public string name { get; set; }
            public Challenges challenges { get; set; }
        }

        public struct Entry
        {
            public bool online { get; set; }
            public int rank { get; set; }
            public bool dead { get; set; }
            public Character character { get; set; }
            public Account account { get; set; }
        }


        public int total { get; set; }
        public List<Entry> entries { get; set; }

    }
}