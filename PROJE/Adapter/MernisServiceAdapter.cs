using PROJE.Adapter;
using PROJE.MernisServiceReference; //mernis web servisi için kullanılan kütüphane
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE
{
    class MernisServiceAdapter
    {
        public bool CheckIfRealPerson(Person person)
        {
            //TC Kimlik doğrulamak için gerekli metotun bulunduğu mernis classı
            KPSPublicSoapClient client = new KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(Convert.ToInt64(person.NationalityId),
                                            person.firstName.ToUpper(),
                                            person.lastName.ToUpper(),
                                            person.DateOfYear);
        }
    }
}
