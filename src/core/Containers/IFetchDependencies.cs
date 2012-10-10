using System;

namespace core.Containers
{
    public interface IFetchDependencies
    {
        Dependency A<Dependency>();
        object A(Type dependency);
    }
}