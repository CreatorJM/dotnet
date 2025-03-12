class Persona
{ 
    public string Nombre{get;set;}
    public int Edad{get;set;}
    public string Telefono{get;set;}
     public Persona(string nombre, int edad, string telefono)
    {
        Nombre = nombre;
        Edad = edad;
        Telefono = telefono;
    }
    public override string ToString()
    {
        return string.Format("{0},{1} años,tel: {2}",Nombre,Edad,Telefono);
    }

}
