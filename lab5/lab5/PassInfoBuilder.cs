namespace lab32
{
    public class PassInfoBuilder
    {
        private string _name;
        private Status _status;
        private PassTypes _passType;
        private int _securityLevel = 1;
        private int _passesAmountLeft = 0;

        public PassInfoBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public PassInfoBuilder SetStatus(Status status)
        {
            _status = status;
            return this;
        }

        public PassInfoBuilder SetPassType(PassTypes passType)
        {
            _passType = passType;
            if(passType == PassTypes.Permanent)
            {
                _passesAmountLeft = int.MaxValue;
            }
            return this;
        }

        public PassInfoBuilder SetSecurityLevel(int securityLevel)
        {
            _securityLevel = securityLevel;
            return this;
        }

        public PassInfoBuilder SetPassesAmountLeft(int passesAmountLeft)
        {
            _passesAmountLeft = passesAmountLeft;
            return this;
        }

        public PassInfo Build()
        {
            return new PassInfo(_name, _status, _passType, _securityLevel, _passesAmountLeft);
        }
    }
}