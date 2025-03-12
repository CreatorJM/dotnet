using System;
using System.Collections;
using System.Text.RegularExpressions;
namespace HelloWorld;


class Person
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    private static Regex phoneRegex = new Regex(@"^(\d{10}|\d{2} \d{4} \d{4})$");
    private static Regex emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

    public Person(string nombre, string telefono, string email)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
    }

    public bool ValidarTelefono() { return phoneRegex.IsMatch(Telefono); }
    public bool ValidarEmail() { return emailRegex.IsMatch(Email); }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Teléfono: {Telefono} {(ValidarTelefono() ? "Valido" : "Invalido")}");
        Console.WriteLine($"Email: {Email} {(ValidarEmail() ? " Valido" : " Invalido")}");
    }
}

class Agend
{
    static ArrayList personas = new ArrayList();

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- Menu CRUD ---");
            Console.WriteLine("1. Agregar persona");
            Console.WriteLine("2. Mostrar personas");
            Console.WriteLine("3. Editar persona");
            Console.WriteLine("4. Eliminar persona");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarPersona();
                        break;
                    case 2:
                        MostrarPersonas();
                        break;
                    case 3:
                        EditarPersona();
                        break;
                    case 4:
                        EliminarPersona();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción invalida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no valida. Intente de nuevo.");
            }
        } while (opcion != 5);
    }

    static void AgregarPersona()
    {
        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine();

        string telefono;
        do
        {
            Console.Write("Ingrese telefono (formato: 6060994978 o 56 6568 5659): ");
            telefono = Console.ReadLine();
        } while (!new Person("", telefono, "").ValidarTelefono());

        string email;
        do
        {
            Console.Write("Ingrese email valido: ");
            email = Console.ReadLine();
        } while (!new Person("", "", email).ValidarEmail());

        personas.Add(new Person(nombre, telefono, email));
        Console.WriteLine("Persona agregada exitosamente.");
    }

    static void MostrarPersonas()
    {
        if (personas.Count == 0)
        {
            Console.WriteLine("No hay personas registradas.");
            return;
        }

        for (int i = 0; i < personas.Count; i++)
        {
            Console.WriteLine($"\nRegistro {i + 1}:");
            ((Person)personas[i]).MostrarInformacion();
        }
    }

    static void EditarPersona()
    {
        MostrarPersonas();
        Console.Write("Ingrese el numero de registro a editar: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= personas.Count)
        {
            Person person = (Person)personas[index - 1];
            Console.Write("Nuevo nombre: ");
            person.Nombre = Console.ReadLine();

            string telefono;
            do
            {
                Console.Write("Nuevo telefono (formato: 10 digitos): ");
                telefono = Console.ReadLine();
            } while (!new Person("", telefono, "").ValidarTelefono());
            person.Telefono = telefono;

            string email;
            do
            {
                Console.Write("Nuevo email valido: ");
                email = Console.ReadLine();
            } while (!new Person("", "", email).ValidarEmail());
            person.Email = email;

            Console.WriteLine("Registro actualizado.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    static void EliminarPersona()
    {
        MostrarPersonas();
        Console.Write("Ingrese el numero de registro a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= personas.Count)
        {
            personas.RemoveAt(index - 1);
            Console.WriteLine("Registro eliminado.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }