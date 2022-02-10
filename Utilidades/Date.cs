using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegramsaUltimate.Utilidades
{
    /// <summary>
    /// clase con funciones de fecha
    /// </summary>
    public class Date
    {
        public static int obtieneNumeroSemanaAno(DateTime fecha)
        {
            int numeroSemana = 0;
            try
            {
                var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                numeroSemana = cal.GetWeekOfYear(new DateTime(fecha.Year, fecha.Month, fecha.Day), System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday);

            }
            catch { }
            return numeroSemana;
        }

        public static string obtieneDiaxNumero(int dia)
        {
            string diaSemana = "";
            switch (dia)
            {
                case 1:
                    diaSemana = "lunes";
                    break;
                case 2:
                    diaSemana = "martes";
                    break;
                case 3:
                    diaSemana = "miercoles";
                    break;
                case 4:
                    diaSemana = "jueves";
                    break;
                case 5:
                    diaSemana = "viernes";
                    break;
                case 6:
                    diaSemana = "sabado";
                    break;
                case 7:
                    diaSemana = "domingo";
                    break;

                default:
                    break;
            }
                    return diaSemana;
        }

        public static string formatoHora(int horas)
        {
            try
            {
                string cadena = "";

                int h = horas / 60;
                int min = horas % 60;

                if (h > 0)
                    cadena += h.ToString();
                else cadena = "00";

                cadena += min.ToString();



                return cadena;
            }
            catch
            {
                return "00:00";
            }
        }
    }
}