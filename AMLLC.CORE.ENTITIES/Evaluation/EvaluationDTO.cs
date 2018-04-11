using System.Runtime.Serialization;
namespace AMLLC.CORE.ENTITIES.Evaluation
{
    [DataContract]
    public class EvaluationDTO
    {
        [DataMember]
        public int idUser { get; set; }

    }
}
