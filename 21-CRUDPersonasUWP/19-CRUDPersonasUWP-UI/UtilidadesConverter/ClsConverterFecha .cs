using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _19_CRUDPersonasUWP_UI.UtilidadesConverter
{
    public class ClsConverterFecha : IValueConverter
    {
        //public object Convert(object value, Type targetType, object parameter, string language)
        //{
        //    String fecha = null;

        //    fecha = value.ToString();
        //    fecha = fecha.Substring(0, 10);
        //    return fecha;

        //}

        //public object ConvertBack(object value, Type targetType, object parameter, string language)
        //{
        //    DateTime fecha = new DateTime();

        //    fecha = System.Convert.ToDateTime(value);

        //    return fecha;

        //}

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = (DateTime)value;
            return fecha.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = new DateTime();
            try
            {
                fecha = System.Convert.ToDateTime(value);
            }
            catch (Exception e)
            {
                throw e;
            }
            

            return fecha;

        }
    }
}
