namespace Generic
{
    class Program
    {
        public static void Main(string[] args)
        {
            MiLista<int> numeros = new MiLista<int>(10);

            numeros.Add(3);
            numeros.Add(4);

            MiLista<string> nombres = new MiLista<string>(2);
            nombres.Add("Manuel");
            nombres.Add("Jose");

            MiLista<Persona> persona = new MiLista<Persona>(2);
            persona.Add(new Persona { nombre="Emilio", estatura = 1.72});
            persona.Add(new Persona { nombre = "Mauricio", estatura = 1.42 });

            Console.WriteLine(nombres.ObtenerString());
            Console.WriteLine(numeros.ObtenerString());
            Console.WriteLine(persona.ObtenerString());

            Console.WriteLine(numeros.ObtenerElemento(1));
            Console.WriteLine(nombres.ObtenerElemento(0));
            

        }
        public class Persona
        {
            public string nombre { get; set; }
            public double estatura { get; set; }

            public override string ToString()
            {
                return $"Nombre: {nombre} Estatura: {estatura}";
            }
        }

        public class MiLista <T>
        {
            private T[] _elementos;
            private int _index = 0;

            public MiLista(int n)
            {
                //Aqui le decimos que el valor recibido, se guarda como T
                this._elementos = new T[n];
            }

            //Aqui ahora recibimos la T
            public void Add(T n)
            {
                if(_index < _elementos.Length)
                {
                    _elementos[_index] = n;
                    _index++;
                }
            }

            public T ObtenerElemento (int n)
            {
                if(n < _index && n >= 0)
                {
                    return _elementos[n];
                }   

                return  default(T);
            }

            public string ObtenerString()
            {
                int i = 0;
                string resultado = "";
                while (i < _index)
                {
                    resultado += _elementos[i].ToString() + ",";
                    i++;
                }

                return resultado;
            }
        }
    }
}
