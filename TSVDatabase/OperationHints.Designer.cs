﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSVDatabase {
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
    public class OperationHints {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OperationHints() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TSVDatabase.OperationHints", typeof(OperationHints).Assembly);
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
        ///   Looks up a localized string similar to Please enter record values separated by space.
        /// </summary>
        public static string Add___ask_for_record {
            get {
                return ResourceManager.GetString("Add - ask for record", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter row index.
        /// </summary>
        public static string Add___ask_for_row {
            get {
                return ResourceManager.GetString("Add - ask for row", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter row index (or leave empty for all rows).
        /// </summary>
        public static string Read___ask_for_nullable_int {
            get {
                return ResourceManager.GetString("Read - ask for nullable int", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter row index.
        /// </summary>
        public static string Remove___ask_for_row {
            get {
                return ResourceManager.GetString("Remove - ask for row", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter field value.
        /// </summary>
        public static string Update___ask_for_field_value {
            get {
                return ResourceManager.GetString("Update - ask for field value", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter row and column separated by space.
        /// </summary>
        public static string Update___ask_for_row_and_column {
            get {
                return ResourceManager.GetString("Update - ask for row and column", resourceCulture);
            }
        }
    }
}