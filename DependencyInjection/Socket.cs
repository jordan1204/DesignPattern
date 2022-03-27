using System;

namespace DependencyInjection {
    public class Socket {//插座(依賴的類別)
        private readonly IElectricalPlug _plug;

        public Socket (IElectricalPlug plug) {//建構子注入
            if (plug == null) throw new ArgumentNullException ("plug 為空值");
            this._plug = plug;
        }

        public void SendPower () {/**可讓依賴的類別只需知道要呼叫哪個function而不需要在意這函式的實作過程**/
            this._plug.Connect ();
        }/***Dependent classes can be changed out without the depending class knowing or caring.**/
    }
}