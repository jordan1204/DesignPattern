using System;

namespace DependencyInjection {
    public interface IElectricalPlug {//插頭介面(被依賴類別)
        void Connect ();//連接插座以取得電源
    }
}