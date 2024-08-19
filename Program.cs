using System;
using System.Linq;

class Program
{
    private int[] matrix;
    private int size = 10;

    static void Main()
    {
        Program program = new Program();
        program.GenerateRandomMatrix();

        Console.WriteLine("Произведение элементов массива с четными номерами: " + program.EvenComp());
        var zeroCount = program.FindZeros();
        Console.WriteLine("Сумма элементов массива, расположенных между первым и последним нулевыми элементами: " + program.SumCount(zeroCount.count, zeroCount.firstZero, zeroCount.lastZero));
        Console.WriteLine("Новый массив: " + string.Join(", ", program.ChangedArray()));
    }

    public void GenerateRandomMatrix() {
        matrix = new int[size];
        Random random = new Random();

        for (int i = 0; i < matrix.Length; i++) {
            matrix[i] = random.Next(-100, 100);
        }
    }

    public int EvenComp() {
        int comp = 1;
        for (int i = 1; i < matrix.Length; i += 2) {
            comp *= matrix[i];
        }
        return comp;
    }

    public (int count, int firstZero, int lastZero) FindZeros() 
    {
        int count = 0;
        int firstZero = -1;
        int lastZero = -1;

        for (int i = 0; i < matrix.Length; i++) {
            if (matrix[i] == 0) {
                count ++;
                if (firstZero == -1) {
                    firstZero = i;
                }
                lastZero = i;
            }
        }
        return (count, firstZero, lastZero);
    }

    public int SumCount(int count, int firstZero, int lastZero) 
    {
        int sum = 0;
        if (count > 1) {
            for (int i = firstZero + 1; i < lastZero; i++) {
                sum += matrix[i];
            }
        }
        return sum;
    }

    public int[] ChangedArray() {
        var positiveList = new List<int>();
        var negativeList = new List<int>();

        for (int i = 0; i < matrix.Length; i++) {
            if (matrix[i] >= 0) {
                positiveList.Add(matrix[i]);
            }
            else {
                negativeList.Add(matrix[i]);
            }
        }

        positiveList.AddRange(negativeList);

        return positiveList.ToArray();
    }
}