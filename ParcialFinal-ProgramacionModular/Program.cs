using System.Globalization;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        static int[] habitacionID = new int[maxHabitaciones];
        static string[] tipoHabitacion = new string[maxHabitaciones];
        static double[] precioHabitacion = new double[maxHabitaciones];
        static int contadorHabitaciones = 0;
        #endregion

        #region Variables Huespedes
        static string[] nombreHuesped = new string[maxHuespedes];
        static string[] huespedID = new string[maxHuespedes];
        static long [] telefonoHuesped = new long[maxHuespedes];
        static int contadorHuespedes = 0;
        #endregion

        #region Variables Reservas
        static int[] reservaIDHabitacion = new int[maxReservas];
        static int[] reservaIDHuesped = new int[maxReservas];
        static string[] reservaFechaEntrada = new string[maxReservas];
        static int[] reservaNumNoches = new int[maxReservas];
        static bool[] habitacionReservada = new bool[maxReservas];
        static int contadorReservas = 0;
        #endregion

        static void Main(string[] args)
        {
            Menu();
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
                    BorrarPantalla();
                    break;
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

                opcion = int.Parse(Console.ReadLine());

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
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Seleccione una opción del 1 al 5.");
                        break;
                }

            } while (opcion != 5);

            BorrarPantalla();
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
                Console.WriteLine($"{habitacionID[i]}\t{tipoHabitacion[i]} \t {precioHabitacion[i]} ");
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
            int numeroHabitacion = int.Parse(Console.ReadLine());

            if (BuscarHabitacionPorID(numeroHabitacion) != -1)
            {
                Console.WriteLine("Error: Ya existe una habitación con ese número.");
                return;
            }

            Console.WriteLine("Ingrese el tipo de habitación: Individual, Doble, Familiar");
            string tipo = Console.ReadLine();

            Console.WriteLine("Ingrese el precio por noche:");
            int precio = int.Parse(Console.ReadLine());

            habitacionID[contadorHabitaciones] = numeroHabitacion;
            tipoHabitacion[contadorHabitaciones] = tipo;
            precioHabitacion[contadorHabitaciones] = precio;
            contadorHabitaciones++;

        }

        static void EditarHabitacion()
        {
            Console.WriteLine("Ingrese el número de habitación a editar:");
            int indiceHabitacion = int.Parse(Console.ReadLine());

            int indice = BuscarHabitacionPorID(indiceHabitacion);
            if (indice == -1)
            {
                Console.WriteLine("Error: Habitación no encontrada.");
                return;
            }

            Console.WriteLine($"\nEditando Habitación {habitacionID[indice]} ({tipoHabitacion[indice]})");

            Console.Write("Nuevo tipo de habitación (actual: " + tipoHabitacion[indice] + "): ");
            string nuevoTipo = Console.ReadLine();

            tipoHabitacion[indice] = nuevoTipo;

            Console.Write("Nuevo precio (actual: " + precioHabitacion[indice] + "): ");
            double nuevoPrecio = Double.Parse(Console.ReadLine());

            precioHabitacion[indice] = nuevoPrecio;


            Console.WriteLine("\n La información de la habitación ha sido actualizada.");

            BorrarPantalla();
        }

        static void VerDisponibilidadHabitacion()
        {
            Console.WriteLine("Ingrese la fecha de entrada");
            string fechaEntrada = Console.ReadLine();

            Console.WriteLine("Ingrese el número de noches");
            int numNoches = int.Parse(Console.ReadLine());

            Console.WriteLine($"Habitaciones disponibles para: {fechaEntrada} por {numNoches} noches:");
            Console.WriteLine("Número:\t Tipo:\t Precio por Noche:");

            for (int i = 0; i < contadorHabitaciones; i++)
            {
                string disponibilidad = ValidarDisponibilidadHabitacion(i, fechaEntrada, numNoches) ? " Disponible" : "Ocupada";
                Console.WriteLine($"{habitacionID[i]}\t{tipoHabitacion[i],-10}\t{precioHabitacion[i]:C}\t{disponibilidad}");
            }

            BorrarPantalla();
        }
        #endregion

        //Realizado por Majo
        #region Gestión de Huespedes

        static void GestionHuespedes()
        {
            int opcion;

            do { 
            Console.WriteLine($"Bienvenido a la gestión huéspedes;ingrese la opción que requiere" +
                "\n 1.Registrar huéspedes" + "\n 2.Mostrar lista de huéspedes" + "\n 3.Editar información  huésped" +
                "\n 4.Salir de gestión de huéspedes");
            opcion = int.Parse(Console.ReadLine());

            
           
                switch (opcion)
                {
                    case 1:
                        RegistrarHuesped();
                        break;
                    case 2:
                        MostrarListaHuespedes();
                        break;
                    case 3:
                        EditarHuesped();
                        break;
                    case 4:
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 4);
        }

        static void RegistrarHuesped()
        {
            
            if (contadorHuespedes >= maxHuespedes)
            {
                Console.WriteLine("\nError: Capacidad máxima de huéspedes (20) alcanzada.");
                return;
            }

            Console.Write("\nIngrese nombre del huésped: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese documento de identidad: ");
            string documento = Console.ReadLine();


            if (BuscarHuespedPorID(documento) != -1)
            {
                Console.WriteLine("Error: Ya existe un huésped con ese documento.");
                return;
            }

            Console.Write("Ingrese teléfono: ");
            long telefono = long.Parse(Console.ReadLine());

            nombreHuesped[contadorHuespedes] = nombre;
            huespedID[contadorHuespedes] = documento;
            telefonoHuesped[contadorHuespedes] = telefono;
            contadorHuespedes++;

            Console.WriteLine("\n Huésped registrado con éxito.");

            BorrarPantalla();
        }

        static void MostrarListaHuespedes()
        {
            if (contadorHuespedes == 0)
            {
                Console.WriteLine("\n No hay huéspedes registrados.");
                return;
            }

            Console.WriteLine("\n Lista de huéspedes registrados ");
            Console.WriteLine("ID\t Documento\t\tNombre\t\tTeléfono");

            for (int i = 0; i < contadorHuespedes; i++)
            {

                Console.WriteLine($"{i + 1}\t{huespedID[i],-15}\t{nombreHuesped[i],-10}\t{telefonoHuesped[i]}");
            }

            BorrarPantalla();
        }

        static void EditarHuesped()
        {
            Console.Write("\nIngrese el documento de identidad del huésped a editar: ");
            string documento = Console.ReadLine();

            int indice = BuscarHuespedPorID(documento);
            if (indice == -1)
            {
                Console.WriteLine("Error: Huésped no encontrado.");
                return;
            }

            Console.WriteLine($"\nEditando Huésped: {nombreHuesped[indice]} ");

            Console.Write("Nuevo nombre (actual: " + nombreHuesped[indice] + "): ");
            string nuevoNombre = Console.ReadLine();
            nombreHuesped[indice] = nuevoNombre;

            Console.Write("Nuevo teléfono (actual: " + telefonoHuesped[indice] + "): ");
            int nuevoTelefono = Convert.ToInt32(Console.ReadLine());

            telefonoHuesped[indice] = nuevoTelefono;

            Console.WriteLine("\n Información del huésped actualizada.");
        }
        #endregion

        #region Gestión de Reservas
        //Realizado por Laura
        static void GestionReservas()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n GESTIÓN DE RESERVAS");
                Console.WriteLine("1. Crear una nueva reserva");
                Console.WriteLine("2. Ver reservas de una habitación específica");
                Console.WriteLine("3. Ver historial de reservas por huésped");
                Console.WriteLine("4. Cancelar una reserva");
                Console.WriteLine("5. Salir de Gestión de reservas");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearReserva();
                        break;
                    case 2:
                        MostrarListaReservas();
                        break;
                    case 3:
                        HistorialReservas();
                        break;
                    case 4:
                        CancelarReserva();
                        break;
                    case 5:
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 5);
        }

        //Realizado por Majo
        static void CrearReserva()
        {
            if (contadorReservas >= maxReservas)
            {
                Console.WriteLine("\nError: Capacidad máxima de reservas alcanzada.");
                return;
            }

            // 1. Seleccionar Habitación
            Console.Write("\nIngrese número de habitación a reservar: ");
            if (!int.TryParse(Console.ReadLine(), out int numHabitacionElegido))
            {
                Console.WriteLine("Número de habitación inválido.");
                return;
            }
            int indiceHabitacion = BuscarHabitacionPorID(numHabitacionElegido);
            if (indiceHabitacion == -1)
            {
                Console.WriteLine("Error: Habitación no encontrada.");
                return;
            }

            Console.Write("Ingrese documento de identidad del huésped: ");
            string documentoHuespedElegido = Console.ReadLine();
            int indiceHuesped = BuscarHuespedPorID(documentoHuespedElegido);
            if (indiceHuesped == -1)
            {
                Console.WriteLine("Error: Huésped no registrado. Regístrelo primero.");
                return;
            }

            Console.Write("Ingrese fecha de entrada (día/mes/año),ej:10/04/2025");
            string fechaEntradaString = Console.ReadLine();
            if (ConvertirAFecha(fechaEntradaString) == DateTime.MinValue)
            {
                Console.WriteLine("Error: Formato de fecha inválido.");
                return;
            }

            Console.Write("Ingrese número de noches: ");
            int numNoches = int.Parse(Console.ReadLine());

            if (ValidarDisponibilidadHabitacion(indiceHabitacion, fechaEntradaString, numNoches))
            {
                reservaIDHabitacion[contadorReservas] = indiceHabitacion;
                reservaIDHuesped[contadorReservas] = indiceHuesped;
                reservaFechaEntrada[contadorReservas] = fechaEntradaString;
                reservaNumNoches[contadorReservas] = numNoches;
                habitacionReservada[contadorReservas] = true;
                contadorReservas++;
                Console.WriteLine($"\n Reserva de {numNoches} noches creada con éxito para la Hab. {habitacionID[indiceHabitacion]}.");
            }
            else
            {
                Console.WriteLine("\nError: La habitación no está disponible en las fechas seleccionadas (Hay solapamiento con otra reserva).");
            }

            BorrarPantalla();
        }

            static void MostrarListaReservas()
            {
            Console.Write("\nIngrese número de habitación para ver reservas: ");
            int numHabitacionElegido = int.Parse(Console.ReadLine());

            int indiceHabitacion = BuscarHabitacionPorID(numHabitacionElegido);
            if (indiceHabitacion == -1)
            {
                Console.WriteLine("Error: Habitación no encontrada.");
                return;
            }

            Console.WriteLine($"\nRESERVAS PARA HABITACIÓN {habitacionID[indiceHabitacion]}");
            Console.WriteLine("No.\tHuésped\t\tEntrada\t\tSalida\t\tActiva");

            bool encontradas = false;
            for (int i = 0; i < contadorReservas; i++)
            {
                if (reservaIDHabitacion[i] == indiceHabitacion)
                {
                    encontradas = true;
                    DateTime entrada = ConvertirAFecha(reservaFechaEntrada[i]);
                    DateTime salida = entrada.AddDays(reservaNumNoches[i]);

                    Console.WriteLine($"{i + 1}\t{nombreHuesped[reservaIDHuesped[i]],-10}\t{entrada:d}\t{salida:d}\t{(habitacionReservada[i] ? "Si" : "No")}");
                }
            }

            if (!encontradas)
            {
                Console.WriteLine("No hay reservas registradas para esta habitación.");
            }

            BorrarPantalla();
        }

            //Realizado por Laura
            static void HistorialReservas()
            {
            Console.Write("\nIngrese documento de identidad del huésped: ");
            string documentoHuespedElegido = Console.ReadLine();
            int indiceHuesped = BuscarHuespedPorID(documentoHuespedElegido);
            if (indiceHuesped == -1)
            {
                Console.WriteLine("Error: Huésped no encontrado.");
                return;
            }

            Console.WriteLine($"\nHISTORIAL DE RESERVAS DE {nombreHuesped[indiceHuesped]}");
            Console.WriteLine("No.\tHabitación\tEntrada\t\tNoches\t\tEstado");


            bool encontradas = false;
            for (int i = 0; i < contadorReservas; i++)
            {
                if (reservaIDHuesped[i] == indiceHuesped)
                {
                    encontradas = true;
                    string estado = habitacionReservada[i] ? "Activa" : "Cancelada";

                    Console.WriteLine($"{i + 1}\t{habitacionID[reservaIDHabitacion[i]]}\t\t{reservaFechaEntrada[i]}\t{reservaNumNoches[i]}\t\t{estado}");
                }
            }

            if (!encontradas)
            {
                Console.WriteLine("No hay historial de reservas para este huésped.");
            }

            BorrarPantalla();
        }

            static void CancelarReserva()
            {
            Console.Write("\nIngrese número de habitación de la reserva a cancelar: ");
            if (!int.TryParse(Console.ReadLine(), out int numHabitacionElegido))
            {
                Console.WriteLine("Número de habitación inválido.");
                return;
            }
            int indiceHabitacion = BuscarHabitacionPorID(numHabitacionElegido);

            Console.Write("Ingrese documento del huésped asociado a la reserva: ");
            string documentoHuespedElegido = Console.ReadLine();
            int indiceHuesped = BuscarHuespedPorID(documentoHuespedElegido);

            if (indiceHabitacion == -1 || indiceHuesped == -1)
            {
                Console.WriteLine("Error: Habitación o Huésped no encontrados.");
                return;
            }

            int indiceReserva = -1;

            for (int i = 0; i < contadorReservas; i++)
            {
                if (habitacionReservada[i] && reservaIDHabitacion[i] == indiceHabitacion && reservaIDHuesped[i] == indiceHuesped)
                {
                    indiceReserva = i;
                    break;
                }
            }

            if (indiceReserva != -1)
            {
                habitacionReservada[indiceReserva] = false; 
                Console.WriteLine($"\nReserva de Hab. {habitacionID[indiceHabitacion]} a nombre de {nombreHuesped[indiceHuesped]} ha sido Cancelada.");
            }
            else
            {
                Console.WriteLine("Error: No se encontró una reserva Activa para esa combinación de Habitación y Huésped.");
            }
        }

            #endregion

        #region Módulos auxiliares para validar y buscar

        //Realizado por Laura
        static bool ValidarDisponibilidadHabitacion(int indiceHabitacion, string fechaEntradaString, int numNochesInt)
        {
            DateTime nuevaEntrada = ConvertirAFecha(fechaEntradaString);

            if (nuevaEntrada == DateTime.MinValue)
            {
                return false;
            }

            DateTime nuevaSalida = nuevaEntrada.AddDays(numNochesInt);

            for (int i = 0; i < contadorReservas; i++)
            {
                
                if (habitacionReservada[i] && reservaIDHabitacion[i] == indiceHabitacion)
                {
                    DateTime existenteEntrada = ConvertirAFecha(reservaFechaEntrada[i]);
                    DateTime existenteSalida = existenteEntrada.AddDays(reservaNumNoches[i]);

                    if (nuevaEntrada < existenteSalida && nuevaSalida > existenteEntrada)
                    {
                        return false; 
                    }
                }
            }
            return true;
        }

        static DateTime ConvertirAFecha(string fecha)
        {
            if(DateTime.TryParseExact(fecha, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaConvertida))
            {
                return fechaConvertida;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        //Realizado por Majo
        static int BuscarHuespedPorID(string ID)
        {
            for (int i = 0; i < contadorHuespedes; i++)
            {
                if (huespedID[i] == ID)
                {
                    return i; 
                }
            }
            return -1; 
        }

        //Realizado por Laura
        static int BuscarHabitacionPorID(int numero)
        {
            for(int i= 0; i< contadorHabitaciones; i++)
            {
                if (habitacionID[i] == numero)
                {
                    return i;
                }
                
            }
            return -1;
        }

        static void BorrarPantalla()
        {
            Console.Clear();
        }

        #endregion
        }
    }

