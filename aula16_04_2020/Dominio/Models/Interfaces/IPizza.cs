using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Interfaces
{
    public interface IPizza
    {
       
                
        double CalcularTotal();

        public bool ValidoParaCadastro();
    }
}