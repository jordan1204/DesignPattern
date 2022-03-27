using System;

namespace DependencyInjection {
    public class SecureHairDryerPlug : IElectricalPlug {
        public IElectricalPlug plug { get; set; }
        public string identity { get; set; }

        //使用裝飾者模式做依賴注入
        public SecureHairDryerPlug (IElectricalPlug plug, string identity) {
            this.plug = plug;
            this.identity = identity;
        }
        public void Connect () {
            if (identity == "Mom") {
                Console.WriteLine ("HairDryerPlug connected!\n");

            }

        }
    }
}