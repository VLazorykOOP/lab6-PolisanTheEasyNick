using System;
using System.Collections;

namespace Lab6CSharp
{
    interface IAction
    {
        void Start();
        void Stop();
    }
    
class Engine: IAction
    {
        protected string Model;

        public Engine()
        {
            Model = "Default engine";
        }
        public Engine(string m)
        {
            Model = m;
        }

        public Engine(int m)
        {
            Model = m.ToString();
        }

        ~Engine()
        {
            Console.WriteLine("Destructor Engine");
        }
        
        public void Show()
        {
            Console.WriteLine($"Model: {Model}");
        }

        public void Start()
        {
            Console.WriteLine("Engine started");
        }

        public void Stop()
        {
            Console.WriteLine("Engine stopped");
        }

        public override string ToString()
        {
            return Model;
        }
    }

    class InternalEngine : Engine, IComparable, IAction
    {
        private readonly double _v;

        public InternalEngine()
        {
            _v = 5;
            Model = "Internal engine";
        }
        public InternalEngine(double v)
        {
            _v = v;
            Model = "React engine";
        }

        public InternalEngine(double v, string m) : base(m)
        {
            _v = v;
        }

        ~InternalEngine()
        {
            Console.WriteLine("Destructor Internal Engine");
        }


        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            var other = obj as InternalEngine;
            if (other != null)
            {
                return this._v.CompareTo(other._v);
            }
            else
                throw new ArgumentException("Object is not a InternalEngine");
        }

        public new void Show()
        {
            Console.WriteLine($"Model: {Model}\nV: {_v}");
        }
        public void Start()
        {
            Console.WriteLine("InternalEngine started");
        }

        public void Stop()
        {
            Console.WriteLine("InternalEngine stopped");
        }
    }

    class DieselEngine : Engine, IComparable, IAction
    {
        private readonly double _v;

        public DieselEngine()
        {
            _v = 2;
            Model = "Diesel engine";
        }
        public DieselEngine(double v)
        {
            _v = v;
            Model = "React engine";
        }

        public DieselEngine(double v, string m) : base(m)
        {
            _v = v;
        }

        ~DieselEngine()
        {
            Console.WriteLine("Destructor Diesel Engine");
        }
        public new void Show()
        {
            Console.WriteLine($"Model: {Model}\nV: {_v}");
        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            var other = obj as DieselEngine;
            if (other != null)
            {
                return this._v.CompareTo(other._v);
            }
            else
                throw new ArgumentException("Object is not a InternalEngine");
        }
        public void Start()
        {
            Console.WriteLine("DieselEngine started");
        }

        public void Stop()
        {
            Console.WriteLine("DieselEngine stopped");
        }
        
    }

    class ReactEngine : Engine, IComparable, IAction
    {
        private readonly double _v;

        public ReactEngine()
        {
            _v = 6;
            Model = "React engine";
        }
        public ReactEngine(double v)
        {
            _v = v;
            Model = "React engine";
        }

        public ReactEngine(double v, string m) : base(m)
        {
            _v = v;
        }

        ~ReactEngine()
        {
            Console.WriteLine("Destructor React Engine");
        }
        public new void Show()
        {
            Console.WriteLine($"Model: {Model}\nV: {_v}");
        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            var other = obj as ReactEngine;
            if (other != null)
            {
                return this._v.CompareTo(other._v);
            }
            else
                throw new ArgumentException("Object is not a InternalEngine");
        }
        public void Start()
        {
            Console.WriteLine("ReactEngine started");
        }

        public void Stop()
        {
            Console.WriteLine("ReactEngine stopped");
        }
    }

    interface IFunction
    {
        double Calculate(double x);
    }

    class Line : IFunction
    {
        public double a, b;
        public Line()
        {
            a = 0;
            b = 0;
        }
        public Line(double a_, double b_)
        {
            a = a_;
            b = b_;
        }
        public double Calculate(double x)
        {
            return a * x + b;
        }
    }

    class Quadratic : IFunction
    {
        public double a, b, c;
        public Quadratic()
        {
            a = 0;
            b = 0;
            c = 0;
        }
        public Quadratic(double a_, double b_, double c_)
        {
            a = a_;
            b = b_;
            c = c_;
        }
        public double Calculate(double x)
        {
            return a * x * x + b * x + c;
        }
    }
    
    class Hyperbola : IFunction
    {
        public double k;
        public Hyperbola()
        {
            k = 0;
        }
        public Hyperbola(double k_)
        {
            k = k_;
        }
        public double Calculate(double x)
        {
            return k/x;
        }
    }

    class Engines : IEnumerable
    {
        private Engine[] _engines;

        public Engines(Engine[] arr)
        {
            _engines = arr;
        }

        public IEnumerator GetEnumerator()
        {
            return new EngineEnum(_engines);
        }
    }
    
    class EngineEnum: IEnumerator
    {
        public Engine[] _models;
        private int pos = -1;
        public EngineEnum(Engine[] list)
        {
            _models = list;
        }

        ~EngineEnum()
        {
            Console.WriteLine("Destructor Engine");
        }
        
        public bool MoveNext()
        {
            pos++;
            return (pos < _models.Length);
        }

        public void Reset()
        {
            pos = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Engine Current 
        { 
            get
            {
              try
              {
                return _models[pos];
              }
              catch (IndexOutOfRangeException)
              {
                throw new InvalidOperationException();
              }
            } 
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Show();
            InternalEngine internalEngine = new(5, "Internal");
            internalEngine.Show();
            ReactEngine reactEngine = new(2.2);
            reactEngine.Show();
            DieselEngine dieselEngine = new();
            dieselEngine.Show();
            
            //----
            Line line = new(3, 6);
            Console.WriteLine(line.Calculate(2).ToString());
            Quadratic quad = new(1, 2, 3);
            Console.WriteLine(quad.Calculate(2).ToString());
            Hyperbola hyp = new(4);
            Console.WriteLine(hyp.Calculate(2).ToString());
            Console.WriteLine("End of main");
            //----
            Engine[] arr = new Engine[3];
            arr[0] = new Engine("first");
            arr[1] = new Engine("second");
            arr[2] = new Engine("third");
        
            Engines eng = new Engines(arr);
            foreach (var engineModel in eng)
            {
                Console.WriteLine(engineModel.ToString());
            }
        }
    }
}