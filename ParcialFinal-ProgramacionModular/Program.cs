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
        static void Menu()
        {

        }

        //Realizado por Laura
        #region Gestión de Habitaciones

        static void GestionHabitaciones()
        {
        }

        static void MostrarListaHabitaciones()
        {
        }

        static void RegistrarHabitacion()
        {
        }

        static void EditarHabitacion()
        {
        }

        static void VerDisponibilidadHabitacion()
        {
        }
        #endregion

        //Realizado por Majo
        #region Gestión de Huespedes

        static void GestionHuespedes()
        {
        }

        static void RegistrarHuesped()
        {
        }

        static void MostrarListaHuespedes()
        {
        }

        static void EditarHuesped()
        {
        }
        #endregion

        #region Gestión de Reservas
        //Realizado por Laura
        static void GestionReservas()
        {
        }

        //Realizado por Majo
        static void CrearReserva()
        {
        }

        static void MostrarListaReservas()
        {
        }

        //Realizado por Laura
        static void HistorialReservas()
        {
        }

        static void CancelarReserva()
        {
        }

        #endregion

        #region Módulos auxiliares para validar y buscar

        //Realizado por Laura
        static void ValidarDisponibilidadHabitacion()
        {
        }

        //Realizado por Majo
        static void BuscarHuespedPorID()
        {
        }

        //Realizado por Laura
        static void BuscarHabitacionPorNumero()
        {
        }

        #endregion
    }
}
