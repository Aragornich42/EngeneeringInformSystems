using System;
using System.Collections.Generic;

namespace IoC
{
    public class TrivialIoCC
    {
        private Dictionary<Type, Type> _diDict = new Dictionary<Type, Type>();

        public TrivialIoCC() { }

        public TrivialIoCC(Type intf, Type impl)
        {
            _diDict.Add(intf, impl);
        }

        /// <summary>
        /// Можно даже повторно заинжектить - сменится имплементация просто
        /// </summary>
        public void Inject<Intf, Impl>()
        {
            var intf = typeof(Intf);
            if (_diDict.ContainsKey(intf))
                _diDict[intf] = typeof(Impl);
            _diDict.Add(intf, typeof(Impl));
        }

        public void Remove<Intf>()
        {
            _diDict.Remove(typeof(Intf));
        }

        /// <summary>
        /// Лень заставила меня создавать класс с конструктором без параметров, поэтому... Товарищи! Создавайте дефолтные конструкторы!
        /// </summary>
        public object Get<Intf>()
        {
            var implType = _diDict[typeof(Intf)];
            if (implType == null)
                throw new Exception("Вот сложно было заинжектить сначала?");
            return Activator.CreateInstance(implType);
        }
    }
}
