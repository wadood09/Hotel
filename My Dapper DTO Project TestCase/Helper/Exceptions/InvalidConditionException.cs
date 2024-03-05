namespace My_Dapper_DTO_Project_TestCase.Helper.Exceptions
{
    public class InvalidConditionException : Exception
    {
        public override string Message => "Some Conditions have yet to be met or fulfilled!!!";
    }
}