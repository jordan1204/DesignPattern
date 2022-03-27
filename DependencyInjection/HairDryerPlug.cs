using System;

namespace DependencyInjection {
   public class HairDryerPlug:IElectricalPlug{
       public void Connect(){
          Console.WriteLine("HairDryerPlug connected!\n");
       }
   }
}