
var filePath = "../../../data/input.txt";
string[] reports = File.ReadAllLines(filePath);
int safeReports = reports.Length;
int realSafeReports = 0;

foreach (var line in reports)
{
    int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
    int safeReportStatus = CheckSafetyReport(numbers);
    int[][] dampenedNumbers = new int[numbers.Length][];

    if (safeReportStatus == 1)
    {
        for (int i = 0, level = 0; i < numbers.Length; i++, level++)
        {
            dampenedNumbers[i] = new int[numbers.Length - 1];
            for (int j = 0, ii = 0; j < numbers.Length - 1; j++, ii++)
            {
                if (j == level)
                    ii++;
                dampenedNumbers[i][j] = numbers[ii];
            }

            int tempReportStatus = CheckSafetyReport(dampenedNumbers[i]);
            if (tempReportStatus == 0)
            {
                realSafeReports++;
                break;
            }
        }
    }
    safeReports -= safeReportStatus;
}

realSafeReports += safeReports;

Console.WriteLine($"Safe reports:{safeReports}");
Console.WriteLine($"Real safe reports:{realSafeReports}");

static int CheckSafetyReport(int[] numbers)
{
    for(int i=0,j=1,decreasing = 0,increasing = 0, equals = 0,difference = 0;i<numbers.Length;i++,j++)
    {
        if (numbers[i] > numbers[j])
            decreasing++;
        else if (numbers[i] < numbers[j])
            increasing++;
        else 
            equals++;

        if (Math.Abs(numbers[i] - numbers[j]) > 3)
            difference++;
        
        if (j == numbers.Length - 1)
        {
            if (decreasing > 0 && increasing > 0 || equals > 0 || difference > 0)
            {
                return 1;
            }
            break;
        }
    }
    return 0;
}