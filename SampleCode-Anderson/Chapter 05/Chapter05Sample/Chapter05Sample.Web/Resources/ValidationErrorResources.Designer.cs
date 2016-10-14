﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chapter05Sample.Web.Resources {
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
    public class ValidationErrorResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationErrorResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Chapter05Sample.Web.Resources.ValidationErrorResources", typeof(ValidationErrorResources).Assembly);
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
        ///   Looks up a localized string similar to The friendly name cannot be more than 255 characters long.
        /// </summary>
        public static string ValidationErrorBadFriendlyNameLength {
            get {
                return ResourceManager.GetString("ValidationErrorBadFriendlyNameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must be at least 7 and at most 50 characters long.
        /// </summary>
        public static string ValidationErrorBadPasswordLength {
            get {
                return ResourceManager.GetString("ValidationErrorBadPasswordLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A password needs to contain at least one special character e.g. @ or #.
        /// </summary>
        public static string ValidationErrorBadPasswordStrength {
            get {
                return ResourceManager.GetString("ValidationErrorBadPasswordStrength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user name must be at least 4 and at most 255 characters long.
        /// </summary>
        public static string ValidationErrorBadUserNameLength {
            get {
                return ResourceManager.GetString("ValidationErrorBadUserNameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid email. An email must use the format user@company.com.
        /// </summary>
        public static string ValidationErrorInvalidEmail {
            get {
                return ResourceManager.GetString("ValidationErrorInvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid user name. It must contain only alphanumeric characters.
        /// </summary>
        public static string ValidationErrorInvalidUserName {
            get {
                return ResourceManager.GetString("ValidationErrorInvalidUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Passwords do not match.
        /// </summary>
        public static string ValidationErrorPasswordConfirmationMismatch {
            get {
                return ResourceManager.GetString("ValidationErrorPasswordConfirmationMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field is required.
        /// </summary>
        public static string ValidationErrorRequiredField {
            get {
                return ResourceManager.GetString("ValidationErrorRequiredField", resourceCulture);
            }
        }
    }
}
