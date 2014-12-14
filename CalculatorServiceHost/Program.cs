using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CalculatorServiceHost
{
    [ServiceContract]
    public interface IMath
    {
        [OperationContract]
        double Add(double x);
        [OperationContract]
        double Subtract(double x);
        [OperationContract]
        double Multiplication(double x);
        [OperationContract]
        double Division(double x);
        [OperationContract]
        double Modular(double x);
        [OperationContract]
        double GetRunningTotal();
    }

    //ConcurrencyMode.Single - single threaded sequential execution, 
    //ConcurrencyMode.Multiple - multi-threaded and parallel execution
    //ConcurrencyMode.Reentrant - used in deadlock scenarios

    //different object id and same session id
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 

    //same object id and same sesion id
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]

    //default is PerSession and need not be specified
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MathService : IMath
    {
        double runningTotal;
        public double Add(double x)
        {
            Console.WriteLine("object id: {0}, session id: {1}", this.GetHashCode(), OperationContext.Current.SessionId);
            return runningTotal += x;
        }

        public double Subtract(double x)
        {
            Console.WriteLine("object id: {0}, session id: {1}", this.GetHashCode(), OperationContext.Current.SessionId);
            return runningTotal -= x;
        }

        public double Multiplication(double x)
        {
            Console.WriteLine("object id: {0}, session id: {1}", this.GetHashCode(), OperationContext.Current.SessionId);
            return runningTotal *= x;
        }

        public double Division(double x)
        {
            Console.WriteLine("object id: {0}, session id: {1}", this.GetHashCode(), OperationContext.Current.SessionId);
            return runningTotal /= x;
        }

        public double Modular(double x)
        {
            Console.WriteLine("object id: {0}, session id: {1}", this.GetHashCode(), OperationContext.Current.SessionId);
            return runningTotal %= x;
        }


        public double GetRunningTotal()
        {
            return runningTotal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MathService));
            host.Open();
            Console.WriteLine("Service up and running");
            Console.ReadLine();
        }
    }
}
