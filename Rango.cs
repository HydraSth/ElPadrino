using Familia;
using Armas;
#pragma warning disable CS8600, CS8602, CS8603

namespace Rango
{
    public class Humano{
        public ArbolFamiliar? familia {get;set;}
        public string? nombre {get;set;}
        public string? rango {get;set;}
        public List<Arsenal>? armas {get;set;}
        public int intimidacion = 0;
        public int vida=4;
        public void ElMasPeligroso(){
            int NivelDePeligrosidad=0;
            if(vida>0){
                //Retorna el nivel de peligrosidad segun armas y rango
                NivelDePeligrosidad=Peligrosidad();
            }else{
                //Si esta muerto no es peligroso
                NivelDePeligrosidad=0;
            }
            ActualizarIntimidacion(NivelDePeligrosidad);
            
        }
        public int PuntosIntimidacion{
            get {return intimidacion;}
        }
        public int Peligrosidad(){
            int SumaPeligro=0;
            foreach (var arma in armas){
                switch (arma.nombre){
                    case "Revolver":
                        Revolver revolver = (Revolver)arma;
                        if(!revolver.Condiciones){
                            SumaPeligro+=1;
                        }else{
                            SumaPeligro+=(revolver.CantidadBalas*2);
                        }
                    break;
                    case "Daga":
                        double numeroRandom = new Random().Next(0, 8);
                        SumaPeligro+=(int)Math.Floor(numeroRandom);
                    break;
                    case "Cuerda de piano":
                        CuerdaDePiano cuerda = (CuerdaDePiano)arma;
                        if(cuerda.Condiciones){
                            SumaPeligro+=5;
                        }else{
                            SumaPeligro+=1;
                        }
                    break;
                }
            }
            switch(rango){
                case "Don":
                    SumaPeligro+=20;
                break;
                case "Subjefe":
                    SumaPeligro=SumaPeligro*2;
                break;
            }
            return SumaPeligro;
        }
        public void DurmiendoConLosPeces(){
            if(vida > 0){
                System.Console.WriteLine($"{this.nombre} sigue con vida");
            }else{
                System.Console.WriteLine($"{this.nombre} esta muerto!");
            }
        }
        public void VerArmas(){
            if(armas.Count == 0){
                System.Console.WriteLine($"{this.nombre} no tiene armas.");
            }else{
                System.Console.Write($"{this.nombre} cuenta con ");        
                foreach (var arma in armas)
                {
                    System.Console.Write($"{arma.nombre} ");        
                }
            }
            System.Console.WriteLine("");
        }
        public void ActualizarIntimidacion(int puntos){
            intimidacion+=puntos;
        }
        public void AtaqueSorpresa(Humano mafioso){
            if(armas.Count == 0){
                System.Console.WriteLine($"{this.nombre} no tiene armas.");
            }else if(mafioso.vida>0){
                foreach (var arma in armas){
                    switch (arma.nombre){
                        case "Revolver":
                            Revolver revolver = (Revolver)arma;
                            if(revolver.Condiciones){
                                revolver.Atacar(mafioso);
                                return;
                            }
                        break;
                        case "Daga":
                            Daga daga = (Daga)arma;
                            if(daga.Condiciones){
                                daga.Atacar(mafioso);
                                return;
                            }
                        break;
                        case "Cuerda de piano":
                            CuerdaDePiano cuerda = (CuerdaDePiano)arma;
                            if(cuerda.Condiciones){
                                cuerda.Atacar(mafioso);
                                return;
                            }
                        break;
                    }
                }
            }else{
                System.Console.WriteLine($"{mafioso.nombre} ya esta muerto!");
            }
        }
        public void Reformar(){
            foreach (var arma in armas)
            {
                arma.Recargar();
            }
            armas.Add(new Revolver());
        }
    }
    public class Don:Humano{
        public Don(string Nombre,ArbolFamiliar Familia){
            this.nombre=Nombre;
            Familia.Don=this;
            this.rango="Don";
            this.armas=new List<Arsenal>();
        }
        public void DesarmaVictima(Humano persona){
            persona.armas.Clear();
        }
        
    }
    public class Subjefe:Humano{
        public Subjefe(string Nombre,ArbolFamiliar Familia){
            this.nombre=Nombre;
            Familia.Consigliere.Add(this);
            this.rango="Subjefe";
            this.armas=new List<Arsenal>(){
                new Revolver(),
                new CuerdaDePiano(),
                new Daga()
            };
        }
        public int ArmasEnCondiciones(){
            int CantidadDeArmasEnCondiciones=0;
            foreach (var arma in armas)
            {
                if(arma.Condiciones){
                    CantidadDeArmasEnCondiciones+=1;
                }
            }
            return CantidadDeArmasEnCondiciones;
        }
    }
    public class Soldado:Humano{
        public Soldado(string Nombre,ArbolFamiliar Familia){
            this.nombre=Nombre;
            Familia.Consigliere.Add(this);
            this.rango="Soldado";
            this.armas=new List<Arsenal>(){
                new Revolver(),
            };
        }
        public int ArmasEnCondiciones(){
            int CantidadDeArmasEnCondiciones=0;
            foreach (var arma in armas)
            {
                if(arma.Condiciones){
                    CantidadDeArmasEnCondiciones+=1;
                }
            }
            return CantidadDeArmasEnCondiciones;
        }
    }    

}
