namespace Web_Api_Inm.Helpers
{
    public class FechaHelper
    {
        private DateTime fechaActual;

        public FechaHelper()
        {
            fechaActual = DateTime.Now;
        }

        public int ObtenerNumeroDia()
        {
            return fechaActual.Day;
        }

        public int ObtenerNumeroAnio()
        {
            return fechaActual.Year;
        }

        public string ObtenerMesTexto()
        {
            int mes = fechaActual.Month;
            string mesTexto = mes switch
            {
                1 => "ENERO",
                2 => "FEBRERO",
                3 => "MARZO",
                4 => "ABRIL",
                5 => "MAYO",
                6 => "JUNIO",
                7 => "JULIO",
                8 => "AGOSTO",
                9 => "SETIEMBRE",
                10 => "OCTUBRE",
                11 => "NOVIEMBRE",
                12 => "DICIEMBRE",
                _ => "MES INVÁLIDO"
            };
            return mesTexto;
        }
    }
}
