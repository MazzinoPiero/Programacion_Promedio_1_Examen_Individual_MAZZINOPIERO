using System;
using System.Collections.Generic;

public class Game
{
    private List<Planta> plantas = new List<Planta>();
    private List<Zombie> zombies = new List<Zombie>();
    private Random random = new Random();
    private int turn = 0;
    private bool canCreatePlanta = true;
    private bool canCreateZombie = true;

public void Start()
{
    Console.WriteLine("Bienvenido al Mini Plantas vs Zombies");

    while (plantas.Count == 0)
    {
        Console.WriteLine("Debes crear al menos una planta para iniciar el juego.");
        CreatePlanta();
    }

    while (plantas.Count > 0)
    {
        turn++;
        Console.WriteLine($"\n--- Turno {turn} ---");

        CreatePlanta(); 

        if (turn % 3 == 0)
        {
            CreateZombie();
        }

        if (zombies.Count > 0)
        {
            Battle();
        }

        DisplayStatus();
    }

    EndGame();
}

private void CreatePlanta()
{
       if (plantas.Count >= 3)
    {
        Console.WriteLine("No puedes crear más plantas. El máximo es 3.");
        return;
    }
    
    Console.WriteLine("Crea una nueva planta (1-3 para crear, 0 para saltar):");
    Console.WriteLine("1. Planta Débil (40 salud, 5 ataque)");
    Console.WriteLine("2. Planta Normal (50 salud, 10 ataque)");
    Console.WriteLine("3. Planta Fuerte (80 salud, 15 ataque)");

    int choice;
    while (true)
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Entrada inválida. Por favor, intenta de nuevo.");
            continue;
        }

        if (int.TryParse(input, out choice))
        {
            if (choice >= 0 && choice <= 3)
            {
                break;
            }
        }

        Console.WriteLine("Opción inválida. Por favor, elige un número entre 0 y 3.");
    }

    switch (choice)
    {
        case 1:
            plantas.Add(new Planta(40, 5));
            break;
        case 2:
            plantas.Add(new Planta(50, 10));
            break;
        case 3:
            plantas.Add(new Planta(80, 15));
            break;
        default:
            return;
    }

    Console.WriteLine("Planta creada con éxito.");
}

  private void CreateZombie()
{
    if (plantas.Count > 0)
    {
        if (random.Next(2) == 0)
        {
            zombies.Add(new NormalZombie());
            Console.WriteLine("Un zombie normal ha aparecido");
        }
        else
        {
            zombies.Add(new ToughZombie());
            Console.WriteLine("Un zombie resistente ha aparecido");
        }
    }
}


    private void Battle()
{
    foreach (var planta in plantas.ToList())
    {
        if (zombies.Count > 0)
        {
            planta.Attack(zombies[0]);
            if (!zombies[0].IsAlive())
            {
                Console.WriteLine("Un zombie ha sido derrotado");
                zombies.RemoveAt(0);
            }
        }
    }

    if (plantas.Count > 0)
    {
        foreach (var zombie in zombies.ToList())
        {
            if (plantas.Count > 0)
            {
                zombie.Attack(plantas[0]);
                if (!plantas[0].IsAlive())
                {
                    Console.WriteLine("Una planta ha sido derrotada");
                    plantas.RemoveAt(0);
                }
            }
        }
    }
}

    private void DisplayStatus()
    {
        Console.WriteLine($"Plantas restantes: {plantas.Count}");
        Console.WriteLine($"Zombies restantes: {zombies.Count}");
    }

  private void EndGame()
  { 
    if (plantas.Count > 0 && zombies.Count == 0)
     {
        Console.WriteLine("Las plantas han ganado");
     }
    else if (zombies.Count > 0 && plantas.Count == 0)
     {
        Console.WriteLine("Los zombies han ganado");
     } 
  }

}