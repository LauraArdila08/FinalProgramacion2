using System.Reflection.Metadata;

namespace ParcialFinal_ProgramacionModular
{
    internal class Program
    {
        //Variables globales

        //constantes
        const int maxHabitaciones = 20;
        const int maxHuespedes = 20;
        const int maxReservas = maxHabitaciones;

        #region Variables Habitaciones
        int[] numHabitacion = new int[maxHabitaciones];
        string[] tipoHabitacion = new string[maxHabitaciones];
        double [] precioHabitacion = new double[maxHabitaciones];
        int contadorHabitaciones = 0;
        #endregion

        #region Variables Huespedes
        string[] nombreHuesped = new string[maxHuespedes];
        int[] huespedID = new int[maxHuespedes];
        int[] telefonoHuesped = new int[maxHuespedes];
        int contadorHuespedes = 0;
        #endregion

        #region Variables Reservas
        int[] reservaIDHabitacion = new int [maxReservas];
        int [] reservaIDHuesped = new int [maxReservas];
        string[] fechaEntrada = new string [maxReservas];
        int[] numNoches = new int [maxReservas];
        bool [] habitacionReservada = new bool [maxReservas];
        int contadorReservas = 0;
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        //Realizado por Majo
        namespace ConsoleApp2

    {

        internal class Program
        {


            static void Main(string[] args)
            {

                int[,] habitaciones = new int[20, 3];

                int habitacionesCreadas = 0;

                while (true)
                {

                    Console.WriteLine("Bienvenido, escoja una opcion " +

                        "\n 1... Crear habitación" +

                        "\n 2... Ver habitaciones" +

                        "\n 3... Editar habitaciones");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    BorrarConsola();

                    switch (opcion)
                    {

                        case 1:

                            CrearHabitacion(habitaciones, habitacionesCreadas);

                            habitacionesCreadas++;

                            break;

                        case 2:

                            MostrarMatriz(habitaciones);

                            break;

                        case 3:

                            EditarHabitacion(habitaciones);

                            break; // Sale del Main (termina el programa)

                        default:

                            Console.WriteLine("Opción no válida. Intente de nuevo.");

                            break;

                    }

                }


            }

            static void EditarHabitacion(int[,] habitaciones)
            {

                Console.WriteLine("EDITANDO HABITACIÓN");

                Console.WriteLine("Por favor ingrese el numero de la habitacion a editar");

                int numeroDeHabitacion = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < habitaciones.GetLength(0); i++)
                {

                    if (habitaciones[i, 0] == numeroDeHabitacion)
                    {

                        Console.WriteLine("Habitacion encontrada");

                        CrearHabitacion(habitaciones, i);

                        return;

                    }

                }

                Console.WriteLine("Habitacion no encontrada");

            }

            static void CrearHabitacion(int[,] habitaciones, int indexDeHabitacion)
            {

                if (indexDeHabitacion == 20)
                {

                    Console.WriteLine("HABITACIONES COMPLETAS");

                    return;

                }

                Console.WriteLine("Creando habitacion");

                Console.WriteLine("Ingrese el número de la habitacion");

                int numero = Convert.ToInt32(Console.ReadLine());

                habitaciones[indexDeHabitacion, 0] = numero;

                Console.WriteLine("Ingrese el tipo de la habitacion");

                Console.WriteLine("1 -> basica \n 2 -> Doble \n 3 -> Familiar");

                bool tipoValido = false;

                while (tipoValido == false)
                {

                    int tipo = Convert.ToInt32(Console.ReadLine());

                    if (tipo < 1 || tipo > 3)
                    {

                        tipoValido = false;

                        Console.WriteLine("Tipo de habitacio no es valido, vuelva a intentarlo");

                    }
                    else
                    {

                        tipoValido = true;

                        habitaciones[indexDeHabitacion, 1] = tipo;

                    }

                }


                Console.WriteLine("Ingrese el precio de la habitacion");

                int precio = Convert.ToInt32(Console.ReadLine());

                habitaciones[indexDeHabitacion, 2] = precio;


            }

            static void MostrarMatriz(int[,] matriz)
            {

                Console.WriteLine("Numero  Tipo   Precio");

                for (int i = 0; i < matriz.GetLength(0); i++)
                {

                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {

                        if (j == 1)
                        {

                            if (matriz[i, j] == 1) Console.Write("Basica  ");

                            else if (matriz[i, j] == 2) Console.Write("Doble     ");

                            else if (matriz[i, j] == 3) Console.Write("Familiar  ");

                        }
                        else
                        {

                            Console.Write($"{matriz[i, j]} |");

                        }


                    }

                    Console.WriteLine();

                }

            }

            static void BorrarConsola()
            {

                Console.Clear();

            }

        }


    }



