﻿using System;
using System.IO;

namespace Uptime.Domain
{
    public class UptimeService : IUptimeService
    {
        public string FilePath { get; set; }

        public UptimeService() : this("c:/temp/uptime.txt") {}

        public UptimeService(string filePath)
        {
            this.FilePath = filePath;
        }
        
        public UptimeResult Get()
        {
            string rawValue = File.ReadAllText(this.FilePath).Split(" ")[0];
            decimal seconds = Decimal.Parse(rawValue);

            return new UptimeResult()
            {
                Seconds = seconds,
                Minutes = Math.Round(seconds / 60, 2),
                Hours = Math.Round(seconds / 60 / 60, 2),
                Days = Math.Round(seconds / 60 / 60 / 24, 2)
            };
        }
    }
}