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

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║                  Menú Principal                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.WriteLine("1. Ver todos los animales");
            Console.WriteLine("2. Buscar un animal");
            Console.WriteLine("3. Registrar nuevo animal");
            Console.WriteLine("4. Modificar un animal");
            Console.WriteLine("5. Eliminar un animal");
            Console.WriteLine("6. Cantidad de animales");
            Console.WriteLine("7. Salir");
            Console.WriteLine("═════════════════════════");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n Lista de todoss los animales\n");
                    MantenimientoZoo.MostrarInformacion(zoologico);
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                    break;

                case "2":
                    MantenimientoZoo.BuscarAnimal(zoologico);
                    break;

                case "3":
                    MantenimientoZoo.RegistrarAnimal(zoologico);
                    break;

                case "4":
                    MantenimientoZoo.ModificarAnimal(zoologico);
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                    break;

                case "5":
                    MantenimientoZoo.EliminarAnimal(zoologico);
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                    break;

                case "6":
                    MantenimientoZoo.CantidadAnimales(zoologico);
                    break;

                case "7":
                    continuar = false;
                    Console.WriteLine("¡Gracias por su visita!");
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. ");
                    Console.WriteLine("\nPresione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }



}