    //Realizado por Laura
    #region Gestión de Habitaciones

    void GestionHabitaciones()
        {
            int opcion;

            do
            {
                Console.WriteLine("Gestión de Habitaciones:");
                Console.WriteLine("1. Registrar nueva habitación");
                Console.WriteLine("2. Mostrar lista de habitaciones");
                Console.WriteLine("3. Editar habitación");
                Console.WriteLine("4. Ver disponibilidad de habitación");
                Console.WriteLine("5. Volver al menú principal");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarHabitacion();
                        break;
                    case 2:
                        MostrarListaHabitaciones();
                        break;
                    case 3:
                        EditarHabitacion();
                        break;
                    case 4:
                        VerDisponibilidadHabitacion();
                        break;
                    case 5:
                        Console.WriteLine("Volviendo al menú principal");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Seleccione una opción del 1 al 5.");
                        break;
                }

            } while (opcion != 5);
        }

        void MostrarListaHabitaciones()
        {
            if(contadorHabitaciones == 0)
            {
                Console.WriteLine("No hay habitaciones registradas.");
                return;
            }

            Console.WriteLine("Lista de Habitaciones:");
            Console.WriteLine("Número:\t Tipo:\t Precio por Noche:");
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                Console.WriteLine($"{numHabitacion[i]}\t{tipoHabitacion[i]} \t {precioHabitacion[i]} ");
            }
        }

        void RegistrarHabitacion()
        {
            if(contadorHabitaciones >= maxHabitaciones)
            {
                Console.WriteLine("No se pueden registrar más habitaciones. Capacidad máxima de habitaciones alcanzada");
                return;
            }

            Console.WriteLine("Ingrese el número de habitación:");
            if(!int.TryParse(Console.ReadLine(), out int numeroHabitacion) || numeroHabitacion <= 0)
            {
                Console.WriteLine("Número de habitación inválido. Debe ser un número entero.");
                return;
            }

            /*BuscarHabitacionPorNumero();
            if ()
            {

            }*/

            Console.WriteLine("Ingrese el tipo de habitación: Individual, Doble, Suite");
            string tipo = Console.ReadLine();

            Console.WriteLine("Ingrese el precio por noche:");
            if(!double.TryParse(Console.ReadLine(), out double precio) || precio <= 0)
            {
                Console.WriteLine("Precio inválido. Debe ser un número positivo.");
                return;
            }

            numHabitacion[contadorHabitaciones] = numeroHabitacion;
            tipoHabitacion [contadorHabitaciones] = tipo;
            precioHabitacion[contadorHabitaciones] = precio;
            contadorHabitaciones++;

        }

        void EditarHabitacion()
        {
            Console.WriteLine("Ingrese el número de habitación a editar:");
            if(!int.TryParse(Console.ReadLine(), out int numeroHabitacion) || numeroHabitacion <= 0)
            {
                Console.WriteLine("Número de habitación inválido. Debe ser un número entero.");
                return;

                int indiceHabitacion; //= BuscarHabitacionPorNumero();

            }
        }

         void VerDisponibilidadHabitacion()
        {
            Console.WriteLine("Ingrese la fecha de entrada");
            string fechaEntrada = Console.ReadLine();

            Console.WriteLine("Ingrese el número de noches");
            if(!int.TryParse(Console.ReadLine(), out int numNoches) || numNoches <= 0)
            {
                Console.WriteLine("Número de noches inválido. Debe ser un número entero positivo.");
                return;
            }

            Console.WriteLine($"Habitaciones disponibles para: {fechaEntrada} por {numNoches} noches:");
            Console.WriteLine("Número:\t Tipo:\t Precio por Noche:");

            for(int i = 0; i < contadorHabitaciones; i++)
            {
                string dispoinibilidad; // = ValidarDisponibilidadHabitacion();
            }
        }
        #endregion

        //Realizado por Majo
        #region Gestión de Huespedes

        void GestionHuespedes()
        {
        }

        void RegistrarHuesped()
        {
        }

        void MostrarListaHuespedes()
        {
        }

        void EditarHuesped()
        {
        }
        #endregion

        #region Gestión de Reservas
        //Realizado por Laura
        void GestionReservas()
        {
        }

        //Realizado por Majo
        void CrearReserva()
        {
        }

        void MostrarListaReservas()
        {
        }

        //Realizado por Laura
        void HistorialReservas()
        {
        }

        void CancelarReserva()
        {
        }

        #endregion

        #region Módulos auxiliares para validar y buscar

        //Realizado por Laura
        void ValidarDisponibilidadHabitacion()
        {
        }

        //Realizado por Majo
        void BuscarHuespedPorID()
        {
        }

        //Realizado por Laura
        void BuscarHabitacionPorNumero()
        {
        }

        #endregion
    }
}
