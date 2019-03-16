using System;
using System.Timers;

namespace Alarm
{

    class MainClass
    {
        private static System.Timers.Timer aTimer;
        public static void Main(string[] args)
        {
            Console.WriteLine("请输入您要在几秒后使闹钟唤醒");
            int alarmTime = Convert.ToInt16(Console.ReadLine());
            setTimer(alarmTime);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

        }

        private static void setTimer(int seoconds)
        {
            aTimer = new System.Timers.Timer(1000 * seoconds);
            aTimer.Elapsed += MakeSound;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

        }

        static void MakeSound(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Alarm!!");
        }
    }
}
