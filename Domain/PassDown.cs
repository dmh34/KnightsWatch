using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace KnightsWatch.Entites
{
    [DataContract]
    public class PassDown
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [Column(TypeName = "datetime2")]
        [DataMember]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime2")]
        [DataMember]
        public DateTime? EndTime { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public bool IsImportant { get; set; }
        [Column(TypeName = "datetime2")]
        [DataMember]
        public DateTime ExpireDate { get; set; }
    }
}
