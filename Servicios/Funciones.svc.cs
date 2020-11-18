using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCinema.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Funciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Funciones.svc o Funciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Funciones : IFunciones
    {

        BDCinemaEntities context = new BDCinemaEntities();
        public string CreateFuncion(string nombre, int precio)
        {
            string result = "Exito";
            try
            {
                var resultHora = context.CreateFuncion(nombre, precio);
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

        public string CreateHoraFuncion(InfoFuncionHora data)
        {
            string result = "Exito";
            try
            {
                var resultHora = context.CreateFuncionHora(data.Funcion, data.Fecha, data.Hora, (data.Descuento ? 1 : 0), data.PorcentajeDescuento);

                foreach (string insertHora in resultHora)
                {
                    if (!insertHora.Equals("Exito"))
                    {
                        result = insertHora;
                    }
                    break;
                }

                if (result.Equals("Exito"))
                {
                    data.NumeroSillas = data.NumeroSillas > 100 ? 100 : data.NumeroSillas;
                    for (int i = 1; i <= data.NumeroSillas; i++)
                    {
                        context.CreateSillaFuncion(data.Funcion, data.Fecha, data.Hora, i);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

        }

        public ResultFunciones ConsultFunciones()
        {
            ResultFunciones result = new ResultFunciones();
            try
            {
                var resultFunciones = context.ConsultFunciones();
                foreach (ConsultFunciones_Result registro in resultFunciones)
                {
                    result.Funciones.Add(registro);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = ex.InnerException.Message;
            }
            return result;
        }

        public ResultFechas ConsultFechasFuncion(int funcion)
        {
            ResultFechas result = new ResultFechas();
            try
            {
                var resultFunciones = context.ConsultFechasFuncion(funcion);
                foreach (string registro in resultFunciones)
                {
                    result.Fechas.Add(registro);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = ex.InnerException.Message;
            }
            return result;
        }

        public ResultHoras ConsultHorasFuncion(int funcion, string fecha)
        {
            ResultHoras result = new ResultHoras();
            try
            {
                var resultFunciones = context.ConsultHorasFuncion(funcion,fecha);
                foreach (ConsultHorasFuncion_Result registro in resultFunciones)
                {
                    result.Horas.Add(registro);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Mensaje = ex.InnerException.Message;
            }
            return result;
        }

        public ResultSillas ConsultSillasFuncion(int funcion, string fecha, string hora)
        {
            ResultSillas result = new ResultSillas();
            try
            {
                var resultFunciones = context.ConsultSillasFuncion(funcion, fecha, hora);
                foreach (ConsultSillasFuncion_Result registro in resultFunciones)
                {
                    result.Sillas.Add(registro);
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
