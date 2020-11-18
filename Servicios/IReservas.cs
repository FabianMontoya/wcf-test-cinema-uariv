using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCinema.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReservas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReservas
    {
        [OperationContract]
        string CreateReserva(infoReserva data);
        [OperationContract]
        resultReservasHora ConsultReservasFuncionHora(int funcion, string fecha, string hora);

        [OperationContract]
        resultReservas ConsultReservasFuncion(int funcion);
    }
    [DataContract]
    public class infoReserva
    {

        [DataMember(IsRequired = true)]
        public int Funcion { get; set; }

        [DataMember(IsRequired = true)]
        public string Fecha { get; set; }

        [DataMember(IsRequired = true)]
        public string Hora { get; set; }

        [DataMember(IsRequired = true)]
        public int Silla { get; set; }

        [DataMember(IsRequired = true)]
        public string Documento { get; set; }

        [DataMember(IsRequired = true)]
        public string Nombre { get; set; }

        [DataMember(IsRequired = true)]
        public string Telefono { get; set; }

        [DataMember(IsRequired = true)]
        public int ValorPaga { get; set; }
    }

    [DataContract]
    public class resultReservasHora
    {
        string _mensaje = "";
        bool _error = false;
        List<ConsultReservasFuncionHora_Result> _reservas = new List<ConsultReservasFuncionHora_Result>();

        [DataMember]
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        [DataMember]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }

        [DataMember]
        public List<ConsultReservasFuncionHora_Result> Reservas
        {
            get { return _reservas; }
            set { _reservas = value; }
        }
    }

    [DataContract]
    public class resultReservas
    {
        string _mensaje = "";
        bool _error = false;
        List<ConsultHorariosReservasFuncion_Result> _reservas = new List<ConsultHorariosReservasFuncion_Result>();

        [DataMember]
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        [DataMember]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }

        [DataMember]
        public List<ConsultHorariosReservasFuncion_Result> Reservas
        {
            get { return _reservas; }
            set { _reservas = value; }
        }
    }
}
