namespace Calculadora.Models
{
    public class GastoAtividadeModel
    {
        public int MinutosAtividade { get; set; }
        public string AtividadeRealizada { get; set; }

        public double Calculo(GastoAtividadeModel dados)
        {
            switch (dados.AtividadeRealizada)
            {
                case "Caminhada (piso plano)":
                    return Convert.ToDouble(6.1 * dados.MinutosAtividade);
                case "Trabalho doméstico":
                    return Convert.ToDouble(4.6 * dados.MinutosAtividade);
                case "Corrida (5 min/Km)":
                    return Convert.ToDouble(16 * dados.MinutosAtividade);
                case "Bicicleta (9 km/h)":
                    return Convert.ToDouble(4.9 * dados.MinutosAtividade);
                case "Bicicleta (15 Km/h)":
                    return Convert.ToDouble(7.7 * dados.MinutosAtividade);
                case "Alongamento":
                    return Convert.ToDouble(5.4 * dados.MinutosAtividade);
            }

            return 0.0;
        }
    }
}