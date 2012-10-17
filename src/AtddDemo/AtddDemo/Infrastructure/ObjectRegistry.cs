using System;
using System.Collections.Generic;
using AtddDemo.Main;
using AtddDemo.Settings;

namespace AtddDemo.Infrastructure
{
    public class ObjectRegistry
    {
        private static readonly IDictionary<Type, Type> Types = new Dictionary<Type, Type>();
        private static readonly IDictionary<Type, object> LatestCreatedObjects = new Dictionary<Type, object>();

        static ObjectRegistry()
        {
            Register<ISettingsView, SettingsWindow>();
            Register<IMainView, MainWindow>();
        }

        public static T GetLatestCreated<T>()
        {
            return (T)LatestCreatedObjects[typeof(T)];
        }

        public static T Create<T>()
        {
            Type concreteType = typeof(T);

            if (Types.ContainsKey(typeof(T)))
                concreteType = Types[typeof(T)];

            var instance = (T)Activator.CreateInstance(concreteType);

            LatestCreatedObjects[instance.GetType()] = instance;
            LatestCreatedObjects[typeof(T)] = instance;

            return instance;
        }

        public static void Register<TRequested, TConcrete>()
            where TConcrete : TRequested, new()
        {
            Types[typeof(TRequested)] = typeof(TConcrete);
        }
    }
}