using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidades.Ejercicio3
{
    public struct Coordinate
    {
        public double x;
        public double y;

        public Coordinate(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    #region ejemplo de estructura tomado de docs.microsoft.com
    
    //Con pequeños ajustes relacionados a la simplificacion de declaraciones.

    /// <summary>
    /// Commonly used in databases this struct can represent 3 values DBBool.True, DBBool.False, DBBool.Null
    /// </summary>
    public struct DBBool
    {
        // The three possible DBBool values.
        public static readonly DBBool Null = new (0);
        public static readonly DBBool False = new (-1);
        public static readonly DBBool True = new (1);

        // Private field that stores -1, 0, 1 for False, Null, True.

        readonly sbyte value;

        // Private instance constructor. The value parameter must be -1, 0, or 1.

        DBBool(int value)
        {
            this.value = (sbyte)value;
        }

        // Properties to examine the value of a DBBool. Return true if this
        // DBBool has the given value, false otherwise.

        public bool IsNull { get { return value == 0; } }

        public bool IsFalse { get { return value < 0; } }

        public bool IsTrue { get { return value > 0; } }

        // Implicit conversion from bool to DBBool. Maps true to DBBool.True and
        // false to DBBool.False.

        public static implicit operator DBBool(bool x)
        {
            return x ? True : False;
        }

        // Explicit conversion from DBBool to bool. Throws an exception if the
        // given DBBool is Null, otherwise returns true or false.

        public static explicit operator bool(DBBool x)
        {
            if (x.value == 0) throw new InvalidOperationException();
            return x.value > 0;
        }

        // Equality operator. Returns Null if either operand is Null, otherwise
        // returns True or False.

        public static DBBool operator ==(DBBool x, DBBool y)
        {
            if (x.value == 0 || y.value == 0) return Null;
            return x.value == y.value ? True : False;
        }

        // Inequality operator. Returns Null if either operand is Null, otherwise
        // returns True or False.

        public static DBBool operator !=(DBBool x, DBBool y)
        {
            if (x.value == 0 || y.value == 0) return Null;
            return x.value != y.value ? True : False;
        }

        // Logical negation operator. Returns True if the operand is False, Null
        // if the operand is Null, or False if the operand is True.

        public static DBBool operator !(DBBool x)
        {
            return new DBBool(-x.value);
        }

        // Logical AND operator. Returns False if either operand is False,
        // otherwise Null if either operand is Null, otherwise True.

        public static DBBool operator &(DBBool x, DBBool y)
        {
            return new DBBool(x.value < y.value ? x.value : y.value);
        }

        // Logical OR operator. Returns True if either operand is True, otherwise
        // Null if either operand is Null, otherwise False.

        public static DBBool operator |(DBBool x, DBBool y)
        {
            return new DBBool(x.value > y.value ? x.value : y.value);
        }

        // Definitely true operator. Returns true if the operand is True, false
        // otherwise.

        public static bool operator true(DBBool x)
        {
            return x.value > 0;
        }

        // Definitely false operator. Returns true if the operand is False, false
        // otherwise.

        public static bool operator false(DBBool x)
        {
            return x.value < 0;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DBBool)) return false;
            return value == ((DBBool)obj).value;
        }

        public override int GetHashCode()
        {
            return value;
        }

        public override string ToString()
        {
            if (value > 0) return "DBBool.True";
            if (value < 0) return "DBBool.False";
            return "DBBool.Null";
        }
    }
    #endregion;
}
