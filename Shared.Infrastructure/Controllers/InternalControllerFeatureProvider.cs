using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Controllers
{
    /// <summary>
    /// Classe responsável por adicionar controllers que estão em projetos diferentes.
    /// Essa classe deve ser registrada em um container de serviço do HOST
    /// </summary>
    internal class InternalControllerFeatureProvider: ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            if (!typeInfo.IsClass)         
                return false;
            
            if(typeInfo.IsAbstract)
                return false;

            if (typeInfo.ContainsGenericParameters)
                return false;

            if (typeInfo.IsDefined(typeof(NonControllerAttribute)))
                return false;


            return typeInfo.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) ||
                typeInfo.IsDefined(typeof(ControllerAttribute));
        }
    }
}
