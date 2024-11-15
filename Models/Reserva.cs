namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes recebido
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            { 
                Hospedes = hospedes;
            }
            else
            {
                // Lançar uma exceção caso a capacidade seja menor que o número de hóspedes
                throw new Exception("Capacidade da suíte insuficiente para o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor da diária com base nos dias reservados e o valor da diária da suíte
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Concede um desconto de 10% caso os dias reservados sejam 10 ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.90m;
            }

            return valor;
        }
    }
}
