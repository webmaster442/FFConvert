﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FFConvert.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FFConvert.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created config.xml. Set folder of ffmpeg and ffprobe before using. Now exiting..
        /// </summary>
        internal static string ConfigCreated {
            get {
                return ResourceManager.GetString("ConfigCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conversion aborted.
        /// </summary>
        internal static string ErrorAborted {
            get {
                return ResourceManager.GetString("ErrorAborted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Coudn&apos;t read the Presets.xml file. Probably it&apos;s not a valid xml.
        /// </summary>
        internal static string ErrorCoudNotLoadPresets {
            get {
                return ResourceManager.GetString("ErrorCoudNotLoadPresets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ffmpeg.exe not found in the following directory: {0}.
        /// </summary>
        internal static string ErrorFFmpegNotFound {
            get {
                return ResourceManager.GetString("ErrorFFmpegNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ffprobe.exe not found in the following directory: {0}.
        /// </summary>
        internal static string ErrorFFprobeNotFound {
            get {
                return ResourceManager.GetString("ErrorFFprobeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input file doesn&apos;t exist.
        /// </summary>
        internal static string ErrorFileNotExists {
            get {
                return ResourceManager.GetString("ErrorFileNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No input files found that match the given filter.
        /// </summary>
        internal static string ErrorFilesNotFound {
            get {
                return ResourceManager.GetString("ErrorFilesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The selected preset is not usable. It has missing parts in the definition..
        /// </summary>
        internal static string ErrorInvalidPreset {
            get {
                return ResourceManager.GetString("ErrorInvalidPreset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid value. Value must be one of the following: {0}.
        /// </summary>
        internal static string ErrorInvalidValue {
            get {
                return ResourceManager.GetString("ErrorInvalidValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid value. Value must be minimum {0} and maximum {1}.
        /// </summary>
        internal static string ErrorMinMaxRange {
            get {
                return ResourceManager.GetString("ErrorMinMaxRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The selected presets command line parameter count doesn&apos;t match the provided count. 
        ///This is a preset issue..
        /// </summary>
        internal static string ErrorParamCountMissmatch {
            get {
                return ResourceManager.GetString("ErrorParamCountMissmatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preset not found: {0}.
        /// </summary>
        internal static string ErrorPresetNotFound {
            get {
                return ResourceManager.GetString("ErrorPresetNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preset parameter validator string parameters  aren&apos;t valid. This is an issue in the XML..
        /// </summary>
        internal static string ErrorPresetParamTokens {
            get {
                return ResourceManager.GetString("ErrorPresetParamTokens", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Didn&apos;t find the presets.xml. Created a sample one..
        /// </summary>
        internal static string ErrorPresetsFileNotExists {
            get {
                return ResourceManager.GetString("ErrorPresetsFileNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown converter: {0}.
        /// </summary>
        internal static string ErrorUnknownConverter {
            get {
                return ResourceManager.GetString("ErrorUnknownConverter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown validator: {0}.
        /// </summary>
        internal static string ErrorUnknownValidator {
            get {
                return ResourceManager.GetString("ErrorUnknownValidator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FFConvert - an FfMpeg command line converter
        ///
        ///  Usage: ffconvert [inputfiles] [preset] [outdir]
        ///  Available presets: {0}.
        /// </summary>
        internal static string GenericHelp {
            get {
                return ResourceManager.GetString("GenericHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preset Name:       {0}
        ///Result extension:  {1}
        ///Description:       {2}.
        /// </summary>
        internal static string PresetHelpHeader {
            get {
                return ResourceManager.GetString("PresetHelpHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameters:.
        /// </summary>
        internal static string PresetHelpParameters {
            get {
                return ResourceManager.GetString("PresetHelpParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name:         {0}
        ///Description:  {1}
        ///Optional?:    {2}.
        /// </summary>
        internal static string PresetHelpParameterTemplate {
            get {
                return ResourceManager.GetString("PresetHelpParameterTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Speed: {0}x, Remaining time: {1}.
        /// </summary>
        internal static string StatusReportTemplate {
            get {
                return ResourceManager.GetString("StatusReportTemplate", resourceCulture);
            }
        }
    }
}
