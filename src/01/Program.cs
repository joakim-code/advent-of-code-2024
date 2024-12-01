using Microsoft.VisualBasic.FileIO;

var filePath = "../../../data/input.txt";
string[] input = File.ReadAllLines(filePath);

int[] leftList = new int[1000];
int[] rightList = new int[1000];

int distance = 0;

for (int i = 0; i < 1000; i++)
{
    string[] numbers = input[i].Split("   ");
    leftList[i] = int.Parse(input[i].Substring(0,5));
    rightList[i] = int.Parse(input[i].Substring(8,5));
}

//sooooort
BubbleSort(leftList);
BubbleSort(rightList);

for (int i = 0; i < 1000; i++) {
    distance += Math.Abs(leftList[i] - rightList[i]);
}

Console.WriteLine($"The total distance was: {distance}");

int similarity = 0;
for (int i = 0; i < 1000; i++)
{
    var count = 0;
    for (int j = 0; j < 1000; j++)
    {
        if (leftList[i] == rightList[j])
            count++;
    }
    similarity += leftList[i] * count;
}

Console.WriteLine($"The similarity score was: {similarity}");




//just for fun
static void BubbleSort(int[] list) {
    int n = list.Length;
    for (int i = 0; i < n - 1; i++)
        for (int j = 0; j < n - i - 1; j++)
            if (list[j] > list[j + 1]) {
                int temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
            }
}

