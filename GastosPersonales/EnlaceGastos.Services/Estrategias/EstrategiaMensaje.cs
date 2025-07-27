using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EnlaceGastos.Services.Interfaces;

namespace EnlaceGastos.Services.Estrategias
{
    public class EstrategiaMensaje : IAnalisisFinancieroStrategy
    {
        private readonly Dictionary<string, List<string>> _mensajes;
        private readonly Random _random;

        public EstrategiaMensaje()
        {
            _mensajes = CargarMensajesDesdeXml("Recursos/Mensajes.xml");
            _random = new Random();
        }

        public string Evaluar(decimal ingresos, decimal egresos)
        {
            if (ingresos == 0 && egresos == 0)
                return ObtenerMensaje("nulo");

            if (ingresos == 0)
                return ObtenerMensaje("soloEgresos");

            if (egresos == 0)
                return ObtenerMensaje("soloIngresos");

            if (ingresos == egresos)
                return ObtenerMensaje("empate");

            if (egresos > ingresos)
            {
                var porcentaje = (egresos - ingresos) / ingresos * 100;
                return string.Format(ObtenerMensaje("exceso"), porcentaje);
            }

            var ahorro = ingresos - egresos;
            var porcentajeAhorro = (ahorro / ingresos) * 100;
            return string.Format(ObtenerMensaje("ahorro"), porcentajeAhorro);
        }

        private string ObtenerMensaje(string tipo)
        {
            if (!_mensajes.ContainsKey(tipo) || _mensajes[tipo].Count == 0)
                return "Sin mensaje definido.";

            var lista = _mensajes[tipo];
            return lista[_random.Next(lista.Count)];
        }

        private Dictionary<string, List<string>> CargarMensajesDesdeXml(string rutaRelativa)
        {
            var rutaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

            if (!File.Exists(rutaAbsoluta))
                throw new FileNotFoundException($"No se encontró el archivo XML: {rutaAbsoluta}");

            var xdoc = XDocument.Load(rutaAbsoluta);

            var diccionario = new Dictionary<string, List<string>>();

            foreach (var nodo in xdoc.Root!.Elements("Mensaje"))
            {
                var tipo = nodo.Attribute("tipo")!.Value;
                var texto = nodo.Value;

                if (!diccionario.ContainsKey(tipo))
                    diccionario[tipo] = new List<string>();

                diccionario[tipo].Add(texto);
            }

            return diccionario;
        }
    }
}
