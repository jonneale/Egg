﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.312
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Facebook.Controls.Properties {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [DebuggerNonUserCode()]
    [CompilerGenerated()]
    internal class Resources {
        
        private static ResourceManager resourceMan;
        
        private static CultureInfo resourceCulture;
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager {
            get {
                if (ReferenceEquals(resourceMan, null)) {
                    ResourceManager temp = new ResourceManager("Facebook.Controls.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description.
        /// </summary>
        internal static string lblDescription {
            get {
                return ResourceManager.GetString("lblDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Employer.
        /// </summary>
        internal static string lblEmployer {
            get {
                return ResourceManager.GetString("lblEmployer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have {0} upcoming event{1}..
        /// </summary>
        internal static string lblEventCount {
            get {
                return ResourceManager.GetString("lblEventCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have {0} friend{1}..
        /// </summary>
        internal static string lblFriendCount {
            get {
                return ResourceManager.GetString("lblFriendCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} has {1} invited facebook user{2}.
        /// </summary>
        internal static string lblInvitees {
            get {
                return ResourceManager.GetString("lblInvitees", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Location.
        /// </summary>
        internal static string lblLocation {
            get {
                return ResourceManager.GetString("lblLocation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Position.
        /// </summary>
        internal static string lblPosition {
            get {
                return ResourceManager.GetString("lblPosition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time Period.
        /// </summary>
        internal static string lblTimePeriod {
            get {
                return ResourceManager.GetString("lblTimePeriod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;
        ///&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; &gt;
        ///&lt;head&gt;
        ///    &lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html; charset=utf-8&quot; /&gt;
        ///    &lt;style type=&quot;text/css&quot;&gt;
        ///        .nameClass
        ///        {
        ///            font-family:verdana;
        ///            color:blue;
        ///        }
        ///        .addressClass
        ///        {
        ///            font-family:verdana;
        ///            color:green;
        ///        }
        ///    &lt;/style&gt;
        ///    
        ///    &lt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MapPage {
            get {
                return ResourceManager.GetString("MapPage", resourceCulture);
            }
        }
        
        internal static Bitmap missingPicture {
            get {
                object obj = ResourceManager.GetObject("missingPicture", resourceCulture);
                return ((Bitmap)(obj));
            }
        }
    }
}
