using System;

//依賴:兩個物件是否認識彼此//注入:兩個物件認識的途徑
namespace DependencyInjection {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("使用吹風機插頭");
            /*********注入不同的 IElectricalPlug 類別實作就會有不同的 Connect() 方法實作細節，在不需要動到 Socket 程式碼的情況下，即可抽換實際連結的插頭物件。*********/
            IElectricalPlug hairDryerPlug = new HairDryerPlug ();
            var socket = new Socket (hairDryerPlug);
            socket.SendPower ();

            Console.WriteLine ("使用經身分驗證的安全吹風機插頭");
            IElectricalPlug secureHairDryerPlug = new SecureHairDryerPlug (hairDryerPlug, "Mom");
            var socketDecorated = new Socket(secureHairDryerPlug);
            socketDecorated.SendPower();
        }
    }
}