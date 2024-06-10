using System;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}
public class IntegerIterator : IIterator<int>
{
    private int[] _collection;
    private int _currentIndex = -1;

    public IntegerIterator(int[] collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _currentIndex + 1 < _collection.Length;
    }

    public int Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more elements in the collection.");
        }
        _currentIndex++;
        return _collection[_currentIndex];
    }
}
public interface IAggregate<T>
{
    IIterator<T> GetIterator();
}


public class IntegerCollection : IAggregate<int>
{
    private int[] _collection;

    public IntegerCollection(int[] collection)
    {
        _collection = collection;
    }

    public IIterator<int> GetIterator()
    {
        return new IntegerIterator(_collection);
    }
}
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        IntegerCollection collection = new IntegerCollection(numbers);
        IIterator<int> iterator = collection.GetIterator();

        while (iterator.HasNext())
        {
            int number = iterator.Next();
            Console.WriteLine(number);
        }
    }
}
