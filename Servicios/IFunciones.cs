using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCinema.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFunciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFunciones
    {
        [OperationContract]
        string CreateFuncion(string nombre, int precio);

        [OperationContract]
        ResultFunciones ConsultFunciones();

        [OperationContract]
        string CreateHoraFuncion(InfoFuncionHora data);

        [OperationContract]
        ResultFechas ConsultFechasFuncion(int funcion);

        [OperationContract]
        ResultHoras ConsultHorasFuncion(int funcion, string fecha);

        [OperationContract]
        ResultSillas ConsultSillasFuncion(int funcion, string fecha, string hora);
    }

    [DataContract]
    public class ResultFunciones
    {
        List<ConsultFunciones_Result> funciones = new List<ConsultFunciones_Result>();
        bool error = false;
        string mensaje = "";

        [DataMember]
        public List<ConsultFunciones_Result> Funciones
        {
            get { return funciones; }
            set { funciones = value; }
        }

        [DataMember]
        public bool Error
        {
            get { return error; }
            set { error = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
    }

    [DataContract]
    public class InfoFuncionHora
    {
        [DataMember(IsRequired = true)]
        public int Funcion { get; set; }

        [DataMember(IsRequired = true)]
        public string Fecha { get; set; }

        [DataMember(IsRequired = true)]
        public string Hora { get; set; }

        [DataMember(IsRequired = true)]
        public bool Descuento { get; set; }

        [DataMember(IsRequired = true)]
        public int PorcentajeDescuento { get; set; }

        [DataMember(IsRequired = true)]
        public int NumeroSillas { get; set; }
    }

    [DataContract]
    public class ResultFechas
    {
        List<string> _fechas = new List<string>();
        bool _error = false;
        string _mensaje = "";

        [DataMember]
        public List<string> Fechas
        {
            get { return _fechas; }
            set { _fechas = value; }
        }

        [DataMember]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }

    [DataContract]
    public class ResultHoras
    {
        List<ConsultHorasFuncion_Result> _horas = new List<ConsultHorasFuncion_Result>();
        bool _error = false;
        string _mensaje = "";

        [DataMember]
        public List<ConsultHorasFuncion_Result> Horas
        {
            get { return _horas; }
            set { _horas = value; }
        }

        [DataMember]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }

    [DataContract]
    public class ResultSillas
    {
        List<ConsultSillasFuncion_Result> _sillas = new List<ConsultSillasFuncion_Result>();
        bool _error = false;
        string _mensaje = "";

        [DataMember]
        public List<ConsultSillasFuncion_Result> Sillas
        {
            get { return _sillas; }
            set { _sillas = value; }
        }

        [DataMember]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }
}
