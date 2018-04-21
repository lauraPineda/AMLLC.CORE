using System.ServiceModel;

namespace AMLLC.CORE.WEBSERVICE
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReferenceService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReferenceService
    {
        [OperationContract]
        void OK();
    }
}
