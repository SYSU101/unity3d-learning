using System;

public class CheckTimer
{
    private DateTime consTime;
    private long mstime;
    private Action work;

    public CheckTimer()
    {
        consTime = DateTime.Now;
    }

    public static CheckTimer SetTimeout(long mstime, Action work)
    {
        CheckTimer newTimer = new CheckTimer();
        newTimer.mstime = mstime;
        newTimer.work = work;
        return newTimer;
    }

    public bool Check()
    {
        if (DateTime.Now.Ticks - consTime.Ticks >= mstime*10000)
        {
            work();
            return false;
        }
        return true;
    }
}
