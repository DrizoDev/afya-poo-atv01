using System;

namespace Ex01_Lampada
{
    public class LampadaInteligente
    {
        private string _marca;
        private readonly string _tecnologia;
        private bool _ligada;
        private int _brilho;

        public string Marca
        {
            get => _marca;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _marca = value;
            }
        }

        public string Tecnologia => _tecnologia;
        public bool EstaLigada => _ligada;
        public int Brilho => _brilho;

        public LampadaInteligente(string marca, string tecnologia)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("A marca é obrigatória.");

            if (string.IsNullOrWhiteSpace(tecnologia))
                throw new ArgumentException("A tecnologia é obrigatória.");

            _marca = marca;
            _tecnologia = tecnologia;
            _ligada = false;
            _brilho = 100;
        }

        public void Alternar()
        {
            _ligada = !_ligada;
        }

        public bool AjustarBrilho(int novoBrilho)
        {
            if (!_ligada)
                return false;

            if (novoBrilho < 0 || novoBrilho > 100)
                return false;

            _brilho = novoBrilho;
            return true;
        }

        public override string ToString()
        {
            return $"Marca: {_marca} | Tecnologia: {_tecnologia} | Estado: {(_ligada ? "Ligada" : "Desligada")} | Brilho: {_brilho}%";
        }
    }

    class Program
    {
        static void Main()
        {
            LampadaInteligente lampada = new LampadaInteligente("Philips", "LED");

            Console.WriteLine(lampada);

            lampada.Alternar();
            lampada.AjustarBrilho(70);

            Console.WriteLine(lampada);

            lampada.Alternar();
            Console.WriteLine(lampada);

            lampada.Alternar();
            Console.WriteLine(lampada);
        }
    }
}
