using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumnoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]
        ML.Result Add(ML.Alumno alumno);

        [OperationContract]
        ML.Result Update(ML.Alumno alumno);

        [OperationContract]
        ML.Result Delete(int idAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetById(int idAlumno);
    }
}
