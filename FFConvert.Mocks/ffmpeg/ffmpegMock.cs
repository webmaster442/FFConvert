﻿const int delay = 100;
Console.WriteLine(@"bitrate=588.8kbits/s
total_size=2001
out_time_us=50000000 
out_time_ms=50000000
out_time=00:00:50
dup_frames=0
drop_frames=0
speed=100x
progress=continue");
Thread.Sleep(delay);
Console.WriteLine(@"bitrate=588.8kbits/s
total_size=2001
out_time_us=100000000  
out_time_ms=100000000
out_time=00:01:40
dup_frames=0
drop_frames=0
speed=100x
progress=continue");
Thread.Sleep(delay);
Console.WriteLine(@"bitrate=588.8kbits/s
total_size=2001
out_time_us=150000000  
out_time_ms=150000000
out_time=00:02:30
dup_frames=0
drop_frames=0
speed=63.5x
progress=continue");
Thread.Sleep(delay);
Console.WriteLine(@"bitrate=588.8kbits/s
total_size=2001
out_time_us=200000000  
out_time_ms=200000000
out_time=00:03:20
dup_frames=0
drop_frames=0
speed=100x
progress=continue");