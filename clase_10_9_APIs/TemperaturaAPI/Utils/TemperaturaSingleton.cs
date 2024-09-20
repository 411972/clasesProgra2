using TemperaturaAPI.Models;

namespace TemperaturaAPI.Utils
{
    public class TemperaturaSingleton
    {
        private static TemperaturaSingleton _instance;

        private static List<Temperatura> temperaturas;

        private TemperaturaSingleton()
        {
            temperaturas = new List<Temperatura>();
            Temperatura oT1 = new Temperatura();
            Temperatura oT2 = new Temperatura();
            Temperatura oT3 = new Temperatura();

            oT1.Identificador = 1;
            oT1.FechaHora = DateTime.Now;
            oT1.Valor = 25;
            temperaturas.Add(oT1);

            oT2.Identificador = 2;
            oT2.FechaHora = DateTime.Now;
            oT2.Valor = 32;
            temperaturas.Add(oT2);

            oT3.Identificador = 3;
            oT3.FechaHora = DateTime.Now;
            oT3.Valor = 17;

            temperaturas.Add(oT3);


        }

        public static TemperaturaSingleton getInstance()
        {
            if (_instance == null)
            {
                _instance = new TemperaturaSingleton();      
            }
            return _instance;
        }

        public bool AgregarTemperatura(Temperatura temp)
        {
            temperaturas.Add(temp);
            return true;
        }

        public List<Temperatura> ObtenerTemperaturas()
        {
            return temperaturas;
        }

        public Temperatura ObtenerTemperaturaPorValor(float valor)
        {
            var temp = temperaturas.Find(tem => tem.Valor == valor);
            return temp;
        }

    }
}
