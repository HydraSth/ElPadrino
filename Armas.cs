using Rango;
namespace Armas
{
    public class Arsenal{
            public string? nombre {get;set;}
            private bool condiciones {get;set;}
            public bool Condiciones{
                get {return condiciones;}
            }
            public void SetCondiciones(bool Valor){
                this.condiciones=Valor;
            }
            public void Recargar(){}
            public void Atacar(){}

    }
    
    public class Revolver:Arsenal
        {
            public Revolver(){
                this.nombre="Revolver";
                SetCondiciones(true);
            }    
            public int CantidadBalas{
                get {return balas;}
            }
            private int balas = 6;

            public void Atacar(Humano mafioso)
            {
                if (balas > 0){
                    System.Console.WriteLine($"Pow! {mafioso.nombre} fue atacado!");
                    balas--;
                    mafioso.vida-= HizoDaño(true);
                }else{
                    System.Console.WriteLine("Se atasco!");
                    SetCondiciones(false);
                    mafioso.vida-= HizoDaño(false);
                }
            }
            
            public int HizoDaño(bool Ataco){
                if(Ataco){
                    return 4;
                }else{
                    return 0;
                }
            }
            public new void Recargar()
            {
                System.Console.WriteLine($"{this.nombre} cargado!");
                balas = 6;
                SetCondiciones(true);
            }
        }
    
    public class Daga:Arsenal
        {
            public Daga(){
                this.nombre="Daga";
                SetCondiciones(true);
            }    

            public void Atacar(Humano mafioso)
            {
                mafioso.vida-= HizoDaño();
            }
            public int HizoDaño(){
                Random random = new Random();
                double randomNumber = random.Next(1, 3);
                return (int)Math.Round(randomNumber);
            }
        }
    
    public class CuerdaDePiano:Arsenal
        {
            public CuerdaDePiano(){
                this.nombre="Cuerda de piano";
                SetCondiciones(true);
            }
            public void Atacar(Humano mafioso)
            {
                EstaTensa();
                if (Condiciones){
                    System.Console.WriteLine("Sigh!wenfnw");
                    mafioso.vida-=HizoDaño(true);
                    SetCondiciones(false);
                }else{
                    System.Console.WriteLine("Eso es todo lo que tienes? Bastardo");
                    mafioso.vida-=HizoDaño(false);
                    SetCondiciones(false);
                }
            }
            public int HizoDaño(bool Ataco){
                return Ataco? 4: 1;
            }
            public void EstaTensa()
            {
                int numeroRandom = new Random().Next(0, 10);
                SetCondiciones(numeroRandom < 5);
            }
        }
}