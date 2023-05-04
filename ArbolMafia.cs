using Rango;
#pragma warning disable CS8600, CS8602, CS8603

namespace Familia
{
    public class ArbolFamiliar{
        public string? nombre {get;set;}
        public Humano? Don ;
        public List<Humano>? Consigliere {get;set;}
        public ArbolFamiliar(string FamiliaNombre, List<Humano>ListaConsigliere){
            this.nombre=FamiliaNombre;
            this.Consigliere = new List<Humano>();
            this.Consigliere.AddRange(ListaConsigliere);
        }

        public void VerFamilia(){
            System.Console.WriteLine("\n");
            if(Don!=null){
                System.Console.WriteLine($"{Don.nombre} es el don de {this.nombre}");
            }
            if(Consigliere!=null){
                foreach (var humano in Consigliere){
                    System.Console.WriteLine($"{humano.nombre} tiene el rango {humano.rango} pertenece a {this.nombre}, cuenta con {humano.PuntosIntimidacion} puntos de intimidacion");
                }
            }
        }
        public void Luto(){
            if(this.Don.vida<=0){
                Humano NuevoDon= ElMasPeligroso();
                this.Don= NuevoDon;
                foreach(var Persona in Consigliere){
                    switch(Persona.rango){
                        case "Subjefe":
                            Rango.Subjefe SubjefeOBJ = (Subjefe)Persona;
                            if(SubjefeOBJ.ArmasEnCondiciones()<=2){
                                SubjefeOBJ.rango="Soldado";
                            }
                            SubjefeOBJ.Reformar();
                        break;
                        case "Soldado":
                            Rango.Soldado SoldadoOBJ = (Soldado)Persona;
                            if(SoldadoOBJ.ArmasEnCondiciones()>2){
                                SoldadoOBJ.rango="Subjefe";
                            }
                            SoldadoOBJ.Reformar();
                        break;
                    }
                }
                this.Don.Reformar();
            }
        }
        public Humano ElMasPeligroso(){
            int PuntajeMasAlto=0;
            string NombreDePuntaje="";
            Humano PersonaOBJ=new Humano();
            foreach (var humano in Consigliere){
                humano.ElMasPeligroso();
                if(humano.PuntosIntimidacion>PuntajeMasAlto){
                    PuntajeMasAlto=humano.PuntosIntimidacion;
                    NombreDePuntaje=humano.nombre;
                    PersonaOBJ=humano;
                }
            }
            if(Don!=null){
                if(Don.PuntosIntimidacion>PuntajeMasAlto && Don.vida>0){
                    Don.ElMasPeligroso();
                    PuntajeMasAlto=Don.PuntosIntimidacion;
                    NombreDePuntaje=Don.nombre;
                    PersonaOBJ=Don;
                }
            }
            PersonaOBJ.rango="Don";
            this.Consigliere.Remove(PersonaOBJ);
            return PersonaOBJ;
        }
    }

}