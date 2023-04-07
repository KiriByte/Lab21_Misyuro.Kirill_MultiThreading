// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

//List<int> numbers = Enumerable.Range(0, int.MaxValue).ToList();

int chunkSize = int.MaxValue / sizeof(int);
int numChunks = (int.MaxValue / chunkSize) + 1;
List<List<int>> lists = new List<List<int>>(numChunks);
for (int i = 0; i < numChunks; i++)
{
    int start = i * chunkSize;
    int count = (i == numChunks - 1) ? int.MaxValue - start + 1 : chunkSize;
    List<int> chunkList = Enumerable.Range(start, count).ToList();
    lists.Add(chunkList);
}

//List<int> allDiv3 = new List<int>();
Parallel.ForEach(lists, list =>
{

    foreach (int i in list)
    {
        if (i % 3 == 0)
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}:\t {i}.");
    }

    //List<int> div3 = list.Where(x => x % 3 == 0).ToList();
    ////lock (allDiv3)
    ////{
    ////    allDiv3.AddRange(div3);
    ////    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} complete.");
    ////}
    //allDiv3.AddRange(div3);
    //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} complete.");
});
//foreach (var value in allDiv3)
//{
////    Console.WriteLine(value);
////}
//Console.WriteLine();
//Console.WriteLine($"Count numbers div 3 = {allDiv3.Count}");