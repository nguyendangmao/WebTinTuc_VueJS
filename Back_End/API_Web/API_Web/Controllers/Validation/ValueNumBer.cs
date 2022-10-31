namespace API_Web.Controllers.Validation
{
    public class ValueNumBer
    {
        //Quảng cáo
        public static bool CheckSo(int a, int b)
        {
            if (a > 0 && b > 0)
            {
                if (a < 500 && b < 500)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
