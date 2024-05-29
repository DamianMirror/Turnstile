namespace lab32
{
    public class PassInfoBuilder : IPassInfoBuilder
    {
        
        
        private string _name;
        private Status _status;
        private PassTypes _passType;
        private int _securityLevel = 0;
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
            PassInfo pass = new PassInfo();
            pass.Name = _name;
            pass.Status = _status;
            pass.PassType = _passType;
            pass.PassesAmountLeft = _passesAmountLeft;
            pass.SetSecurityLevel(_securityLevel);
            return pass;
        }
    }
}