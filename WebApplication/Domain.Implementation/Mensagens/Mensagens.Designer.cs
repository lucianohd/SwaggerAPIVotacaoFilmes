﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Implementation.Mensagens {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Mensagens {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Mensagens() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Implementation.Mensagens.Mensagens", typeof(Mensagens).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Campo {0} está nulo e é obrigatório.
        /// </summary>
        public static string MSG001 {
            get {
                return ResourceManager.GetString("MSG001", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Campo {0} excede o tamanho de caracteres maximo que é {1}.
        /// </summary>
        public static string MSG002 {
            get {
                return ResourceManager.GetString("MSG002", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Token Invalido.
        /// </summary>
        public static string MSG003 {
            get {
                return ResourceManager.GetString("MSG003", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Filme Não Registrado.
        /// </summary>
        public static string MSG004 {
            get {
                return ResourceManager.GetString("MSG004", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;Não existem usuarios nao administradores cadastrados&quot;.
        /// </summary>
        public static string MSG005 {
            get {
                return ResourceManager.GetString("MSG005", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;Validacao do {0} recusada&quot;.
        /// </summary>
        public static string MSG006 {
            get {
                return ResourceManager.GetString("MSG006", resourceCulture);
            }
        }
    }
}
