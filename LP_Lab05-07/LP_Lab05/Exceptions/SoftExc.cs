using System;  


namespace LP_Lab05.Exceptions
{
    class SoftExc:Exception
    {
        public SoftExc(string masage) : base(masage){ }
    }
}