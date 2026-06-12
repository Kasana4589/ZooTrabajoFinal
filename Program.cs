using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Visitante visitante = new Visitante("Heidy", 17);

        Promocion promocion =
            new Promocion("Entrada Estudiantil", 25);

        Console.WriteLine("=================================");
        Console.WriteLine("   ZOOLÓGICO VIRTUAL NICARAGUA");
        Console.WriteLine("=================================\n");

        Console.WriteLine($"Bienvenido/a: {visitante.Nombre}");
        Console.WriteLine();

        promocion.MostrarInformacion();

        Console.WriteLine("\n=================================");
        Console.WriteLine("      INICIO DEL RECORRIDO");
        Console.WriteLine("=================================\n");

        List<Animal> zoologico = new List<Animal>()
        {
            // AVES
            new Ave("Águila Real", 5, "Ave rapaz", true,"sonido de ave", true),
            new Ave("Pingüino Emperador", 8, "Ave marina", false, "sonido de ave", false),

            // MAMÍFEROS
            new Mamifero("León", 7, "Felino", "Sabana", "Gruñido", "Carnívoro"),
            new Mamifero("Delfín", 12, "Mamífero marino", "Mar","Sonido de delphin", "Pescado"),

            // ANFIBIOS
            
new Anfibio(  "Rana Roja",2, "Rana venenosa", true,"Selva tropical","Croac croac", "Insectos"),

new Anfibio("Sapo Común",4,"Sapo",false,"Bosques y jardines","Croooac", "Lombrices"),

new Anfibio(   "Ajolote",3,"Salamandra acuática",false,"Lagos y canales","Sonido suave", "Camarones"),

new Anfibio("Salamandra Tigre",5,"Salamandra", false, "Bosques húmedos", "Chirrido", "Insectos"),

new Anfibio("Rana Toro",4,"Rana",false,"Pantanos","BRROOOOM", "Insectos"),

new Anfibio("Rana Arborícola",2,"Rana",false,"Árboles de zonas húmedas","Cri cri", "Insectos"),

new Anfibio( "Tritón Alpino", 3, "Tritón", false, "Lagunas de montaña", "Chii", "Insectos"),

new Anfibio("Rana Dardo Azul", 1,"Rana venenosa",true,"Selvas tropicales","Croac", "Insectos"),

new Anfibio("Salamandra Gigante",10,"Salamandra",false,"Ríos de montaña","Gruñido suave ", "Insectos"),

new Anfibio( "Rana de Cristal", 2, "Rana", false, "Bosques tropicales", "Croac transparente", "Insectos")
        };
        List<Visitante> visitantes = new List<Visitante>();

        GestorDeVisitante gestorVisitantes =
            new GestorDeVisitante();
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║                  Menú Principal                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.WriteLine("1. Visitar el zoológico");
            Console.WriteLine("2. Gestionar zoológico");
            Console.WriteLine("0. Salir");

            Console.Write("\nSeleccione una opción: ");

            string opcionPrincipal = Console.ReadLine() ?? "";

            switch (opcionPrincipal)
            {
                case "1":
                    MenuVisitarZoo(zoologico);
                    break;

                case "2":
                    MenuGestionZoo(zoologico, visitantes, gestorVisitantes);
                    break;

                case "0":
                    continuar = false;
                    Console.WriteLine("Gracias por visitarnos.");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadLine();
                    break;
            }
        }
    }
    public static void MenuVisitarZoo(List<Animal> zoologico)
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();

            Console.WriteLine("===== VISITAR ZOOLÓGICO =====");

            Console.WriteLine("1. Ver todos los animales");
            Console.WriteLine("2. Buscar animal");
            Console.WriteLine("0. Volver");

            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    MantenimientoZoo.MostrarInformacion(zoologico);
                    Console.ReadLine();
                    break;

                case "2":
                    MantenimientoZoo.BuscarAnimal(zoologico);
                    break;

                case "0":
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void MenuGestionZoo(
    List<Animal> zoologico,
    List<Visitante> visitantes,
    GestorDeVisitante gestorVisitantes)
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();

            Console.WriteLine("===== GESTIONAR ZOOLÓGICO =====");

            Console.WriteLine("1. Gestión de visitantes");
            Console.WriteLine("2. Gestión de animales");
            Console.WriteLine("0. Volver");

            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    MenuVisitantes(visitantes, gestorVisitantes);
                    break;

                case "2":
                    MenuAnimales(zoologico);
                    break;

                case "0":
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadLine();
                    break;
            }
        }
    }
    public static void MenuVisitantes(
    List<Visitante> visitantes,
    GestorDeVisitante gestor)
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();

            Console.WriteLine("===== GESTIÓN DE VISITANTES =====");

            Console.WriteLine("1. Registrar visitante");
            Console.WriteLine("2. Mostrar visitantes");
            Console.WriteLine("3. Buscar visitante");
            Console.WriteLine("4. Modificar visitante");
            Console.WriteLine("5. Eliminar visitante");
            Console.WriteLine("6. Cantidad de visitantes");
            Console.WriteLine("0. Volver");

            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    gestor.RegistrarVisitante(visitantes);
                    break;

                case "2":
                    gestor.MostrarVisitantes(visitantes);
                    break;

                case "3":
                    gestor.BuscarVisitante(visitantes);
                    break;

                case "4":
                    gestor.ModificarVisitante(visitantes);
                    break;

                case "5":
                    gestor.EliminarVisitante(visitantes);
                    break;

                case "6":
                    gestor.CantidadVisitantes(visitantes);
                    break;

                case "0":
                    volver = true;
                    continue;
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }
    public static void MenuAnimales(List<Animal> zoologico)
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();

            Console.WriteLine("===== GESTIÓN DE ANIMALES =====");

            Console.WriteLine("1. Mostrar animales");
            Console.WriteLine("2. Buscar animal");
            Console.WriteLine("3. Registrar animal");
            Console.WriteLine("4. Modificar animal");
            Console.WriteLine("5. Eliminar animal");
            Console.WriteLine("6. Cantidad de animales");
            Console.WriteLine("0. Volver");

            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    MantenimientoZoo.MostrarInformacion(zoologico);
                    break;

                case "2":
                    MantenimientoZoo.BuscarAnimal(zoologico);
                    break;

                case "3":
                    MantenimientoZoo.RegistrarAnimal(zoologico);
                    break;

                case "4":
                    MantenimientoZoo.ModificarAnimal(zoologico);
                    break;

                case "5":
                    MantenimientoZoo.EliminarAnimal(zoologico);
                    break;

                case "6":
                    MantenimientoZoo.CantidadAnimales(zoologico);
                    break;

                case "0":
                    volver = true;
                    continue;
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }
    
}