namespace FeatureTogglesExemples
{
    public interface IFeatureTogglesData
    {
        string ConsultaValor(string name);

        void Insere(string name, string value);

        void Altera(string name, string value);
    }
}
