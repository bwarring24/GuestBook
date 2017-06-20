using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Runtime.Serialization;
using WcfService.Contracts;

namespace WcfService.Repositories
{
    public class SoftwareRepository
    {
        private static string guestBookSoftwarePath = @"C:\inetpub\wwwroot\WcfService\Downloads\GuestBook\";


        public SoftwareRepository()
        {

        }


        public VersionContract GetLatestVersion()
        {
            string[] latestVersion = File.ReadAllText(guestBookSoftwarePath + "latest.txt").Split('.');

            Version version = new Version(Int32.Parse(latestVersion[0]), Int32.Parse(latestVersion[1]), Int32.Parse(latestVersion[2]), Int32.Parse(latestVersion[3]));

            return new VersionContract
            {
                Major = Int32.Parse(latestVersion[0]),
                Minor = Int32.Parse(latestVersion[1]),
                Revision = Int32.Parse(latestVersion[2])
            };
        }
    }
}