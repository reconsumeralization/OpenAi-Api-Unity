using OpenAi.Json;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenAi.Api.V1
{
    /// <summary>
    /// <see cref="https://beta.openai.com/docs/api-reference/classifications/create#classifications/create-examples"/>
    /// </summary>
    public class LabeledExampleV1 : AModelV1
    {
        /// <summary>
        /// The example that you are performing a search on
        /// </summary>
        public string example;

        /// <summary>
        /// The label that is used when trying to classify a prompt against an example
        /// </summary>
        public string label;

        /// <inheritdoc/>
        public override void FromJson(JsonObject json)
        {
            foreach (JsonObject jo in json.NestedValues)
            {
                switch (jo.Name)
                {
                    case nameof(example):
                        example = jo.StringValue;
                        break;
                    case nameof(label):
                        label = jo.StringValue;
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public override string ToJson()
        {
            JsonBuilder jb = new JsonBuilder();

            jb.StartObject();
            jb.Add(nameof(example), example);
            jb.Add(nameof(label), label);
            jb.EndObject();

            return jb.ToString();
        }
    }
}