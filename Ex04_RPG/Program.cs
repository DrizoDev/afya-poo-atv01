using System;

namespace Ex04_RPG
{
    public class PersonagemRPG
    {
        private readonly string _nome;
        private readonly string _classe;
        private int _nivel;
        private double _vidaAtual;
        private double _vidaMaxima;

        public string Nome => _nome;
        public string Classe => _classe;
        public int Nivel => _nivel;
        public double VidaAtual => _vidaAtual;
        public double VidaMaxima => _vidaMaxima;
        public bool EstaMorto => _vidaAtual <= 0;

        public PersonagemRPG(string nome, string classe)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(classe))
                throw new ArgumentException("A classe é obrigatória.");

            classe = classe.Trim();

            if (classe != "Guerreiro" && classe != "Mago")
                throw new ArgumentException("A classe deve ser Guerreiro ou Mago.");

            _nome = nome;
            _classe = classe;
            _nivel = 1;

            _vidaMaxima = _classe == "Guerreiro" ? 150 : 80;
            _vidaAtual = _vidaMaxima;
        }

        public void ReceberDano(int pontos)
        {
            if (pontos <= 0 || EstaMorto)
                return;

            _vidaAtual -= pontos;

            if (_vidaAtual < 0)
                _vidaAtual = 0;
        }

        public void Curar(int pontos)
        {
            if (pontos <= 0 || EstaMorto)
                return;

            _vidaAtual += pontos;

            if (_vidaAtual > _vidaMaxima)
                _vidaAtual = _vidaMaxima;
        }

        public void SubirNivel()
        {
            if (EstaMorto)
                return;

            if (_nivel >= 99)
                return;

            _nivel++;
            _vidaMaxima += _vidaMaxima * 0.10;
            _vidaAtual = _vidaMaxima;
        }

        public void Ressuscitar()
        {
            if (!EstaMorto)
                return;

            _vidaAtual = _vidaMaxima;
        }

        public override string ToString()
        {
            return $"{_nome} ({_classe}) - Lvl {_nivel} - HP: {_vidaAtual:0}/{_vidaMaxima:0}";
        }
    }

    class Program
    {
        static void Main()
        {
            PersonagemRPG personagem = new PersonagemRPG("Arkan", "Guerreiro");

            Console.WriteLine(personagem);

            personagem.ReceberDano(50);
            Console.WriteLine(personagem);

            personagem.Curar(20);
            Console.WriteLine(personagem);

            personagem.SubirNivel();
            Console.WriteLine(personagem);

            personagem.ReceberDano(300);
            Console.WriteLine(personagem);

            personagem.Curar(50);
            Console.WriteLine(personagem);

            personagem.Ressuscitar();
            Console.WriteLine(personagem);
        }
    }
}
