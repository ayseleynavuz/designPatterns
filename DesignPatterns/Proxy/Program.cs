using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//cacheleme sistemine benzetilebilir.Çağrılmak istenilen operasyon sonucu sabit olan bir hesaplamaysa veya bir kaynaksa 
//tekrar tekrar yeniden çağırmamak için hızlandırma sürecidir

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase creditManager = new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());
            Console.ReadLine();

        }
    }

    abstract class CreditBase  //kredi hesaplamasının belli bir mesleğe,yaşa göre yapılasını if'ler ile çözmek yerine bunların concrete i oluşturulup bu şekilde ilerlenmelidir
    {
        public abstract int Calculate();

    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= 1;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        CreditManager _creditManager;
        private int _cacheValue;
        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cacheValue = _creditManager.Calculate();
            }
            return _cacheValue;
        }
    }
    


}
