using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Top5Radio.Persistance.Data
{
    public class MusicData
    {
        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Artists { get; set; }

        public string Genre { get; set; }

        public float Danceability { get; set; }

        public float Energy { get; set; }

        public float Key { get; set; }

        public float Loudness { get; set; }

        public float Mode { get; set; }

        public float Speechiness { get; set; }

        public float Acousticness { get; set; }

        public float Instrumentalness { get; set; }

        public float Liveness { get; set; }

        public float Valence { get; set; }

        public float Tempo { get; set; }

        [JsonProperty("duration_ms")]
        public float Duration { get; set; }

        [JsonProperty("time_signature")]
        public float TimeSignature { get; set; }
    }
}
