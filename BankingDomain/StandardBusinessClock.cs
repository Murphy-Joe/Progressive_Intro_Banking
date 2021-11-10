namespace BankingDomain
{
    public class StandardBusinessClock : IProvideTheBusinessClock
    {
        private readonly ISystemTime _systemTime;

        public StandardBusinessClock(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        public bool IsDuringBusinessHours()
        {
            return (_systemTime.GetCurrent().Hour >= 9 && _systemTime.GetCurrent().Hour < 17);
        }
    }
}