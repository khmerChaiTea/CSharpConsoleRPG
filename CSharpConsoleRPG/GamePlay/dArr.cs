using System;
using System.Collections.Generic;

public class dArr<T>
{
    private int initialCap;
    private int cap;
    private int nrOfEl;
    private T[] arr;

    // Constructor
    public dArr(int size = 5)
    {
        this.initialCap = size;
        this.cap = size;
        this.nrOfEl = 0;

        this.arr = new T[this.cap];
        this.Initialize(0);
    }

    // Copy Constructor
    public dArr(dArr<T> obj)
    {
        this.initialCap = obj.initialCap;
        this.cap = obj.cap;
        this.nrOfEl = obj.nrOfEl;

        this.arr = new T[this.cap];
        Array.Copy(obj.arr, this.arr, obj.nrOfEl);
    }

    // Indexer in C#
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.nrOfEl)
                throw new IndexOutOfRangeException("OUT OF BOUNDS INDEXING OPERATOR.");

            return this.arr[index];
        }
    }

    // Assignment operator equivalent
    public void Assign(dArr<T> obj)
    {
        this.initialCap = obj.initialCap;
        this.cap = obj.cap;
        this.nrOfEl = obj.nrOfEl;

        this.arr = new T[this.cap];
        Array.Copy(obj.arr, this.arr, obj.nrOfEl);
    }

    // Expand the array
    private void Expand()
    {
        this.cap *= 2;
        T[] tempArr = new T[this.cap];
        Array.Copy(this.arr, tempArr, this.nrOfEl);
        this.arr = tempArr;
    }

    // Initialize the array
    private void Initialize(int from)
    {
        for (int i = from; i < this.cap; i++)
        {
            this.arr[i] = default(T);
        }
    }

    // Get max capacity
    public int MaxCap()
    {
        return this.cap;
    }

    // Get current size
    public int Size()
    {
        return this.nrOfEl;
    }

    // Add an element to the array
    public void Push(T element)
    {
        if (this.nrOfEl >= this.cap)
            this.Expand();

        this.arr[this.nrOfEl++] = element;
    }

    // Remove an element by index
    public void Remove(int index, bool ordered = false)
    {
        if (index < 0 || index >= this.nrOfEl)
            throw new IndexOutOfRangeException("OUT OF BOUNDS REMOVE.");

        if (ordered)
        {
            for (int i = index; i < this.nrOfEl - 1; i++)
            {
                this.arr[i] = this.arr[i + 1];
            }
        }
        else
        {
            this.arr[index] = this.arr[this.nrOfEl - 1];
        }

        this.nrOfEl--;
    }
}