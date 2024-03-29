﻿// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace FFConvert.Domain;

internal sealed class FFProbeTags
{
    [JsonPropertyName("encoder")]
    public string Encoder { get; set; }

    [JsonPropertyName("creation_time")]
    public DateTime CreationTime { get; set; }

    public FFProbeTags()
    {
        Encoder = string.Empty;
    }
}
