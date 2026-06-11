using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ================================
        //   REPOSITORIOS JSON
        // ================================
        var repoVisitantes = new JsonRepository<Visitante>("visitantes.json");
        var repoAnimales = new JsonRepository<Animal>("animales.json");

        // ================================
        //   CARGAR ANIMALES SOLO 1 VEZ
        // ================================
        if (repoAnimales.ObtenerTodos().Count == 0)
        {
            repoAnimales.Agregar(new Ave("Águila Real", 5, "Ave rapaz", true, "sonido de ave", true));
            repoAnimales.Agregar(new Ave("Pingüino Emperador", 8, "Ave marina", false, "sonido de ave", false));

            repoAnimales.Agregar(new Mamifero("León", 7, "Felino", "Sabana", "Gruñido", "Carnívoro"));
            repoAnimales.Agregar(new Mamifero("Delfín", 12, "Mamífero marino", "Mar", "Sonido de delfín", "Pescado"));

            repoAnimales.Agregar(new Anfibio("Rana Roja", 2, "Rana venenosa", true, "Selva tropical", "Croac croac", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Sapo Común", 4, "Sapo", false, "Bosques y jardines", "Croooac", "Lombrices"));
            repoAnimales.Agregar(new Anfibio("Ajolote", 3, "Salamandra acuática", false, "Lagos y canales", "Sonido suave", "Camarones"));
            repoAnimales.Agregar(new Anfibio("Salamandra Tigre", 5, "Salamandra", false, "Bosques húmedos", "Chirrido", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Rana Toro", 4, "Rana", false, "Pantanos", "BRROOOOM", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Rana Arborícola", 2, "Rana", false, "Árboles húmedos", "Cri cri", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Tritón Alpino", 3, "Tritón", false, "Lagunas de montaña", "Chii", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Rana Dardo Azul", 1, "Rana venenosa", true, "Selvas tropicales", "Croac", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Salamandra Gigante", 10, "Salamandra", false, "Ríos de montaña", "Gruñido suave", "Insectos"));
            repoAnimales.Agregar(new Anfibio("Rana de Cristal", 2, "Rana", false, "Bosques tropicales", "Croac transparente", "Insectos"));
        }

        // ================================
        //   OBJETOS INICIALES
        // ================================
        // ================================
        //   CARGAR VISITANTES SOLO 1 VEZ
        // ================================
        if (repoVisitantes.ObtenerTodos().Count == 0)
        {
            repoVisitantes.Agregar(new Visitante("Heidy", 17));
            repoVisitantes.Agregar(new Visitante("Carlos", 22));
            repoVisitantes.Agregar(new Visitante("María", 19));
            repoVisitantes.Agregar(new Visitante("José", 25));
            repoVisitantes.Agregar(new Visitante("Ana", 18));
            repoVisitantes.Agregar(new Visitante("Luis", 30));
            repoVisitantes.Agregar(new Visitante("Fernanda", 21));
            repoVisitantes.Agregar(new Visitante("Miguel", 28));
            repoVisitantes.Agregar(new Visitante("Sofía", 16));
            repoVisitantes.Agregar(new Visitante("Daniel", 20));
            repoVisitantes.Agregar(new Visitante("Valeria", 23));
            repoVisitantes.Agregar(new Visitante("Jorge", 27));
            repoVisitantes.Agregar(new Visitante("Lucía", 24));
            repoVisitantes.Agregar(new Visitante("Ricardo", 29));
            repoVisitantes.Agregar(new Visitante("Paola", 26));
        }

        Promocion promocion = new Promocion("Entrada Estudiantil", 25);

        Console.WriteLine("=================================");
        Console.WriteLine("   ZOOLÓGICO VIRTUAL NICARAGUA");
        Console.WriteLine("=================================\n");

        Console.WriteLine($"Bienvenidos\n");
        promocion.MostrarInformacion();

        Console.WriteLine("\n=================================");
        Console.WriteLine("      INICIO DEL RECORRIDO");
        Console.WriteLine("=================================\n");

        // GESTORES
        var gestorVisitantes = new GestorDeVisitante(repoVisitantes);
        var mantenimiento = new MantenimientoZoo(repoAnimales);

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
                    MenuVisitarZoo(mantenimiento);
                    break;

                case "2":
                    MenuGestionZoo(mantenimiento, gestorVisitantes);
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

    // ============================================================
    // MENÚS
    // ============================================================

    public static void MenuVisitarZoo(MantenimientoZoo mantenimiento)
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
                    mantenimiento.MostrarInformacion();
                    Console.ReadLine();
                    break;

                case "2":
                    mantenimiento.BuscarAnimal();
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
        MantenimientoZoo mantenimiento,
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
                    MenuVisitantes(gestorVisitantes);
                    break;

                case "2":
                    MenuAnimales(mantenimiento);
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

    public static void MenuVisitantes(GestorDeVisitante gestor)
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
                case "1": gestor.RegistrarVisitante(); break;
                case "2": gestor.MostrarVisitantes(); break;
                case "3": gestor.BuscarVisitante(); break;
                case "4": gestor.ModificarVisitante(); break;
                case "5": gestor.EliminarVisitante(); break;
                case "6": gestor.CantidadVisitantes(); break;
                case "0": volver = true; continue;
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }

    public static void MenuAnimales(MantenimientoZoo mantenimiento)
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
                case "1": mantenimiento.MostrarInformacion(); break;
                case "2": mantenimiento.BuscarAnimal(); break;
                case "3": mantenimiento.RegistrarAnimal(); break;
                case "4": mantenimiento.ModificarAnimal(); break;
                case "5": mantenimiento.EliminarAnimal(); break;
                case "6": mantenimiento.CantidadAnimales(); break;
                case "0": volver = true; continue;
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
