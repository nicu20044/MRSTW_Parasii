using OtdamDarom.BusinessLogic.Interfaces;
using OtdamDarom.BusinessLogic.Services;

namespace OtdamDarom.BusinessLogic
{
    public static class BusinessLogic
    {
        public static IAuth GetAuthBl()
        {
            return new AuthService();
        }

        public static ICategory GetCategoryBl()
        {
            return new CategoryService();
        }

        public static IDeal GetDealBl()
        {
            return new DealService();
        }

        public static ISession GetSessionBl()
        {
            return new SessionService();
        }

        public static ISubcategory GetSubcategoryBl()
        {
            return new SubcategoryService();
        }

        public static IUser GetUserBl()
        {
            return new UserService();
        }
    }
}