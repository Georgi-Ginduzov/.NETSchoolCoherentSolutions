using System;
using System.Collections;
using System.Collections.Generic;

public class SparseMatrix : IEnumerable<long>
{
    private readonly Dictionary<(int, int), long> _elements;
    private readonly int _rows;
    private readonly int _columns;

    public SparseMatrix(int rowCount, int columnCount)
    {
        if (rowCount <= 0 || columnCount <= 0)
        {
            throw new ArgumentException("Row and column size must be greater than zero.");
        }

        _rows = rowCount;
        _columns = columnCount;
        _elements = new Dictionary<(int, int), long>();
    }

    public long this[int i, int j]
    {
        get
        {
            if (i >= _rows || j >= _columns)
            {
                throw new IndexOutOfRangeException("Row or column index is out of range.");
            }

            return _elements.TryGetValue((i, j), out long value) ? value : 0;
        }
        set
        {
            if (i < 0 || i >= _rows || j < 0 || j >= _columns)
            {
                throw new IndexOutOfRangeException("Row or column index is out of range.");
            }

            if (value != 0)
            {
                _elements[(i, j)] = value;
            }
            else
            {
                _elements.Remove((i, j));
            }
        }
    }

    public override string ToString()
    {
        var result = new System.Text.StringBuilder();

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                result.Append(this[i, j]).Append(' ');
            }
            result.AppendLine();
        }

        return result.ToString();
    }

    public IEnumerator<long> GetEnumerator()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                yield return this[i, j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<(int, int, long)> GetNonzeroElements()
    {
        foreach (var element in _elements)
        {
            yield return (element.Key.Item1, element.Key.Item2, element.Value);
        }
    }

    public int GetCount(long x)
    {
        int count = 0;

        if (x == 0)
        {
            count = _rows * _columns - _elements.Count;
        }
        else
        {
            foreach (var element in _elements.Values)
            {
                if (element == x)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
