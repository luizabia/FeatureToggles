using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureTogglesExemples
{
    public class FeactureTogglesConfig
    {
        private readonly IFeatureTogglesData _data;
        private readonly Dictionary<string, string> _values;
        private readonly bool _useCache;

        public FeactureTogglesConfig(IFeatureTogglesData data, bool useCache)
        {
            _data = data;
            _values = new Dictionary<string, string>();
            _useCache = useCache;
        }

        public bool IsEnabled(EnumFeactureToggles feactureToggles, bool useCache)
        {
            var valor = string.Empty;

            if (useCache)
            {
                valor = GetValue(GetEnumName(feactureToggles));
            }
            else
            {
                valor = _data.ConsultaValor(GetEnumName(feactureToggles));
            }

            if (string.IsNullOrEmpty(valor))
            {
                valor = false.ToString();
                _data.Insere(GetEnumName(feactureToggles), valor);
            }

            if (!bool.TryParse(valor, out var valorToReturn))
            {
                valor = false.ToString();
                _data.Altera(GetEnumName(feactureToggles), valor);
            }

            return valorToReturn;
        }

        public bool IsEnabled(EnumFeactureToggles feactureToggles)
        {
            return IsEnabled(feactureToggles, _useCache);
        }

        private string GetEnumName(EnumFeactureToggles feactureToggles)
        {
            return Enum.GetName(typeof(EnumFeactureToggles), feactureToggles);
        }

        private string GetValue(string name)
        {
            var valor = string.Empty;
            if (_values.ContainsKey(name))
            {
                valor = _values[name];
            }
            else
            {
                valor = _data.ConsultaValor(name);

                if (!string.IsNullOrEmpty(valor))
                {
                    _values.Add(name, valor);

                }

            }

            return valor;

        }

        public void ClearCache()
        {
            _values.Clear();
        }
    }
}
