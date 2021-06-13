using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ResultsRecorder
{
    class Model
    {

        public Model()
        {
            Module[] Modules = new Module[17];
            LoadFile(ref Modules);
            SaveFile(Modules);
        }

        public void LoadFile(ref Module[] Modules)
        {
            var fileName = @"d:/temp/Modules.json";
            byte[] data = File.ReadAllBytes(fileName);
            Utf8JsonReader reader = new Utf8JsonReader(data);

            var Position = 0;
            var Str = "";

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        Modules[Position] = new Module();
                        break;
                    case JsonTokenType.EndObject:
                        Position++;
                        break;
                    case JsonTokenType.StartArray:
                    case JsonTokenType.EndArray:
                        break;
                    case JsonTokenType.PropertyName:
                        Str = reader.GetString();

                        break;
                    case JsonTokenType.String:
                        if (Str.Equals("Name"))
                        {
                            Modules[Position].Name = reader.GetString();
                        }
                        else if (Str.Equals("Code"))
                        {
                            Modules[Position].Code = reader.GetString();
                        }
                        else if (Str.Equals("Assessment1"))
                        {
                            Modules[Position].Assessment1 = reader.GetString();
                        }
                        else
                        {
                            Modules[Position].Assessment2 = reader.GetString();
                        }
                        break;
                    case JsonTokenType.False:
                        Modules[Position].SingleAssessment = false;
                        break;
                    case JsonTokenType.True:
                        Modules[Position].SingleAssessment = true;
                        break;
                    default:
                        throw new ArgumentException();

                }
            }
        }

        public static void SaveFile(Module[] Modules)
        {
            string JsonData = " [ ";

            foreach (var Module in Modules)
            {
                string SerialisedJson = JsonSerializer.Serialize(Module);
                JsonData = JsonData + SerialisedJson;
                if (Module.Code != "CSY4010")
                {
                    JsonData = JsonData + ", ";
                }
            }
            JsonData = JsonData + " ] ";

            JsonDocument jdoc = JsonDocument.Parse(JsonData);

            var fileName = @"d:\temp\Modules.json";
            FileStream fileStream = File.OpenWrite(fileName);
            FileStream fs = fileStream;

            var writer = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true });
            jdoc.WriteTo(writer);
        }

    }
}
