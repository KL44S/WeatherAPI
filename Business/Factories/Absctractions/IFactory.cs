using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Factories.Absctractions
{
    public interface IFactory<T>
    {
        T BuildAndGetInstance();
    }
}
