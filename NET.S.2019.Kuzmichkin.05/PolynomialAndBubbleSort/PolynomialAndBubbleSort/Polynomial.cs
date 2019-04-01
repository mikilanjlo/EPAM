using System;

namespace PolynomialAndBubbleSort
{
    public sealed class Polynomial : ICloneable
    {
        private double[] m_cooficents;

        /// <summary>
        /// Class Polynomial represents a polynomial by its coefficients, arranged in
        /// ascending order—-that is, a vector of coefficients a0, a1, ... an such that
        /// f(x) = a0*x^0 + a1*X^1 + ... + an*x^n. 
        /// </summary>
        /// <param name="cooficents"></param>
        public Polynomial(params double[] cooficents)
        {
            if (cooficents == null)
                throw new ArgumentNullException(nameof(cooficents));
            if (cooficents.Length <= 1)
                throw new ArgumentException(nameof(cooficents));
            m_cooficents = cooficents;
        }

        public double[] Cooficents
        {
            get { return m_cooficents; }
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Polynomial))
                throw new ArgumentException("obj is not Polynomial");
            Polynomial polynom = obj as Polynomial;
            return IsEqual(this, polynom);
        }

        private bool IsEqual(Polynomial first, Polynomial second)
        {
            if (m_cooficents.Length != second.Cooficents.Length)
                return false;
            for (int i = 0; i < first.Cooficents.Length; i++)
            {
                if (first.Cooficents[i] != second.Cooficents[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashcode = 1;
            for (int i = 0; i < m_cooficents.Length; i++)
            {
                hashcode = (hashcode * 7) + m_cooficents[i].GetHashCode();
                if (hashcode > 200000000)
                    hashcode %= 200000000;
            }
            return hashcode;
        }

        public override string ToString()
        {
            string str = "";
            for(int i = m_cooficents.Length - 1; i >= 0; i--)
            {
                if (m_cooficents[i] != 0)
                {
                    str += m_cooficents[i] + "x^" + i + " ";
                    if (i > 0)
                        if (m_cooficents[i - 1] > 0)
                            str += "+ ";
                }
            }
            return str;
        }



        private static void Swap(ref Polynomial first,ref Polynomial second)
        {
            Polynomial tmp = first;
            first = second;
            second = tmp;
        }

        public object Clone()
        {
            double[] array = new double[m_cooficents.Length];
            for (int i = 0; i < m_cooficents.Length; i++)
                array[i] = m_cooficents[i];
            return new Polynomial(array);
        }

        public double[] CooficentsClone()
        {
            double[] array = new double[m_cooficents.Length];
            for (int i = 0; i < m_cooficents.Length; i++)
                array[i] = m_cooficents[i];
            return array;
        }

        public static bool operator ==(Polynomial first, Polynomial second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !first.Equals(second);
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            if (second.Cooficents.Length > first.Cooficents.Length) 
                Swap(ref first,ref second);
            double[] array = first.CooficentsClone();
            for (int i = 0; i < second.Cooficents.Length; i++)
            {
                array[i] += second.Cooficents[i];
            }
            return new Polynomial(array);
        }

        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            bool swap = false;
            if (second.Cooficents.Length > first.Cooficents.Length)
            {
                Swap(ref first, ref second);
                swap = true;     
            }
            int znak = -1;
           
            double[] array = first.CooficentsClone();
            if (swap)
            {
                for (int i = 0; i < array.Length; i++)
                    array[i] *= -1;
                znak = 1;
            }
            for (int i = 0; i < second.Cooficents.Length; i++)
            {
                array[i] += second.Cooficents[i] * znak;
            }
            return new Polynomial(array);
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            double[] array = new double[first.Cooficents.Length + second.Cooficents.Length - 1];
            for (int i = 0; i < array.Length; i++)
                array[i] = 0;
            for (int i = 0; i < first.Cooficents.Length; i++)
            {
                for (int j = 0; j < second.Cooficents.Length; j++)
                {
                    array[i+j] += first.Cooficents[i]  * second.Cooficents[j];
                }
            }
            return new Polynomial(array);
        }

        public static Polynomial operator *(Polynomial first, int number)
        {
            double[] array = first.CooficentsClone();
            for (int i = 0; i < first.Cooficents.Length; i++)
            {
                array[i] *= number;
            }
            return new Polynomial(array);
        }

        public static Polynomial operator *(int number, Polynomial first)
        {
            double[] array = first.CooficentsClone();
            for (int i = 0; i < first.Cooficents.Length; i++)
            {
                array[i] *= number;
            }
            return new Polynomial(array);
        }
    }
}
