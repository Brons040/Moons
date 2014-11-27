using UnityEngine;
using System.Collections;

public static class PlanetStorage
{

    public static Planet IO = new Planet("IO", Planet.PlanetActual.IO, 40, 100, 90, 0, 75, 1000, 185);
    public static Planet Europa = new Planet("Europa", Planet.PlanetActual.Europa, 25, 100, 50, 100, 0, 2000, 95);
    public static Planet IPPO = new Planet("IPPO", Planet.PlanetActual.IPPO, 10, 25, 0, 0, 0, 4000, 0);
    public static Planet Default = new Planet("Default", Planet.PlanetActual.Default, 50, 10, 50, 25, 50, 6000, 520);
    public static Planet Ganymede = new Planet("Ganymede", Planet.PlanetActual.Ganymede, 15, 75, 45, 90, 50, 3000, 47);
    public static Planet Callisto = new Planet("Callistion", Planet.PlanetActual.Callisto, 0, 75, 35, 90, 60, 7000, 20);
    public static Planet Thebe = new Planet("Thebe", Planet.PlanetActual.Thebe, 20, 60, 40, 60, 60, 500, 555);
    public static Planet Sinope = new Planet("Sinope", Planet.PlanetActual.Sinope, 60, 40, 60, 25, 90, 5500, -166);
    public static Planet Ananke = new Planet("Ananke", Planet.PlanetActual.Ananke, 50, 40, 40, 60, 80, 1500, -175);	

}
