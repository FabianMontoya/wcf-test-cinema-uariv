using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCinema.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Reservas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Reservas.svc o Reservas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Reservas : IReservas
    {
        BDCinemaEntities context = new BDCinemaEntities();
        public string CreateReserva(infoReserva data)
        {
            string result = "Exito";
            try
            {
                var resultHora = context.CreateReserva(data.Funcion, data.Fecha, data.Hora, data.Silla, data.Documento, data.Nombre, data.Telefono, data.ValorPaga);
                foreach (string insert in resultHora)
                {
                    if (!insert.Equals("Exito"))
                    {
                        result = insert;
                    }
                    break;
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

        }

        public resultReservasHora ConsultReservasFuncionHora(int funcion, string fecha, string hora)
        {
            resultReservasHora result = new resultReservasHora();
            try
            {
                var resultFunciones = context.ConsultReservasFuncionHora(funcion, fecha, hora);
                foreach (ConsultReservasFuncionHora_Result registro in resultFunciones)
                {
                    result.Reservas.Add(registro);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = ex.InnerException.Message;
            }

            return result;
        }

        public resultReservas ConsultReservasFuncion(int funcion)
        {
            resultReservas result = new resultReservas();
            try
            {
                var resultFunciones = context.ConsultHorariosReservasFuncion(funcion);
                foreach (ConsultHorariosReservasFuncion_Result registro in resultFunciones)
                {
                    result.Reservas.Add(registro);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = ex.InnerException.Message;
            }

            return result;
        }
    }
}
