using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<String> WriteLine = Console.WriteLine;
            List<Type> figuras = new List<Type>()
            {
            typeof(Estrella),
            typeof(Rayo),
            typeof(Corazon)
            };

            var Container = new Container(figuras);

            foreach (var figura in figuras)
            {
                Console.WriteLine(figura.ToString());
            }
            Console.ReadLine();
        }
    }

    public class Paint
    {
        private static readonly Lazy<Paint> instance = new Lazy<Paint>(() => new Paint());

        private Paint()
        {
        }

        public static Paint Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }

    public class Consola : IConsola
    {
        public Consola(IConsola consola, IContainer Container) { }
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
        public string Read()
        {
            return Console.ReadLine();
        }
    }

    public interface IConsola
    {
        void Write(string s);
        string Read();
    }


    public class Lienzo : ILienzo
    {
        public Lienzo(ILienzo Lienzo, IConsola Consola) { }
    }

    public interface ILienzo
    {
    }


    public class Toolbar : IToolbar
    {
        public Toolbar(IToolbar Toolbar, IContainer Container) { }
    }

    public interface IToolbar
    {
    }


    public class Figura : IFigura
    {
        public string BordeColor { get; set; }
        public string FondoColor { get; set; }
    }

    public interface IFigura
    {
        string BordeColor { get; set; }
        string FondoColor { get; set; }
    }


    public class Container : IContainer
    {
        public Container(IList<Type> figuras) { }
    }

    public interface IContainer
    {
    }

    public class ColorContainer : IContainer
    {
        private string[] colores = { "Blanco", "Negro", "Rojo", "Amarillo", "Verde" };

        public IEnumerable<IContainer> GetEnumerator()
        {
            yield return colores;
        }
    }
    public class FigurasContainer : IContainer
    {
        private string[] figuras = { "Corazon", "Rayo", "Estrella" };

        public IEnumerable<IContainer> GetEnumerator()
        {
            yield return figuras;
        }
    }

    public class Corazon : Figura
    {
        public override string ToString()
        {
            return "Corazon";
        }
    }

    public class Rayo : Figura
    {
        public override string ToString()
        {
            return "Rayo";
        }
    }

    public class Estrella : Figura
    {
        public override string ToString()
        {
            return "Estrella";
        }
    }

    public class GenericList<T>
    {
        void Add(T input) { }
    }
}
