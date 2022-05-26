using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class MyString
    {
        private char[] arraySymbols;

        public MyString(string str)
        {
            arraySymbols = str.ToCharArray();
        }

        public MyString(char[] s)
        {
            arraySymbols = s;
        }

        public MyString()
        {
            arraySymbols = new Char[1];
        }

        public static MyString operator +(MyString myString1, MyString myString2)
        {
            return new MyString(myString1.ToString() + myString2.ToString());
        }

        public static MyString operator +(MyString myString1, String String2)
        {
            return new MyString(myString1.ToString() + String2);
        }

        public override string ToString()
        {
            string str = null;

            foreach (var s in arraySymbols)
            {
                str += s;
            }

            return str;
        }

        public static bool operator ==(MyString myString1, MyString myString2)
        {
            bool isTrue = false;

            if (!ReferenceEquals(myString2, null) && !ReferenceEquals(myString1, null))
            {
                isTrue = myString1.ToString().GetHashCode() == myString2.ToString().GetHashCode();
            }
            if (ReferenceEquals(myString2, null) && ReferenceEquals(myString1, null))
            {
                return true;
            }
            return isTrue;
        }
        public static bool operator !=(MyString myString1, MyString myString2)
        {
            return !(myString1 == myString2);
        }


        public static MyString operator -(MyString myString1, MyString myString2)
        {
            int count = 0;
            int index = -1;
            bool isEqual = false;

            for (int i = 0; i < myString1.arraySymbols.Length; i++)
            {
                if (myString1.arraySymbols[i] == myString2.arraySymbols[count])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == myString2.arraySymbols.Length)
                {
                    index = i + 1;
                    isEqual = true;
                    break;
                }
            }
            if (isEqual)
            {
                Array.Clear(myString1.arraySymbols, index - myString2.arraySymbols.Length, myString2.arraySymbols.Length);
                char[] newSymbols = new char[myString1.arraySymbols.Length - myString2.arraySymbols.Length];
                char zero = new char();
                int j = 0;
                foreach(var s in myString1.arraySymbols)
                {
                    if (s != zero)
                    {
                        newSymbols[j] = s;
                        j++;
                    }
                }
                return new MyString(newSymbols);
            }
            else
            {
                return myString1;
            }
        }
    }
}

