namespace BLL.Exeptions
{
    public class BorrowRequestExeptions
    {
        public class ItemTakenException : Exception
        {
            public ItemTakenException() : base("The item is already taken.")
            {
            }
        }

        public class MaximumBorrowDurationExceededException : Exception
        {
            public MaximumBorrowDurationExceededException() : base("The maximum borrow duration has been exceeded.")
            {
            }
        }

        public class InvalidLoanDatesException : Exception
        {
            public InvalidLoanDatesException() : base("Invalid loan dates specified.")
            {
            }
        }
    }
}
