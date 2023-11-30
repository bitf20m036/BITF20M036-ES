//Iterator for a Dictionary
using System;
using System.Collections;
using System.Collections.Generic;
interface IIterator<TKey, TValue>
{
    bool HasNext();
    KeyValuePair<TKey, TValue> Next();
}

class DictionaryIterator<TKey, TValue> : IIterator<TKey, TValue>
{
    private IEnumerator<KeyValuePair<TKey, TValue>> enumerator;

    public DictionaryIterator(Dictionary<TKey, TValue> dictionary)
    {
        enumerator = dictionary.GetEnumerator();
    }

    public bool HasNext()
    {
        return enumerator.MoveNext();
    }

    public KeyValuePair<TKey, TValue> Next()
    {
        return enumerator.Current;
    }
}
interface IAggregate<TKey, TValue>
{
    IIterator<TKey, TValue> CreateIterator();
}
class DictionaryAggregate<TKey, TValue> : IAggregate<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> dictionary;

    public DictionaryAggregate()
    {
        dictionary = new Dictionary<TKey, TValue>();
    }

    public void Add(TKey key, TValue value)
    {
        dictionary.Add(key, value);
    }

    public IIterator<TKey, TValue> CreateIterator()
    {
        return new DictionaryIterator<TKey, TValue>(dictionary);
    }
}
class DictionaryIteratorClient
{
    static void Main()
    {
        var dictionaryAggregate = new DictionaryAggregate<string, int>();
        dictionaryAggregate.Add("One", 1);
        dictionaryAggregate.Add("Two", 2);
        dictionaryAggregate.Add("Three", 3);

        var iterator = dictionaryAggregate.CreateIterator();

        while (iterator.HasNext())
        {
            var pair = iterator.Next();
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
