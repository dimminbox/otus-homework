namespace Patterns.Abstractions;

public interface IMyCloneable<out T> where T: class
{
    T MyClone();
}