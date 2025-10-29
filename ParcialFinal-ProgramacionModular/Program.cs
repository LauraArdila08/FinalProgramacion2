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
        double[] precioHabitacion = new double[maxHabitaciones];
        int contadorHabitaciones = 0;
        #endregion

        #region Variables Huespedes
        string[] nombreHuesped = new string[maxHuespedes];
        int[] huespedID = new int[maxHuespedes];
        int[] telefonoHuesped = new int[maxHuespedes];
        int contadorHuespedes = 0;
        #endregion

        #region Variables Reservas
        int[] reservaIDHabitacion = new int[maxReservas];
        int[] reservaIDHuesped = new int[maxReservas];
        string[] fechaEntrada = new string[maxReservas];
        int[] numNoches = new int[maxReservas];
        bool[] habitacionReservada = new bool[maxReservas];
        int contadorReservas = 0;
        #endregion

        static void Main(string[] args)
        {

        }

        //Realizado por Majo

        static void Menu()
        {
            Console.WriteLine($"Menú hotel L&M");
            Console.WriteLine($" \n Seleccione la opción que desee realizar" + "\n 1.Ir al menú de gestión de habitaciones"
                + "\n 2.Ir al menú de gestión de huespedes" + "\n 3.Ir al menú de gestión de reservas "
                + "\n 4.Salir del programa");
            int opcion = int.Parse(Console.ReadLine());
           
            switch (opcion)
            {
                case 1:
                    GestionHabitaciones();
                    break;
                case 2:
                    GestionHuespedes();
                    break;
                case 3:
                    GestionReservas();
                    break;
                case 4:
                //BorrarConsola();
                default:
                    Console.WriteLine($"Acción inválida ,ingresar un número entre 1 y 4");
                    break;
            }

        }


        //Realizado por Laura
        #region Gestión de Habitaciones

       static void GestionHabitaciones()
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

         static void MostrarListaHabitaciones()
        {
            if (contadorHabitaciones == 0)
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

       static void RegistrarHabitacion()
        {
            if (contadorHabitaciones >= maxHabitaciones)
            {
                Console.WriteLine("No se pueden registrar más habitaciones. Capacidad máxima de habitaciones alcanzada");
                return;
            }

            Console.WriteLine("Ingrese el número de habitación:");
            if (!int.TryParse(Console.ReadLine(), out int numeroHabitacion) || numeroHabitacion <= 0)
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
            if (!double.TryParse(Console.ReadLine(), out double precio) || precio <= 0)
            {
                Console.WriteLine("Precio inválido. Debe ser un número positivo.");
                return;
            }

            numHabitacion[contadorHabitaciones] = numeroHabitacion;
            tipoHabitacion[contadorHabitaciones] = tipo;
            precioHabitacion[contadorHabitaciones] = precio;
            contadorHabitaciones++;

        }

         static void EditarHabitacion()
        {
            Console.WriteLine("Ingrese el número de habitación a editar:");
            if (!int.TryParse(Console.ReadLine(), out int numeroHabitacion) || numeroHabitacion <= 0)
            {
                Console.WriteLine("Número de habitación inválido. Debe ser un número entero.");
                return;

                int indiceHabitacion; //= BuscarHabitacionPorNumero();

            }
        }

       static void VerDisponibilidadHabitacion()
        {
            Console.WriteLine("Ingrese la fecha de entrada");
            string fechaEntrada = Console.ReadLine();

            Console.WriteLine("Ingrese el número de noches");
            if (!int.TryParse(Console.ReadLine(), out int numNoches) || numNoches <= 0)
            {
                Console.WriteLine("Número de noches inválido. Debe ser un número entero positivo.");
                return;
            }

            Console.WriteLine($"Habitaciones disponibles para: {fechaEntrada} por {numNoches} noches:");
            Console.WriteLine("Número:\t Tipo:\t Precio por Noche:");

            for (int i = 0; i < contadorHabitaciones; i++)
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

