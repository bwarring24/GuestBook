using System;
using System.Runtime.Serialization;

namespace WcfService.Contracts
{
    [DataContract]
    public class VersionContract
    {
        [DataMember]
        public int Build;

        [DataMember]
        public int Major;

        [DataMember]
        public int MajorRevision;

        [DataMember]
        public int Minor;

        [DataMember]
        public int MinorRevision;

        [DataMember]
        public int Revision;
    }
}