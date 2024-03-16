class Program
{
    public static void Main(string[] args)
    {
        int totalCantidadLlamadas = 0;
        int totalFacturaTotal = 0;
        bool makeAnotherCall = true;

        while (makeAnotherCall)
        {
            Llamada llamada = new Llamada();
            totalCantidadLlamadas += llamada.cantidadLlamadas;
            totalFacturaTotal += llamada.facturaTotal;

            Console.WriteLine("¿Desea realizar otra llamada? (Sí/No)");
            string? answer = Console.ReadLine()?.ToLower();

            makeAnotherCall = answer == "s" || answer == "si" || answer == "y" || answer == "yes";
        }

        Informe informe = new Informe(totalCantidadLlamadas, totalFacturaTotal);
        informe.MostrarInforme();
    }

   public class Llamada
    {
      public int cantidadLlamadas = 0;
      public int facturaTotal = 0;

      public Llamada()
      {
        Console.WriteLine("Ingrese su numero de telefono: ");
        string? numero1 = Console.ReadLine();

        if (numero1 != null && numero1.Length == 10)
        {
          string n1 = numero1.Substring(0, 2);

          Console.WriteLine("Ingrese el numero al que desea llamar: ");
          string? numero2 = Console.ReadLine();

          if (numero2 != null && numero2.Length == 10)
          {
            string n2 = numero2.Substring(0, 2);

            if (n1 == n2)
            {
              Console.WriteLine("Llamada local realizada, se le cobraran 15 centimas el segundo");

              Console.WriteLine("Ingrese la duración de la llamada en segundos: ");
              int callDuration = Convert.ToInt32(Console.ReadLine() ?? "0");
              CallCost(callDuration, n1, n2);
            }
            else
            {
              Console.WriteLine("Llamada no local realizada, se le cobraran 30 centimos el segundo");

              Console.WriteLine("Ingrese la duración de la llamada en segundos: ");
              int callDuration = Convert.ToInt32(Console.ReadLine() ?? "0");
              CallCost(callDuration, n1, n2);
            }
          }
        }

      }

      public void CallCost(int callDuration, string n1, string n2)
      {
          if (n1 == n2)
          {
              int callCost = callDuration * 15;
              Console.WriteLine($"El costo de la llamada es: {callCost} centimas");
              cantidadLlamadas += 1;
              facturaTotal += callCost;
          }
          else
          {
              int callCost = callDuration * 30;
              Console.WriteLine($"El costo de la llamada es: {callCost} centimas");
              cantidadLlamadas += 1;
              facturaTotal += callCost;
          }

      }
    }

    public class Informe
    {
        private int cantidadLlamadas;
        private int facturaTotal;

        public Informe(int cantidadLlamadas, int facturaTotal)
        {
            this.cantidadLlamadas = cantidadLlamadas;
            this.facturaTotal = facturaTotal;
        }

        public void MostrarInforme()
        {
            Console.WriteLine($"Cantidad total de llamadas: {cantidadLlamadas}");
            Console.WriteLine($"Factura total de todas las llamadas: {facturaTotal} centimas");
        }
    }

}
