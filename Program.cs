using System;
using System.Collections;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] DiatonicForm = new int[] { 1, 3, 5, 6, 8, 10, 12 };
            int[] PentatonicForm = new int[] { 1, 3, 5, 8, 10 };
            int[] MajTripletForm = new int[] { 1, 5, 8 };
            int[] MinTripletForm = new int[] { 10, 1, 5 };

            int[] ChordMaj7Form = new int[] { 1, 5, 8, 12 };
            int[] ChordMin7Form = new int[] { 10, 1, 5, 8 };
            int[] ChordDom7Form = new int[] { 8, 12, 3, 6 };
            int[] ChordDim7Form = new int[] { 12, 3, 6, 10 };

            string key = "c";
            Console.WriteLine("Небольшой хелпер для освоения нот на грифе гитары в разных тональностях. \n");
            Console.WriteLine("Введите ключ тональности в формате: C,  C#, D, ... B ");
            Console.WriteLine("");
            key = Console.ReadLine();
            Console.Clear();

            int[] Diatonic = toShift(key, DiatonicForm);
            int[] Pentatonic = toShift(key, PentatonicForm);
            int[] MajTriplet = toShift(key, MajTripletForm);
            int[] MinTriplet = toShift(key, MinTripletForm);

            int[] ChordMaj7 = toShift(key, ChordMaj7Form);
            int[] ChordMin7 = toShift(key, ChordMin7Form);
            int[] ChordDom7 = toShift(key, ChordDom7Form);
            int[] ChordDim7 = toShift(key, ChordDim7Form);

            ArrayList scales = new ArrayList();

            scales.Add(Diatonic);
            scales.Add(Pentatonic);
            scales.Add(MajTriplet);
            scales.Add(MinTriplet);

            scales.Add(ChordMaj7);
            scales.Add(ChordMin7);
            scales.Add(ChordDom7);
            scales.Add(ChordDim7);

            int index = 0;
            foreach (int[] scale in scales)
            {
                Console.WriteLine(text(key)[index]);
                printScale(scale);
                index++;
            }

            Console.WriteLine("Для выхода нажать Enter.");
            Console.SetWindowPosition(0, 0);
            Console.ReadLine();

        }

        static string[] text(string key)
        {
            string[] txt = new string[8];
            key = key.ToUpper();
            txt[0] = "Диатоника в тональности " + key + "-мажор:";
            txt[1] = "Пентатоника в тональности " + key + "-мажор:";
            txt[2] = "Мажорное трезвучие от первой ступени в " + key + "-мажор:";
            txt[3] = "Минорное трезвучие от шестой ступени в " + key + "-мажор:";
            txt[4] = "Септаккорд " + key + "maj7";
            txt[5] = "Минорный септаккорд от шестой ступени в " + key + "-мажор";
            txt[6] = "Доминант-септаккорд от пятой ступени в " + key + "-мажор";
            txt[7] = "Полууменьшенный септаккорд от седьмой ступени в " + key + "-мажор";

            return txt;
        }

        static int[] toShift(string key, int[] scale)
        {
            key = key.ToLower();
            int shift = 0;

            switch (key)
            {
                case "c": shift = 0; break;
                case "c#": shift = 1; break;
                case "d": shift = 2; break;
                case "d#": shift = 3; break;
                case "e": shift = 4; break;
                case "f": shift = 5; break;
                case "f#": shift = 6; break;
                case "g": shift = 7; break;
                case "g#": shift = 8; break;
                case "a": shift = 9; break;
                case "a#": shift = 10; break;
                case "b": shift = 11; break;
                default:
                    Console.WriteLine("Что то пошло не так. возможно не та раскладка..");
                    Environment.Exit(0); break;
            }

            int[] newScale = new int[scale.Length];
            int index = 0;

            foreach (int note in scale)
            {
                if (note + shift > 12)
                {
                    newScale[index] = (note + shift) - 12;
                }
                else
                {
                    newScale[index] = note + shift;
                }
                index++;
            }
            return newScale;
        }

        static void printScale(int[] scale)
        {
            for (int n = 1; n < 7; n++)
            {
                Console.WriteLine(getNotesOnString(n, scale));
            }
            Console.WriteLine("");
        }

        static string getNotesOnString(int numberOfString, int[] positions)
        {
            positions = getPositions(numberOfString, positions);

            string result = "|";

            for (int n = 1; n < 13; n++)
            {
                Boolean isTrue = false;

                foreach (int position in positions)
                {
                    if (position == n)
                    {
                        isTrue = true;
                        break;
                    }
                    else
                    {
                        isTrue = false;
                    }
                }

                if (isTrue)
                {
                    result += " o ";
                }
                else
                {
                    result += "   ";
                }
                result += "|";
            }
            return result;
        }

        static int[] getPositions(int numberOfString, int[] notes)
        {

            int shift = 0;
            int index = 0;

            switch (numberOfString)
            {
                case 1: shift = 7; break;
                case 2: shift = 0; break;
                case 3: shift = 4; break;
                case 4: shift = 9; break;
                case 5: shift = 2; break;
                case 6: shift = 7; break;
            }

            int[] newNotes = new int[notes.Length];

            foreach (int note in notes)
            {
                int position = note + shift;

                if (position > 12) position -= 12;
                newNotes[index] = position;
                index++;
            }
            return newNotes;
        }
    }
}
