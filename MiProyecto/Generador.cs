using System;
using System.IO;
using System.Xml;

class Generador
{
    public static void GenerarXML()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alumnos.xml");

        using (XmlWriter writer = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("base");

            Random rnd = new Random();
            for (int i = 1; i <= 30; i++)
            {
                int p1 = rnd.Next(50, 100);
                int p2 = rnd.Next(50, 100);
                int p3 = rnd.Next(50, 100);
                int ext = rnd.Next(50, 100);
                double promedio = (p1 + p2 + p3) / 3.0;
                if (promedio < 60) promedio = ext;

                writer.WriteStartElement("alumno");
                writer.WriteElementString("id", i.ToString());
                writer.WriteElementString("apellido", "Apellido" + i);
                writer.WriteElementString("nombre", "Nombre" + i);
                writer.WriteElementString("parcial1", p1.ToString());
                writer.WriteElementString("parcial2", p2.ToString());
                writer.WriteElementString("parcial3", p3.ToString());
                writer.WriteElementString("ext", ext.ToString());
                writer.WriteElementString("promedio", promedio.ToString("0.00"));
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        Console.WriteLine($"Archivo XML creado en: {path}");
    }
}