using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.MessageTypes
{
    //uygulamalar arasında mesajlasma sürecinde kullanılacak formatı kodluyoruz
    public interface IMessage
    {
        public string Text { get; set; }
    }
}
//hangi ınterface ile neyi ilişkilendirmek istersek o şnterfaceyi kullanarak sadece ilgili şeyin proplarını görselleriz/okuturuz/mesajlaştırırız.