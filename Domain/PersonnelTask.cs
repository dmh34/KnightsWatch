using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace KnightsWatch.Entites
{
    [DataContract]
    public class PersonnelTask
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [Column(TypeName ="datetime2")]
        [DataMember]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime2")]
        [DataMember]
        public DateTime? EndTime { get; set; }
        [DataMember]
        public string Owner { get; set; }
        [DataMember]
        public int TaskNotesID { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int TaskNameID { get; set; }

        [DataMember]
        public virtual TaskName Name { get; set; }
        [DataMember]
        public TimeSpan? TotalTime { get; set; }
    }
}
