using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using System.IO;

namespace LAB_2
{
    public class ComplexNumBackup
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }
        public ComplexNumBackup()
        {

        }
        public ComplexNumBackup(ComplexNumBackup a)
        {
            RealPart = a.RealPart;
            ImaginaryPart = a.ImaginaryPart;
        }
        public ComplexNumBackup(double real)
        {
            RealPart = real;
            ImaginaryPart = 0;
        }
        public ComplexNumBackup(double real, double imaginary)
        {
            RealPart = real;
            ImaginaryPart = imaginary;
        }
        public static ComplexNumBackup operator +(ComplexNumBackup a, ComplexNumBackup b)
        {
            return new ComplexNumBackup()
            {
                ImaginaryPart = a.ImaginaryPart + b.ImaginaryPart,
                RealPart = a.RealPart + b.RealPart
            };
        }
        public static ComplexNumBackup operator -(ComplexNumBackup a, ComplexNumBackup b)
        {
            return new ComplexNumBackup()
            {
                ImaginaryPart = a.ImaginaryPart - b.ImaginaryPart,
                RealPart = a.RealPart - b.RealPart
            };
        }
        public static ComplexNumBackup operator +(ComplexNumBackup a, double k)
        {
            return new ComplexNumBackup()
            {
                ImaginaryPart = a.ImaginaryPart,
                RealPart = a.RealPart + k
            };
        }
        public static ComplexNumBackup operator -(ComplexNumBackup a, double k)
        {
            return new ComplexNumBackup()
            {
                ImaginaryPart = a.ImaginaryPart,
                RealPart = a.RealPart - k
            };
        }
        public static ComplexNumBackup operator *(ComplexNumBackup a, ComplexNumBackup b)
        {
            return new ComplexNumBackup()
            {
                RealPart = a.RealPart * b.RealPart - a.ImaginaryPart * b.ImaginaryPart,
                ImaginaryPart = a.RealPart * b.ImaginaryPart + a.ImaginaryPart * b.RealPart
            };
        }
        public static ComplexNumBackup operator *(ComplexNumBackup a, double d)
        {
            return new ComplexNumBackup()
            {
                RealPart = a.RealPart * d,
                ImaginaryPart = a.ImaginaryPart * d
            };
        }
        public static ComplexNumBackup operator /(ComplexNumBackup a, ComplexNumBackup b)
        {
            return new ComplexNumBackup()
            {
                RealPart = (a.RealPart * b.RealPart + a.ImaginaryPart * b.ImaginaryPart) / (b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart),
                ImaginaryPart = (a.ImaginaryPart * b.RealPart - a.RealPart * b.ImaginaryPart) / (b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart)
            };
        }
        public static ComplexNumBackup operator /(ComplexNumBackup a, double d)
        {
            return new ComplexNumBackup()
            {
                RealPart = a.RealPart / d,
                ImaginaryPart = a.ImaginaryPart / d
            };
        }
        public static bool operator ==(ComplexNumBackup a, ComplexNumBackup b)//сравнение по разнице модулей
        {
            if ((Abs(a.ImaginaryPart - b.ImaginaryPart) < 0.0000001 && Abs(a.RealPart - b.RealPart) < 0.0000001))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(ComplexNumBackup a, ComplexNumBackup b)
        {
            if (Abs(a.ImaginaryPart - b.ImaginaryPart) > 0.0000001 && Abs(a.RealPart - b.RealPart) > 0.0000001)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            ComplexNumBackup n = obj as ComplexNumBackup;
            if ((Object)n == null)
            {
                return false;
            }
            return (Abs(ImaginaryPart - n.ImaginaryPart) < 0.0000001) && (Abs(RealPart - n.RealPart) < 0.0000001);
        }
        public bool Equals(ComplexNumBackup n)
        {
            if ((object)n == null)
            {
                return false;
            }
            return (Abs(ImaginaryPart - n.ImaginaryPart) < 0.0000001) && (Abs(RealPart - n.RealPart) < 0.0000001);
        }
        public override int GetHashCode()
        {
            return (int)ImaginaryPart ^ (int)RealPart;
        }
        public void MakeCopy()
        {
            if (!(Directory.Exists("C:\\tmp")))
            {
                Directory.CreateDirectory("C:\\tmp");
            }
            if (!(File.Exists("C:\\tmp\\Copy.txt")))
            {
                File.Create("C:\\tmp\\Copy.txt");
            }
            using (FileStream file = new FileStream("C:\\tmp\\Copy.txt", FileMode.Open))
            {
                StreamWriter writer = new StreamWriter(file, Encoding.UTF8);
                writer.WriteLine($"{RealPart}");
                writer.WriteLine($"{ImaginaryPart}");
                writer.Close();
            }
        }
        public void DoBackup()
        {
            using (FileStream file = new FileStream("C:\\tmp\\Copy.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(file);
                RealPart = Convert.ToDouble(reader.ReadLine());
                ImaginaryPart = Convert.ToDouble(reader.ReadLine());
                reader.Close();
            }
        }
        public override string ToString()
        {
            return $"{RealPart} + {ImaginaryPart}i";
        }
    }
}
