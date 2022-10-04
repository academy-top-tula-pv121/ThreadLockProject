namespace ThreadLockProject
{
    class Reader
    {
        static Semaphore semaphore = new(2, 5);
        Thread thread;
        int count = 3;

        public Reader(int i)
        {
            thread = new Thread(Read);
            thread.Name = $"Reader {i}";
            thread.Start();
        }

        public void Read()
        {
            while(count > 0)
            {
                semaphore.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name} in library /step{count}/");
                Console.WriteLine($"{Thread.CurrentThread.Name} read book");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} out from library");
                Console.WriteLine("\n------------------\n");
                semaphore.Release();

                count--;
                //Thread.Sleep(1000);
            }
        }
    }

    internal class Program
    {
        static object locker = new();

        static int num = 0;

        static AutoResetEvent wait = new AutoResetEvent(false);

        static Mutex mutex = new();
        static void PrintNumber()
        {
            //lock (new object())
            //bool flag = false;
            //try
            //{
            //    Monitor.Enter(locker, ref flag);
            //    {
            //        num = 1;
            //        for (int i = 0; i < 10; i++)
            //        {

            //            Console.WriteLine($"{Thread.CurrentThread.Name} - {num}");
            //            ++num;
            //            Thread.Sleep(100);
            //        }
            //    }
            //}
            //finally
            //{
            //    if (flag)
            //        Monitor.Exit(locker);
            //}

            //wait.WaitOne();
            //num = 1;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.Name} - {num}");
            //    ++num;
            //    Thread.Sleep(100);
            //}
            //wait.Set();

            //mutex.WaitOne();
            //num = 1;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.Name} - {num}");
            //    ++num;
            //    Thread.Sleep(100);
            //}
            //mutex.ReleaseMutex();

            
        }

        //static void NumInc()
        //{
        //    for(int i = 0; i < 1000; i++)
        //    {
        //        Thread.Sleep(1);
        //        //Console.Write(".");
        //        num++;

        //    }
        //}
        static void Main(string[] args)
        {
            //for(int i = 0; i < 5; i++)
            //{
            //    Thread thread = new(PrintNumber);
            //    thread.Name = $"Thread {i + 1}";
            //    thread.Start();
            //    //thread.Join();
            //}
            //Thread.Sleep(1000);
            //wait.Set();
            ////wait.WaitOne();

            //Console.WriteLine(num);

            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }
                
        }
    }
}