﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace apiweb.healthclinc.manha.Utils
{
    public class TimeSpanConvert : JsonConverter<TimeSpan>
    {
            public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                string? value = reader.GetString();
                return TimeSpan.Parse(value!);
            }

            public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
    }
}
