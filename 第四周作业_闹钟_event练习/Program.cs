using System;
using System.Threading;

namespace 第四周作业_闹钟_event练习
{
    internal class alarmClock
    {
        public event EventHandler Tick;
        public event EventHandler Alarm;

        private int alarmTime;
        private int currentTime;

        public alarmClock(int alarmTime)//构造函数
        {
            this.alarmTime = alarmTime;
            this.currentTime = 0;
        }

        public void Start()//启动闹钟
        {
            while (currentTime <= alarmTime)
            {
                Thread.Sleep(1000);//每隔一秒钟触发一次事件
                currentTime++;
                OnTick();
                if (currentTime == alarmTime)
                {
                    OnAlarm();
                    break;//这里如果不加这一句，时间停止后还会再滴答一次
                }
            }
        }

        protected virtual void OnTick()//触发每秒钟事件
        {
            if (Tick != null)//有订阅者就触发事件
            {
                Tick.Invoke(this, new EventArgs());
            }
        }

        protected virtual void OnAlarm()//触发闹钟事件
        {
            if (Alarm != null)//有订阅者就触发事件
            {
                Alarm.Invoke(this, new EventArgs());
            }
        }      
    }
        class Program
        {
            static void Main(string[] args)
            {
            alarmClock clock = new alarmClock(10);//我们假设闹钟10s后响
            clock.Tick += (sender, e) => Console.WriteLine("滴答");
            clock.Alarm += (sender, e) => Console.WriteLine("时间到了");
            clock.Start();
            }
        }
}
