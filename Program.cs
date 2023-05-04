using Rango;
using Familia;
#pragma warning disable CS8600, CS8602, CS8603

ArbolFamiliar Corleone= new ArbolFamiliar("Corleone",new List<Humano>());
ArbolFamiliar Tattaglia= new ArbolFamiliar("Tattaglia",new List<Humano>());
ArbolFamiliar Haggen= new ArbolFamiliar("Haggen",new List<Humano>());

Don Vito = new Don("Vito", Corleone);


Don Marco = new Don("Marco",Haggen);
Subjefe Rafa = new Subjefe("Rafa",Haggen);
Subjefe Viko = new Subjefe("Viko",Haggen);
Soldado Carlo = new Soldado("Carlo",Haggen);

Don Clemenza = new Don("Clemenza",Tattaglia);
Soldado Lolo = new Soldado("Lolo",Tattaglia);
Subjefe Mauro = new Subjefe("Mauro",Tattaglia);
Soldado Tom = new Soldado("Tom",Tattaglia);

Subjefe Michael = new Subjefe("Michael",Corleone);
Subjefe Michael1 = new Subjefe("Michael",Corleone);
Subjefe Michael2 = new Subjefe("Michael",Corleone);
Subjefe Michael3 = new Subjefe("Michael",Corleone);
Subjefe Michael4 = new Subjefe("Michael",Corleone);
Subjefe Michael5 = new Subjefe("Michael",Corleone);

Lolo.VerArmas();
Michael.AtaqueSorpresa(Clemenza);
Tattaglia.Luto();

