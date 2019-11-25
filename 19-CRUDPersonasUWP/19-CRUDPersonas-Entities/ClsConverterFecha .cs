using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_CRUDPersonas_Entities
{
    public class ClsConverterFecha
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String fecha2 = null;

            fecha2 = value.ToString();
            fecha2 = fecha2.Substring(0, 10);
            return fecha2;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha2 = new DateTime();

            fecha2 = System.Convert.ToDateTime(value);

            return fecha2;

        }
    }
}
