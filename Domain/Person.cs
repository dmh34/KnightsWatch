using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace KnightsWatch.Entites
{
    [DataContract]
    public class Person
    {
        [Key]
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual IList<PersonnelTask> Tasks { get; set; }
        [DataMember]
        public int TaskID { get; set; }
    }
}
