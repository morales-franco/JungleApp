using JungleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Services
{
    public class TestService
    {
        
        public void ThrowOriginalException()
        {
            var exceptionService = new ExceptionService();
            try
            {
                exceptionService.ThowSomething();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("-------ORIGINAL EXCEPTION-------");
                Debug.WriteLine(ex.InnerException);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                Debug.WriteLine("-------THROW ORIGINAL EXCEPTION-------");
                throw;
            }
        }

        public void ThrowExceptionWithResetStackTrace()
        {
            var exceptionService = new ExceptionService();
            try
            {
                exceptionService.ThowSomething();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("-------ORIGINAL EXCEPTION-------");
                Debug.WriteLine(ex.InnerException);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                Debug.WriteLine("-------THROW EXCEPTION (RESET STACK TRACE)-------");
                throw ex;
            }
        }

        public void ThrowCustomException()
        {
            var exceptionService = new ExceptionService();
            try
            {
                exceptionService.ThowSomething();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("-------ORIGINAL EXCEPTION-------");
                Debug.WriteLine(ex.InnerException);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                Debug.WriteLine("-------THROW CUSTOM EXCEPTION-------");
                throw new JungleException("CUSTOM EXCEPTION", ex);
            }
        }

    }
}
