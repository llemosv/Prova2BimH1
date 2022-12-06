namespace Calculadora.Models
{
    public class GastoCaloricoModel
    {
        public char Sexo { get; set; }    
        public double PesoEmKg { get; set; }
        public int IdadeEmAnos  { get; set; }   

        public double CalculoEntre18E30Anos (GastoCaloricoModel dados)
        { 
            if (dados.Sexo == 'F' || dados.Sexo == 'f')
            { 
                return (0.062 * dados.PesoEmKg + 2.036) * 239;
            } else
            {
                return (0.063 * dados.PesoEmKg + 2.896) * 239;
            }
        }

        public double CalculoEntre31E40Anos(GastoCaloricoModel dados)
        {
            if (dados.Sexo == 'F' || dados.Sexo == 'f')
            {
                return (0.034 * dados.PesoEmKg + 3.538) * 239;
            }
            else
            {
                return (0.048 * dados.PesoEmKg + 3.653) * 239;
            }
        }
    }
}