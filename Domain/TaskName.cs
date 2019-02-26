using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace KnightsWatch.Entites
{
    [DataContract]
    public class TaskName 
    {
        [Key]
        [DataMember]
        int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
