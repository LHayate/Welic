using System;
using System.Collections.Generic;
using System.Reflection;

namespace UseFul.ClientApi
{
    public class Adaptador
    {
        public static TResult AdaptadorGeneric<TModel,TResult>(TModel model)
        {

            if (model == null)
            {
                return (TResult)Activator.CreateInstance(typeof(TResult), null);
            }
         
            //Getting Type of Generic Class Model
            Type tModelType = typeof(TModel);

            Type tResultType = typeof(TResult);

            //We will be defining a PropertyInfo Object which contains details about the class property 
            PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();


            PropertyInfo[] arrayPropertyInfosResult = tResultType.GetProperties();

            var result = typeof(TResult).DeclaringMethod;

            //Now we will loop in all properties one by one to get value
            foreach (PropertyInfo property in arrayPropertyInfos)
            {
                foreach (PropertyInfo propertyResult in arrayPropertyInfosResult)
                {
                    if (propertyResult.Name.Equals(property.Name))
                    {
                        propertyResult.SetValue(result,property.GetValue(model));
                    }
                }
            }           
            

            return (TResult) Activator.CreateInstance(typeof(TResult), result);
        }

        public static List<TResult> AdaptadorGeneric<TModel, TResult>(List<TModel> listModel) 
        {
            if (listModel == null)
            {
                return new List<TResult>();
            }

            List<TResult> listaResult = new List<TResult>();
         


            foreach (TModel item in listModel)
            {
                listaResult.Add(AdaptadorGeneric<TModel, TResult>(item));
            }
            return listaResult;
        }
    }
}
