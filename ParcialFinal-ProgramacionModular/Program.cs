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
        static int[] numHabitacion = new int[maxHabitaciones];
        static string[] tipoHabitacion = new string[maxHabitaciones];
        static double[] precioHabitacion = new double[maxHabitaciones];
        static int contadorHabitaciones = 0;
        #endregion

        #region Variables Huespedes
        static string[] nombreHuesped = new string[maxHuespedes];
        static string[] huespedID = new string[maxHuespedes];
        static int[] telefonoHuesped = new int[maxHuespedes];
        static int contadorHuespedes = 0;
        #endregion

        #region Variables Reservas
        static int[] reservaIDHabitacion = new int[maxReservas];
        static int[] reservaIDHuesped = new int[maxReservas];
        static string[] fechaEntrada = new string[maxReservas];
        static int[] numNoches = new int[maxReservas];
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
            int numeroHabitacion = int.Parse(Console.ReadLine());

            if (BuscarHabitacionPorNumero(numeroHabitacion) != -1)
            {
                Console.WriteLine("ERROR: Ya existe una habitación con ese número.");
                return;
            }

            Console.WriteLine("Ingrese el tipo de habitación: Individual, Doble, Familiar");
            string tipo = Console.ReadLine();

            Console.WriteLine("Ingrese el precio por noche:");
            int precio = int.Parse(Console.ReadLine());

            numHabitacion[contadorHabitaciones] = numeroHabitacion;
            tipoHabitacion[contadorHabitaciones] = tipo;
            precioHabitacion[contadorHabitaciones] = precio;
            contadorHabitaciones++;

        }

        static void EditarHabitacion()
        {
            Console.WriteLine("Ingrese el número de habitación a editar:");
            int indiceHabitacion = int.Parse(Console.ReadLine());

            int indice = BuscarHabitacionPorNumero(indiceHabitacion);
            if (indice == -1)
            {
                Console.WriteLine("ERROR: Habitación no encontrada.");
                return;
            }

            Console.WriteLine($"\n--- Editando Habitación {numHabitacion[indice]} ({tipoHabitacion[indice]}) ---");

            Console.Write("Nuevo tipo (actual: " + tipoHabitacion[indice] + "): ");
            string nuevoTipo = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoTipo))
            {
                tipoHabitacion[indice] = nuevoTipo;
            }

            Console.Write("Nuevo precio (actual: " + precioHabitacion[indice] + "): ");
            string precioStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(precioStr) && double.TryParse(precioStr, out double nuevoPrecio) && nuevoPrecio > 0)
            {
                precioHabitacion[indice] = nuevoPrecio;
            }

            Console.WriteLine("\n La información de la habitación ha sido actualizada.");


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
                string disponibilidad = ValidarDisponibilidadHabitacion(i, fechaEntrada, numNoches) ? "✅ DISPONIBLE" : "❌ OCUPADA";
                Console.WriteLine($"{numHabitacion[i]}\t{tipoHabitacion[i],-10}\t{precioHabitacion[i]:C}\t{disponibilidad}");
            }
        }
        #endregion

        //Realizado por Majo
        #region Gestión de Huespedes

           static void GestionHuespedes()
            {
            int opcion;
            Console.WriteLine($"Bienvenido a la gestión huéspedes;ingrese la opción que requiere" +
                "\n 1.Registrar huéspedes" + "\n 2.Mostrar lista de huéspedes" + "\n 3.Editar información  huésped" +
                "\n 4.Salir de gestión de huéspedes");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }
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
                    Console.WriteLine("Volviendo al Menú Principal...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            } while (opcion != 4);
        }

            static void RegistrarHuesped()
            {
            if (contadorHuespedes >= maxHuespedes)
            {
                Console.WriteLine("\nERROR: Capacidad máxima de huéspedes (20) alcanzada.");
                return;
            }

            Console.Write("\nIngrese nombre del huésped: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese documento de identidad: ");
            int documento = Convert.ToInt32(Console.ReadLine());


            if (BuscarHuespedPorID(documento) != -1)
            {
                Console.WriteLine("ERROR: Ya existe un huésped con ese documento.");
                return;
            }

            Console.Write("Ingrese teléfono: ");
            int telefono = Convert.ToInt32(Console.ReadLine());

            nombreHuesped[contadorHuespedes] = nombre;
            huespedID[contadorHuespedes] = documento;
            telefonoHuesped[contadorHuespedes] = telefono;
            contadorHuespedes++;

            Console.WriteLine("\n Huésped registrado con éxito.");
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
            Console.WriteLine("-----------------------------------------------------");
            for (int i = 0; i < contadorHuespedes; i++)
            {

                Console.WriteLine($"{i + 1}\t{huespedID[i],-15}\t{nombreHuesped[i],-10}\t{telefonoHuesped[i]}");
            }
        }

            static void EditarHuesped()
            {
            Console.Write("\nIngrese el documento de identidad del huésped a editar: ");
            string documento = Console.ReadLine();

            int indice = BuscarHuespedPorID(documento);
            if (indice == -1)
            {
                Console.WriteLine("ERROR: Huésped no encontrado.");
                return;
            }

            Console.WriteLine($"\nEditando Huésped: {nombreHuesped[indice]} ");

            Console.Write("Nuevo nombre (actual: " + nombreHuesped[indice] + "): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                nombreHuesped[indice] = nuevoNombre;
            }

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
                Console.WriteLine("\n--- GESTIÓN DE RESERVAS ---");
                Console.WriteLine("1. Crear una nueva reserva");
                Console.WriteLine("2. Ver reservas de una habitación específica");
                Console.WriteLine("3. Ver historial de reservas por huésped");
                Console.WriteLine("4. Cancelar una reserva");
                Console.WriteLine("5. Salir de Gestión de reservas");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1: CrearReserva(); break;
                    case 2: MostrarListaReservas(); break;
                    case 3: HistorialReservas(); break;
                    case 4: CancelarReserva(); break;
                    case 5: Console.WriteLine("Volviendo al Menú Principal..."); break;
                    default: Console.WriteLine("Opción no válida. Intente de nuevo."); break;
                }
            } while (opcion != 5);
        }

            //Realizado por Majo
            static void CrearReserva()
            {
            if (contadorReservas >= maxReservas)
            {
                Console.WriteLine("\nERROR: Capacidad máxima de reservas alcanzada.");
                return;
            }

            // 1. Seleccionar Habitación
            Console.Write("\nIngrese número de habitación a reservar: ");
            if (!int.TryParse(Console.ReadLine(), out int numHabitacionElegido))
            {
                Console.WriteLine("Número de habitación inválido.");
                return;
            }
            int indiceHabitacion = BuscarHabitacionPorNumero(numHabitacionElegido);
            if (indiceHabitacion == -1)
            {
                Console.WriteLine("ERROR: Habitación no encontrada.");
                return;
            }

            // 2. Seleccionar Huésped
            Console.Write("Ingrese documento de identidad del huésped: ");
            string documentoHuespedElegido = Console.ReadLine();
            int indiceHuesped = BuscarHuespedPorID(documentoHuespedElegido);
            if (indiceHuesped == -1)
            {
                Console.WriteLine("ERROR: Huésped no registrado. Regístrelo primero.");
                return;
            }

            // 3. Ingresar Fechas y Noches
            Console.Write("Ingrese fecha de entrada (dd/MM/yyyy): ");
            string fechaEntradaString = Console.ReadLine();
            if (ConvertirAFecha(fechaEntradaString) == DateTime.MinValue)
            {
                Console.WriteLine("ERROR: Formato de fecha inválido.");
                return;
            }

            Console.Write("Ingrese número de noches: ");
            if (!int.TryParse(Console.ReadLine(), out int numNoches) || numNoches <= 0)
            {
                Console.WriteLine("Número de noches inválido.");
                return;
            }

            // 4. Validar Disponibilidad
            if (ValidarDisponibilidadHabitacion(indiceHabitacion, fechaEntradaString, numNoches))
            {
                // 5. Registrar la Reserva
                reservaIDHabitacion[contadorReservas] = indiceHabitacion;
                reservaIDHuesped[contadorReservas] = indiceHuesped;
                fechaEntrada[contadorReservas] = fechaEntradaString;
                numNoches[contadorReservas] = numNoches;
                habitacionReservada[contadorReservas] = true;
                contadorReservas++;
                Console.WriteLine($"\n✅ Reserva de {numNoches} noches creada con éxito para la Hab. {numHabitacion[indiceHabitacion]}.");
            }
            else
            {
                Console.WriteLine("\n❌ ERROR: La habitación no está disponible en las fechas seleccionadas (Hay solapamiento con otra reserva).");
            }
        }

            static void MostrarListaReservas()
            {
            Console.Write("\nIngrese número de habitación para ver reservas: ");
            if (!int.TryParse(Console.ReadLine(), out int numHabitacionElegido))
            {
                Console.WriteLine("Número de habitación inválido.");
                return;
            }
            int indiceHabitacion = BuscarHabitacion(numHabitacionElegido);
            if (indiceHabitacion == -1)
            {
                Console.WriteLine("ERROR: Habitación no encontrada.");
                return;
            }

            Console.WriteLine($"\n--- RESERVAS PARA HABITACIÓN {numHabitacion[indiceHabitacion]} ---");
            Console.WriteLine("No.\tHuésped\t\tEntrada\t\tSalida\t\tActiva");
            Console.WriteLine("------------------------------------------------------------------");

            bool encontradas = false;
            for (int i = 0; i < contadorReservas; i++)
            {
                if (reservaIDHabitacion[i] == indiceHabitacion)
                {
                    encontradas = true;
                    DateTime entrada = ConvertirAFecha(fechaEntrada[i]);
                    DateTime salida = entrada.AddDays(numNoches[i]);

                    Console.WriteLine($"{i + 1}\t{nombreHuesped[reservaIDHuesped[i]],-10}\t{entrada:d}\t{salida:d}\t{(habitacionReservada[i] ? "SI" : "NO")}");
                }
            }

            if (!encontradas)
            {
                Console.WriteLine("No hay reservas registradas para esta habitación.");
            }
        }

            //Realizado por Laura
            static void HistorialReservas()
            {
            Console.Write("\nIngrese documento de identidad del huésped: ");
            string documentoHuespedElegido = Console.ReadLine();
            int indiceHuesped = BuscarHuespedPorID(documentoHuespedElegido);
            if (indiceHuesped == -1)
            {
                Console.WriteLine("ERROR: Huésped no encontrado.");
                return;
            }

            Console.WriteLine($"\n--- HISTORIAL DE RESERVAS DE {nombreHuesped[indiceHuesped]} ---");
            Console.WriteLine("No.\tHabitación\tEntrada\t\tNoches\t\tEstado");
            Console.WriteLine("------------------------------------------------------------------");

            bool encontradas = false;
            for (int i = 0; i < contadorReservas; i++)
            {
                if (reservaIDHuesped[i] == indiceHuesped)
                {
                    encontradas = true;
                    string estado = habitacionReservada[i] ? "ACTIVA" : "CANCELADA";

                    Console.WriteLine($"{i + 1}\t{numHabitacion[reservaIDHabitacion[i]]}\t\t{fechaEntrada[i]}\t{numNoches[i]}\t\t{estado}");
                }
            }

            if (!encontradas)
            {
                Console.WriteLine("No hay historial de reservas para este huésped.");
            }
        }

            static void CancelarReserva()
            {
            Console.Write("\nIngrese número de habitación de la reserva a cancelar: ");
            if (!int.TryParse(Console.ReadLine(), out int numHabitacionElegido))
            {
                Console.WriteLine("Número de habitación inválido.");
                return;
            }
            int indiceHabitacion = BuscarHabitacionPorNumero(numHabitacionElegido);

            Console.Write("Ingrese documento del huésped asociado a la reserva: ");
            string documentoHuespedElegido = Console.ReadLine();
            int indiceHuesped = BuscarHuespedPorID(documentoHuespedElegido);

            if (indiceHabitacion == -1 || indiceHuesped == -1)
            {
                Console.WriteLine("ERROR: Habitación o Huésped no encontrados.");
                return;
            }

            int indiceReserva = -1;
            // Buscar la reserva específica
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
                habitacionReservada[indiceReserva] = false; // Marcar como cancelada
                Console.WriteLine($"\n✅ Reserva de Hab. {numHabitacion[indiceHabitacion]} a nombre de {nombreHuesped[indiceHuesped]} ha sido CANCELADA.");
            }
            else
            {
                Console.WriteLine("ERROR: No se encontró una reserva ACTIVA para esa combinación de Habitación y Huésped.");
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
                    DateTime existenteEntrada = ConvertirAFecha(fechaEntrada[i]);
                    DateTime existenteSalida = existenteEntrada.AddDays(numNoches[i]);

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
            if(DateTime.TryParseExact(fecha, "día/mes/año", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaConvertida))
            {
                return fechaConvertida;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        //Realizado por Majo
        int BuscarHuespedPorID(string ID)
        {
            for (int i = 0; i < contadorHuespedes; i++)
            {
                if (huespedID[i] == ID)
                {
                    return i; // Índice encontrado
                }
            }
            return -1; // No encontrado
        }

        //Realizado por Laura
        static int BuscarHabitacionPorNumero(int numero)
        {
            for(int i= 0; i< contadorHabitaciones; i++)
            {
                if (numHabitacion[i] == numero)
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

