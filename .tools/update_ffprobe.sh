#!/bin/bash
curl https://raw.githubusercontent.com/FFmpeg/FFmpeg/master/doc/ffprobe.xsd --output ../FFConvert.FFProbe/ffprobe.xsd

# https://www.nuget.org/packages/Codaxy.Xsd2/0.10.0
./xsd2.exe --nullable -ns "FFConvert.FFProbe" -ct -cp ../FFConvert.FFProbe/ffprobe.xsd

