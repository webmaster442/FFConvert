namespace FFConvert.FFProbe
{
    using System;
    using System.Collections.Generic;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("ffprobe", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    [System.Xml.Serialization.XmlRootAttribute("ffprobe", Namespace="http://www.ffmpeg.org/schema/ffprobe", IsNullable=false)]
    public partial class FfprobeType
    {
        
        private ProgramVersionType program_versionField;
        
        private LibraryVersionType[] library_versionsField;
        
        private PixelFormatType[] pixel_formatsField;
        
        private PacketType[] packetsField;
        
        private object[] framesField;
        
        private object[] packets_and_framesField;
        
        private ProgramType[] programsField;
        
        private StreamType[] streamsField;
        
        private ChapterType[] chaptersField;
        
        private FormatType formatField;
        
        private ErrorType errorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ProgramVersionType program_version
        {
            get
            {
                return this.program_versionField;
            }
            set
            {
                this.program_versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("library_version", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public LibraryVersionType[] library_versions
        {
            get
            {
                return this.library_versionsField;
            }
            set
            {
                this.library_versionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("pixel_format", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public PixelFormatType[] pixel_formats
        {
            get
            {
                return this.pixel_formatsField;
            }
            set
            {
                this.pixel_formatsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("packet", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public PacketType[] packets
        {
            get
            {
                return this.packetsField;
            }
            set
            {
                this.packetsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("frame", typeof(FrameType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("subtitle", typeof(SubtitleType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public object[] frames
        {
            get
            {
                return this.framesField;
            }
            set
            {
                this.framesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("frame", typeof(FrameType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("packet", typeof(PacketType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("subtitle", typeof(SubtitleType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public object[] packets_and_frames
        {
            get
            {
                return this.packets_and_framesField;
            }
            set
            {
                this.packets_and_framesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("program", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ProgramType[] programs
        {
            get
            {
                return this.programsField;
            }
            set
            {
                this.programsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("stream", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public StreamType[] streams
        {
            get
            {
                return this.streamsField;
            }
            set
            {
                this.streamsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("chapter", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ChapterType[] chapters
        {
            get
            {
                return this.chaptersField;
            }
            set
            {
                this.chaptersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FormatType format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ErrorType error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("programVersionType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class ProgramVersionType
    {
        
        private string versionField;
        
        private string copyrightField;
        
        private string build_dateField;
        
        private string build_timeField;
        
        private string compiler_identField;
        
        private string configurationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string copyright
        {
            get
            {
                return this.copyrightField;
            }
            set
            {
                this.copyrightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string build_date
        {
            get
            {
                return this.build_dateField;
            }
            set
            {
                this.build_dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string build_time
        {
            get
            {
                return this.build_timeField;
            }
            set
            {
                this.build_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string compiler_ident
        {
            get
            {
                return this.compiler_identField;
            }
            set
            {
                this.compiler_identField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string configuration
        {
            get
            {
                return this.configurationField;
            }
            set
            {
                this.configurationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("libraryVersionType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class LibraryVersionType
    {
        
        private string nameField;
        
        private int majorField;
        
        private int minorField;
        
        private int microField;
        
        private int versionField;
        
        private string identField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int major
        {
            get
            {
                return this.majorField;
            }
            set
            {
                this.majorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int minor
        {
            get
            {
                return this.minorField;
            }
            set
            {
                this.minorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int micro
        {
            get
            {
                return this.microField;
            }
            set
            {
                this.microField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ident
        {
            get
            {
                return this.identField;
            }
            set
            {
                this.identField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("pixelFormatType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PixelFormatType
    {
        
        private PixelFormatFlagsType flagsField;
        
        private PixelFormatComponentType[] componentsField;
        
        private string nameField;
        
        private int nb_componentsField;
        
        private int log2_chroma_wField;
        
        private bool log2_chroma_wFieldSpecified;
        
        private int log2_chroma_hField;
        
        private bool log2_chroma_hFieldSpecified;
        
        private int bits_per_pixelField;
        
        private bool bits_per_pixelFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PixelFormatFlagsType flags
        {
            get
            {
                return this.flagsField;
            }
            set
            {
                this.flagsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("component", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public PixelFormatComponentType[] components
        {
            get
            {
                return this.componentsField;
            }
            set
            {
                this.componentsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int nb_components
        {
            get
            {
                return this.nb_componentsField;
            }
            set
            {
                this.nb_componentsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="log2_chroma_w")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _log2_chroma_w
        {
            get
            {
                return this.log2_chroma_wField;
            }
            set
            {
                this.log2_chroma_wField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _log2_chroma_wSpecified
        {
            get
            {
                return this.log2_chroma_wFieldSpecified;
            }
            set
            {
                this.log2_chroma_wFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="log2_chroma_h")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _log2_chroma_h
        {
            get
            {
                return this.log2_chroma_hField;
            }
            set
            {
                this.log2_chroma_hField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _log2_chroma_hSpecified
        {
            get
            {
                return this.log2_chroma_hFieldSpecified;
            }
            set
            {
                this.log2_chroma_hFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="bits_per_pixel")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _bits_per_pixel
        {
            get
            {
                return this.bits_per_pixelField;
            }
            set
            {
                this.bits_per_pixelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _bits_per_pixelSpecified
        {
            get
            {
                return this.bits_per_pixelFieldSpecified;
            }
            set
            {
                this.bits_per_pixelFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> log2_chroma_w
        {
            get
            {
                if (log2_chroma_wFieldSpecified)
                {
                    return log2_chroma_wField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    log2_chroma_wFieldSpecified = true;
                    log2_chroma_wField = value.Value;
                }
                else
                {
                    log2_chroma_wFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> log2_chroma_h
        {
            get
            {
                if (log2_chroma_hFieldSpecified)
                {
                    return log2_chroma_hField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    log2_chroma_hFieldSpecified = true;
                    log2_chroma_hField = value.Value;
                }
                else
                {
                    log2_chroma_hFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> bits_per_pixel
        {
            get
            {
                if (bits_per_pixelFieldSpecified)
                {
                    return bits_per_pixelField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    bits_per_pixelFieldSpecified = true;
                    bits_per_pixelField = value.Value;
                }
                else
                {
                    bits_per_pixelFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("pixelFormatFlagsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PixelFormatFlagsType
    {
        
        private int big_endianField;
        
        private int paletteField;
        
        private int bitstreamField;
        
        private int hwaccelField;
        
        private int planarField;
        
        private int rgbField;
        
        private int alphaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int big_endian
        {
            get
            {
                return this.big_endianField;
            }
            set
            {
                this.big_endianField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int palette
        {
            get
            {
                return this.paletteField;
            }
            set
            {
                this.paletteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int bitstream
        {
            get
            {
                return this.bitstreamField;
            }
            set
            {
                this.bitstreamField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int hwaccel
        {
            get
            {
                return this.hwaccelField;
            }
            set
            {
                this.hwaccelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int planar
        {
            get
            {
                return this.planarField;
            }
            set
            {
                this.planarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int rgb
        {
            get
            {
                return this.rgbField;
            }
            set
            {
                this.rgbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int alpha
        {
            get
            {
                return this.alphaField;
            }
            set
            {
                this.alphaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("pixelFormatComponentType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PixelFormatComponentType
    {
        
        private int indexField;
        
        private int bit_depthField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int bit_depth
        {
            get
            {
                return this.bit_depthField;
            }
            set
            {
                this.bit_depthField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("packetType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PacketType
    {
        
        private TagType[] tagField;
        
        private PacketSideDataType[] side_data_listField;
        
        private string codec_typeField;
        
        private int stream_indexField;
        
        private long ptsField;
        
        private bool ptsFieldSpecified;
        
        private float pts_timeField;
        
        private bool pts_timeFieldSpecified;
        
        private long dtsField;
        
        private bool dtsFieldSpecified;
        
        private float dts_timeField;
        
        private bool dts_timeFieldSpecified;
        
        private long durationField;
        
        private bool durationFieldSpecified;
        
        private float duration_timeField;
        
        private bool duration_timeFieldSpecified;
        
        private long sizeField;
        
        private long posField;
        
        private bool posFieldSpecified;
        
        private string flagsField;
        
        private string dataField;
        
        private string data_hashField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TagType[] tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("side_data", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public PacketSideDataType[] side_data_list
        {
            get
            {
                return this.side_data_listField;
            }
            set
            {
                this.side_data_listField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec_type
        {
            get
            {
                return this.codec_typeField;
            }
            set
            {
                this.codec_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int stream_index
        {
            get
            {
                return this.stream_indexField;
            }
            set
            {
                this.stream_indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pts
        {
            get
            {
                return this.ptsField;
            }
            set
            {
                this.ptsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _ptsSpecified
        {
            get
            {
                return this.ptsFieldSpecified;
            }
            set
            {
                this.ptsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pts_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _pts_time
        {
            get
            {
                return this.pts_timeField;
            }
            set
            {
                this.pts_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pts_timeSpecified
        {
            get
            {
                return this.pts_timeFieldSpecified;
            }
            set
            {
                this.pts_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="dts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _dts
        {
            get
            {
                return this.dtsField;
            }
            set
            {
                this.dtsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _dtsSpecified
        {
            get
            {
                return this.dtsFieldSpecified;
            }
            set
            {
                this.dtsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="dts_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _dts_time
        {
            get
            {
                return this.dts_timeField;
            }
            set
            {
                this.dts_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _dts_timeSpecified
        {
            get
            {
                return this.dts_timeFieldSpecified;
            }
            set
            {
                this.dts_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="duration")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _durationSpecified
        {
            get
            {
                return this.durationFieldSpecified;
            }
            set
            {
                this.durationFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="duration_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _duration_time
        {
            get
            {
                return this.duration_timeField;
            }
            set
            {
                this.duration_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _duration_timeSpecified
        {
            get
            {
                return this.duration_timeFieldSpecified;
            }
            set
            {
                this.duration_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pos")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pos
        {
            get
            {
                return this.posField;
            }
            set
            {
                this.posField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _posSpecified
        {
            get
            {
                return this.posFieldSpecified;
            }
            set
            {
                this.posFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string flags
        {
            get
            {
                return this.flagsField;
            }
            set
            {
                this.flagsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string data_hash
        {
            get
            {
                return this.data_hashField;
            }
            set
            {
                this.data_hashField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pts
        {
            get
            {
                if (ptsFieldSpecified)
                {
                    return ptsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    ptsFieldSpecified = true;
                    ptsField = value.Value;
                }
                else
                {
                    ptsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> pts_time
        {
            get
            {
                if (pts_timeFieldSpecified)
                {
                    return pts_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pts_timeFieldSpecified = true;
                    pts_timeField = value.Value;
                }
                else
                {
                    pts_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> dts
        {
            get
            {
                if (dtsFieldSpecified)
                {
                    return dtsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    dtsFieldSpecified = true;
                    dtsField = value.Value;
                }
                else
                {
                    dtsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> dts_time
        {
            get
            {
                if (dts_timeFieldSpecified)
                {
                    return dts_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    dts_timeFieldSpecified = true;
                    dts_timeField = value.Value;
                }
                else
                {
                    dts_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> duration
        {
            get
            {
                if (durationFieldSpecified)
                {
                    return durationField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    durationFieldSpecified = true;
                    durationField = value.Value;
                }
                else
                {
                    durationFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> duration_time
        {
            get
            {
                if (duration_timeFieldSpecified)
                {
                    return duration_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    duration_timeFieldSpecified = true;
                    duration_timeField = value.Value;
                }
                else
                {
                    duration_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pos
        {
            get
            {
                if (posFieldSpecified)
                {
                    return posField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    posFieldSpecified = true;
                    posField = value.Value;
                }
                else
                {
                    posFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("tagType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class TagType
    {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("packetSideDataType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PacketSideDataType
    {
        
        private string side_data_typeField;
        
        private int side_data_sizeField;
        
        private bool side_data_sizeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string side_data_type
        {
            get
            {
                return this.side_data_typeField;
            }
            set
            {
                this.side_data_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="side_data_size")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _side_data_size
        {
            get
            {
                return this.side_data_sizeField;
            }
            set
            {
                this.side_data_sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _side_data_sizeSpecified
        {
            get
            {
                return this.side_data_sizeFieldSpecified;
            }
            set
            {
                this.side_data_sizeFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> side_data_size
        {
            get
            {
                if (side_data_sizeFieldSpecified)
                {
                    return side_data_sizeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    side_data_sizeFieldSpecified = true;
                    side_data_sizeField = value.Value;
                }
                else
                {
                    side_data_sizeFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("frameType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FrameType
    {
        
        private TagType[] tagField;
        
        private LogType[] logsField;
        
        private FrameSideDataType[] side_data_listField;
        
        private string media_typeField;
        
        private int stream_indexField;
        
        private bool stream_indexFieldSpecified;
        
        private int key_frameField;
        
        private long ptsField;
        
        private bool ptsFieldSpecified;
        
        private float pts_timeField;
        
        private bool pts_timeFieldSpecified;
        
        private long pkt_dtsField;
        
        private bool pkt_dtsFieldSpecified;
        
        private float pkt_dts_timeField;
        
        private bool pkt_dts_timeFieldSpecified;
        
        private long best_effort_timestampField;
        
        private bool best_effort_timestampFieldSpecified;
        
        private float best_effort_timestamp_timeField;
        
        private bool best_effort_timestamp_timeFieldSpecified;
        
        private long pkt_durationField;
        
        private bool pkt_durationFieldSpecified;
        
        private float pkt_duration_timeField;
        
        private bool pkt_duration_timeFieldSpecified;
        
        private long pkt_posField;
        
        private bool pkt_posFieldSpecified;
        
        private int pkt_sizeField;
        
        private bool pkt_sizeFieldSpecified;
        
        private string sample_fmtField;
        
        private long nb_samplesField;
        
        private bool nb_samplesFieldSpecified;
        
        private int channelsField;
        
        private bool channelsFieldSpecified;
        
        private string channel_layoutField;
        
        private long widthField;
        
        private bool widthFieldSpecified;
        
        private long heightField;
        
        private bool heightFieldSpecified;
        
        private string pix_fmtField;
        
        private string sample_aspect_ratioField;
        
        private string pict_typeField;
        
        private long coded_picture_numberField;
        
        private bool coded_picture_numberFieldSpecified;
        
        private long display_picture_numberField;
        
        private bool display_picture_numberFieldSpecified;
        
        private int interlaced_frameField;
        
        private bool interlaced_frameFieldSpecified;
        
        private int top_field_firstField;
        
        private bool top_field_firstFieldSpecified;
        
        private int repeat_pictField;
        
        private bool repeat_pictFieldSpecified;
        
        private string color_rangeField;
        
        private string color_spaceField;
        
        private string color_primariesField;
        
        private string color_transferField;
        
        private string chroma_locationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TagType[] tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("log", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public LogType[] logs
        {
            get
            {
                return this.logsField;
            }
            set
            {
                this.logsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("side_data", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public FrameSideDataType[] side_data_list
        {
            get
            {
                return this.side_data_listField;
            }
            set
            {
                this.side_data_listField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string media_type
        {
            get
            {
                return this.media_typeField;
            }
            set
            {
                this.media_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="stream_index")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _stream_index
        {
            get
            {
                return this.stream_indexField;
            }
            set
            {
                this.stream_indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _stream_indexSpecified
        {
            get
            {
                return this.stream_indexFieldSpecified;
            }
            set
            {
                this.stream_indexFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int key_frame
        {
            get
            {
                return this.key_frameField;
            }
            set
            {
                this.key_frameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pts
        {
            get
            {
                return this.ptsField;
            }
            set
            {
                this.ptsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _ptsSpecified
        {
            get
            {
                return this.ptsFieldSpecified;
            }
            set
            {
                this.ptsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pts_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _pts_time
        {
            get
            {
                return this.pts_timeField;
            }
            set
            {
                this.pts_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pts_timeSpecified
        {
            get
            {
                return this.pts_timeFieldSpecified;
            }
            set
            {
                this.pts_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pkt_dts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pkt_dts
        {
            get
            {
                return this.pkt_dtsField;
            }
            set
            {
                this.pkt_dtsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pkt_dtsSpecified
        {
            get
            {
                return this.pkt_dtsFieldSpecified;
            }
            set
            {
                this.pkt_dtsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pkt_dts_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _pkt_dts_time
        {
            get
            {
                return this.pkt_dts_timeField;
            }
            set
            {
                this.pkt_dts_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pkt_dts_timeSpecified
        {
            get
            {
                return this.pkt_dts_timeFieldSpecified;
            }
            set
            {
                this.pkt_dts_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="best_effort_timestamp")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _best_effort_timestamp
        {
            get
            {
                return this.best_effort_timestampField;
            }
            set
            {
                this.best_effort_timestampField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _best_effort_timestampSpecified
        {
            get
            {
                return this.best_effort_timestampFieldSpecified;
            }
            set
            {
                this.best_effort_timestampFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="best_effort_timestamp_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _best_effort_timestamp_time
        {
            get
            {
                return this.best_effort_timestamp_timeField;
            }
            set
            {
                this.best_effort_timestamp_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _best_effort_timestamp_timeSpecified
        {
            get
            {
                return this.best_effort_timestamp_timeFieldSpecified;
            }
            set
            {
                this.best_effort_timestamp_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pkt_duration")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pkt_duration
        {
            get
            {
                return this.pkt_durationField;
            }
            set
            {
                this.pkt_durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pkt_durationSpecified
        {
            get
            {
                return this.pkt_durationFieldSpecified;
            }
            set
            {
                this.pkt_durationFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pkt_duration_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _pkt_duration_time
        {
            get
            {
                return this.pkt_duration_timeField;
            }
            set
            {
                this.pkt_duration_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pkt_duration_timeSpecified
        {
            get
            {
                return this.pkt_duration_timeFieldSpecified;
            }
            set
            {
                this.pkt_duration_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pkt_pos")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pkt_pos
        {
            get
            {
                return this.pkt_posField;
            }
            set
            {
                this.pkt_posField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pkt_posSpecified
        {
            get
            {
                return this.pkt_posFieldSpecified;
            }
            set
            {
                this.pkt_posFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pkt_size")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _pkt_size
        {
            get
            {
                return this.pkt_sizeField;
            }
            set
            {
                this.pkt_sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pkt_sizeSpecified
        {
            get
            {
                return this.pkt_sizeFieldSpecified;
            }
            set
            {
                this.pkt_sizeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sample_fmt
        {
            get
            {
                return this.sample_fmtField;
            }
            set
            {
                this.sample_fmtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="nb_samples")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _nb_samples
        {
            get
            {
                return this.nb_samplesField;
            }
            set
            {
                this.nb_samplesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _nb_samplesSpecified
        {
            get
            {
                return this.nb_samplesFieldSpecified;
            }
            set
            {
                this.nb_samplesFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="channels")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _channels
        {
            get
            {
                return this.channelsField;
            }
            set
            {
                this.channelsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _channelsSpecified
        {
            get
            {
                return this.channelsFieldSpecified;
            }
            set
            {
                this.channelsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string channel_layout
        {
            get
            {
                return this.channel_layoutField;
            }
            set
            {
                this.channel_layoutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="width")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _widthSpecified
        {
            get
            {
                return this.widthFieldSpecified;
            }
            set
            {
                this.widthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="height")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _heightSpecified
        {
            get
            {
                return this.heightFieldSpecified;
            }
            set
            {
                this.heightFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pix_fmt
        {
            get
            {
                return this.pix_fmtField;
            }
            set
            {
                this.pix_fmtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sample_aspect_ratio
        {
            get
            {
                return this.sample_aspect_ratioField;
            }
            set
            {
                this.sample_aspect_ratioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pict_type
        {
            get
            {
                return this.pict_typeField;
            }
            set
            {
                this.pict_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="coded_picture_number")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _coded_picture_number
        {
            get
            {
                return this.coded_picture_numberField;
            }
            set
            {
                this.coded_picture_numberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _coded_picture_numberSpecified
        {
            get
            {
                return this.coded_picture_numberFieldSpecified;
            }
            set
            {
                this.coded_picture_numberFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="display_picture_number")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _display_picture_number
        {
            get
            {
                return this.display_picture_numberField;
            }
            set
            {
                this.display_picture_numberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _display_picture_numberSpecified
        {
            get
            {
                return this.display_picture_numberFieldSpecified;
            }
            set
            {
                this.display_picture_numberFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="interlaced_frame")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _interlaced_frame
        {
            get
            {
                return this.interlaced_frameField;
            }
            set
            {
                this.interlaced_frameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _interlaced_frameSpecified
        {
            get
            {
                return this.interlaced_frameFieldSpecified;
            }
            set
            {
                this.interlaced_frameFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="top_field_first")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _top_field_first
        {
            get
            {
                return this.top_field_firstField;
            }
            set
            {
                this.top_field_firstField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _top_field_firstSpecified
        {
            get
            {
                return this.top_field_firstFieldSpecified;
            }
            set
            {
                this.top_field_firstFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="repeat_pict")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _repeat_pict
        {
            get
            {
                return this.repeat_pictField;
            }
            set
            {
                this.repeat_pictField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _repeat_pictSpecified
        {
            get
            {
                return this.repeat_pictFieldSpecified;
            }
            set
            {
                this.repeat_pictFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_range
        {
            get
            {
                return this.color_rangeField;
            }
            set
            {
                this.color_rangeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_space
        {
            get
            {
                return this.color_spaceField;
            }
            set
            {
                this.color_spaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_primaries
        {
            get
            {
                return this.color_primariesField;
            }
            set
            {
                this.color_primariesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_transfer
        {
            get
            {
                return this.color_transferField;
            }
            set
            {
                this.color_transferField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string chroma_location
        {
            get
            {
                return this.chroma_locationField;
            }
            set
            {
                this.chroma_locationField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> stream_index
        {
            get
            {
                if (stream_indexFieldSpecified)
                {
                    return stream_indexField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    stream_indexFieldSpecified = true;
                    stream_indexField = value.Value;
                }
                else
                {
                    stream_indexFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pts
        {
            get
            {
                if (ptsFieldSpecified)
                {
                    return ptsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    ptsFieldSpecified = true;
                    ptsField = value.Value;
                }
                else
                {
                    ptsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> pts_time
        {
            get
            {
                if (pts_timeFieldSpecified)
                {
                    return pts_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pts_timeFieldSpecified = true;
                    pts_timeField = value.Value;
                }
                else
                {
                    pts_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pkt_dts
        {
            get
            {
                if (pkt_dtsFieldSpecified)
                {
                    return pkt_dtsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pkt_dtsFieldSpecified = true;
                    pkt_dtsField = value.Value;
                }
                else
                {
                    pkt_dtsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> pkt_dts_time
        {
            get
            {
                if (pkt_dts_timeFieldSpecified)
                {
                    return pkt_dts_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pkt_dts_timeFieldSpecified = true;
                    pkt_dts_timeField = value.Value;
                }
                else
                {
                    pkt_dts_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> best_effort_timestamp
        {
            get
            {
                if (best_effort_timestampFieldSpecified)
                {
                    return best_effort_timestampField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    best_effort_timestampFieldSpecified = true;
                    best_effort_timestampField = value.Value;
                }
                else
                {
                    best_effort_timestampFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> best_effort_timestamp_time
        {
            get
            {
                if (best_effort_timestamp_timeFieldSpecified)
                {
                    return best_effort_timestamp_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    best_effort_timestamp_timeFieldSpecified = true;
                    best_effort_timestamp_timeField = value.Value;
                }
                else
                {
                    best_effort_timestamp_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pkt_duration
        {
            get
            {
                if (pkt_durationFieldSpecified)
                {
                    return pkt_durationField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pkt_durationFieldSpecified = true;
                    pkt_durationField = value.Value;
                }
                else
                {
                    pkt_durationFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> pkt_duration_time
        {
            get
            {
                if (pkt_duration_timeFieldSpecified)
                {
                    return pkt_duration_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pkt_duration_timeFieldSpecified = true;
                    pkt_duration_timeField = value.Value;
                }
                else
                {
                    pkt_duration_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pkt_pos
        {
            get
            {
                if (pkt_posFieldSpecified)
                {
                    return pkt_posField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pkt_posFieldSpecified = true;
                    pkt_posField = value.Value;
                }
                else
                {
                    pkt_posFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> pkt_size
        {
            get
            {
                if (pkt_sizeFieldSpecified)
                {
                    return pkt_sizeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pkt_sizeFieldSpecified = true;
                    pkt_sizeField = value.Value;
                }
                else
                {
                    pkt_sizeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> nb_samples
        {
            get
            {
                if (nb_samplesFieldSpecified)
                {
                    return nb_samplesField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    nb_samplesFieldSpecified = true;
                    nb_samplesField = value.Value;
                }
                else
                {
                    nb_samplesFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> channels
        {
            get
            {
                if (channelsFieldSpecified)
                {
                    return channelsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    channelsFieldSpecified = true;
                    channelsField = value.Value;
                }
                else
                {
                    channelsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> width
        {
            get
            {
                if (widthFieldSpecified)
                {
                    return widthField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    widthFieldSpecified = true;
                    widthField = value.Value;
                }
                else
                {
                    widthFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> height
        {
            get
            {
                if (heightFieldSpecified)
                {
                    return heightField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    heightFieldSpecified = true;
                    heightField = value.Value;
                }
                else
                {
                    heightFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> coded_picture_number
        {
            get
            {
                if (coded_picture_numberFieldSpecified)
                {
                    return coded_picture_numberField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    coded_picture_numberFieldSpecified = true;
                    coded_picture_numberField = value.Value;
                }
                else
                {
                    coded_picture_numberFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> display_picture_number
        {
            get
            {
                if (display_picture_numberFieldSpecified)
                {
                    return display_picture_numberField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    display_picture_numberFieldSpecified = true;
                    display_picture_numberField = value.Value;
                }
                else
                {
                    display_picture_numberFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> interlaced_frame
        {
            get
            {
                if (interlaced_frameFieldSpecified)
                {
                    return interlaced_frameField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    interlaced_frameFieldSpecified = true;
                    interlaced_frameField = value.Value;
                }
                else
                {
                    interlaced_frameFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> top_field_first
        {
            get
            {
                if (top_field_firstFieldSpecified)
                {
                    return top_field_firstField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    top_field_firstFieldSpecified = true;
                    top_field_firstField = value.Value;
                }
                else
                {
                    top_field_firstFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> repeat_pict
        {
            get
            {
                if (repeat_pictFieldSpecified)
                {
                    return repeat_pictField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    repeat_pictFieldSpecified = true;
                    repeat_pictField = value.Value;
                }
                else
                {
                    repeat_pictFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("logType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class LogType
    {
        
        private string contextField;
        
        private int levelField;
        
        private bool levelFieldSpecified;
        
        private int categoryField;
        
        private bool categoryFieldSpecified;
        
        private string parent_contextField;
        
        private int parent_categoryField;
        
        private bool parent_categoryFieldSpecified;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string context
        {
            get
            {
                return this.contextField;
            }
            set
            {
                this.contextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="level")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _levelSpecified
        {
            get
            {
                return this.levelFieldSpecified;
            }
            set
            {
                this.levelFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="category")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _categorySpecified
        {
            get
            {
                return this.categoryFieldSpecified;
            }
            set
            {
                this.categoryFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parent_context
        {
            get
            {
                return this.parent_contextField;
            }
            set
            {
                this.parent_contextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="parent_category")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _parent_category
        {
            get
            {
                return this.parent_categoryField;
            }
            set
            {
                this.parent_categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _parent_categorySpecified
        {
            get
            {
                return this.parent_categoryFieldSpecified;
            }
            set
            {
                this.parent_categoryFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> level
        {
            get
            {
                if (levelFieldSpecified)
                {
                    return levelField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    levelFieldSpecified = true;
                    levelField = value.Value;
                }
                else
                {
                    levelFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> category
        {
            get
            {
                if (categoryFieldSpecified)
                {
                    return categoryField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    categoryFieldSpecified = true;
                    categoryField = value.Value;
                }
                else
                {
                    categoryFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> parent_category
        {
            get
            {
                if (parent_categoryFieldSpecified)
                {
                    return parent_categoryField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    parent_categoryFieldSpecified = true;
                    parent_categoryField = value.Value;
                }
                else
                {
                    parent_categoryFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("frameSideDataType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FrameSideDataType
    {
        
        private FrameSideDataTimecodeType[] timecodesField;
        
        private string side_data_typeField;
        
        private int side_data_sizeField;
        
        private bool side_data_sizeFieldSpecified;
        
        private string timecodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("timecode", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public FrameSideDataTimecodeType[] timecodes
        {
            get
            {
                return this.timecodesField;
            }
            set
            {
                this.timecodesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string side_data_type
        {
            get
            {
                return this.side_data_typeField;
            }
            set
            {
                this.side_data_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="side_data_size")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _side_data_size
        {
            get
            {
                return this.side_data_sizeField;
            }
            set
            {
                this.side_data_sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _side_data_sizeSpecified
        {
            get
            {
                return this.side_data_sizeFieldSpecified;
            }
            set
            {
                this.side_data_sizeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timecode
        {
            get
            {
                return this.timecodeField;
            }
            set
            {
                this.timecodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> side_data_size
        {
            get
            {
                if (side_data_sizeFieldSpecified)
                {
                    return side_data_sizeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    side_data_sizeFieldSpecified = true;
                    side_data_sizeField = value.Value;
                }
                else
                {
                    side_data_sizeFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("frameSideDataTimecodeType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FrameSideDataTimecodeType
    {
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("subtitleType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class SubtitleType
    {
        
        private string media_typeField;
        
        private long ptsField;
        
        private bool ptsFieldSpecified;
        
        private float pts_timeField;
        
        private bool pts_timeFieldSpecified;
        
        private int formatField;
        
        private bool formatFieldSpecified;
        
        private int start_display_timeField;
        
        private bool start_display_timeFieldSpecified;
        
        private int end_display_timeField;
        
        private bool end_display_timeFieldSpecified;
        
        private int num_rectsField;
        
        private bool num_rectsFieldSpecified;
        
        public SubtitleType()
        {
            this.media_typeField = "subtitle";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string media_type
        {
            get
            {
                return this.media_typeField;
            }
            set
            {
                this.media_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _pts
        {
            get
            {
                return this.ptsField;
            }
            set
            {
                this.ptsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _ptsSpecified
        {
            get
            {
                return this.ptsFieldSpecified;
            }
            set
            {
                this.ptsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="pts_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _pts_time
        {
            get
            {
                return this.pts_timeField;
            }
            set
            {
                this.pts_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _pts_timeSpecified
        {
            get
            {
                return this.pts_timeFieldSpecified;
            }
            set
            {
                this.pts_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="format")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _formatSpecified
        {
            get
            {
                return this.formatFieldSpecified;
            }
            set
            {
                this.formatFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="start_display_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _start_display_time
        {
            get
            {
                return this.start_display_timeField;
            }
            set
            {
                this.start_display_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _start_display_timeSpecified
        {
            get
            {
                return this.start_display_timeFieldSpecified;
            }
            set
            {
                this.start_display_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="end_display_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _end_display_time
        {
            get
            {
                return this.end_display_timeField;
            }
            set
            {
                this.end_display_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _end_display_timeSpecified
        {
            get
            {
                return this.end_display_timeFieldSpecified;
            }
            set
            {
                this.end_display_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="num_rects")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _num_rects
        {
            get
            {
                return this.num_rectsField;
            }
            set
            {
                this.num_rectsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _num_rectsSpecified
        {
            get
            {
                return this.num_rectsFieldSpecified;
            }
            set
            {
                this.num_rectsFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> pts
        {
            get
            {
                if (ptsFieldSpecified)
                {
                    return ptsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    ptsFieldSpecified = true;
                    ptsField = value.Value;
                }
                else
                {
                    ptsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> pts_time
        {
            get
            {
                if (pts_timeFieldSpecified)
                {
                    return pts_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    pts_timeFieldSpecified = true;
                    pts_timeField = value.Value;
                }
                else
                {
                    pts_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> format
        {
            get
            {
                if (formatFieldSpecified)
                {
                    return formatField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    formatFieldSpecified = true;
                    formatField = value.Value;
                }
                else
                {
                    formatFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> start_display_time
        {
            get
            {
                if (start_display_timeFieldSpecified)
                {
                    return start_display_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    start_display_timeFieldSpecified = true;
                    start_display_timeField = value.Value;
                }
                else
                {
                    start_display_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> end_display_time
        {
            get
            {
                if (end_display_timeFieldSpecified)
                {
                    return end_display_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    end_display_timeFieldSpecified = true;
                    end_display_timeField = value.Value;
                }
                else
                {
                    end_display_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> num_rects
        {
            get
            {
                if (num_rectsFieldSpecified)
                {
                    return num_rectsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    num_rectsFieldSpecified = true;
                    num_rectsField = value.Value;
                }
                else
                {
                    num_rectsFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("programType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class ProgramType
    {
        
        private TagType[] tagField;
        
        private StreamType[] streamsField;
        
        private int program_idField;
        
        private int program_numField;
        
        private int nb_streamsField;
        
        private int pmt_pidField;
        
        private int pcr_pidField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TagType[] tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("stream", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public StreamType[] streams
        {
            get
            {
                return this.streamsField;
            }
            set
            {
                this.streamsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int program_id
        {
            get
            {
                return this.program_idField;
            }
            set
            {
                this.program_idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int program_num
        {
            get
            {
                return this.program_numField;
            }
            set
            {
                this.program_numField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int nb_streams
        {
            get
            {
                return this.nb_streamsField;
            }
            set
            {
                this.nb_streamsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pmt_pid
        {
            get
            {
                return this.pmt_pidField;
            }
            set
            {
                this.pmt_pidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pcr_pid
        {
            get
            {
                return this.pcr_pidField;
            }
            set
            {
                this.pcr_pidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("streamType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class StreamType
    {
        
        private StreamDispositionType dispositionField;
        
        private TagType[] tagField;
        
        private PacketSideDataType[] side_data_listField;
        
        private int indexField;
        
        private string codec_nameField;
        
        private string codec_long_nameField;
        
        private string profileField;
        
        private string codec_typeField;
        
        private string codec_tagField;
        
        private string codec_tag_stringField;
        
        private string extradataField;
        
        private int extradata_sizeField;
        
        private bool extradata_sizeFieldSpecified;
        
        private string extradata_hashField;
        
        private int widthField;
        
        private bool widthFieldSpecified;
        
        private int heightField;
        
        private bool heightFieldSpecified;
        
        private int coded_widthField;
        
        private bool coded_widthFieldSpecified;
        
        private int coded_heightField;
        
        private bool coded_heightFieldSpecified;
        
        private bool closed_captionsField;
        
        private bool closed_captionsFieldSpecified;
        
        private bool film_grainField;
        
        private bool film_grainFieldSpecified;
        
        private int has_b_framesField;
        
        private bool has_b_framesFieldSpecified;
        
        private string sample_aspect_ratioField;
        
        private string display_aspect_ratioField;
        
        private string pix_fmtField;
        
        private int levelField;
        
        private bool levelFieldSpecified;
        
        private string color_rangeField;
        
        private string color_spaceField;
        
        private string color_transferField;
        
        private string color_primariesField;
        
        private string chroma_locationField;
        
        private string field_orderField;
        
        private int refsField;
        
        private bool refsFieldSpecified;
        
        private string sample_fmtField;
        
        private int sample_rateField;
        
        private bool sample_rateFieldSpecified;
        
        private int channelsField;
        
        private bool channelsFieldSpecified;
        
        private string channel_layoutField;
        
        private int bits_per_sampleField;
        
        private bool bits_per_sampleFieldSpecified;
        
        private string idField;
        
        private string r_frame_rateField;
        
        private string avg_frame_rateField;
        
        private string time_baseField;
        
        private long start_ptsField;
        
        private bool start_ptsFieldSpecified;
        
        private float start_timeField;
        
        private bool start_timeFieldSpecified;
        
        private long duration_tsField;
        
        private bool duration_tsFieldSpecified;
        
        private float durationField;
        
        private bool durationFieldSpecified;
        
        private int bit_rateField;
        
        private bool bit_rateFieldSpecified;
        
        private int max_bit_rateField;
        
        private bool max_bit_rateFieldSpecified;
        
        private int bits_per_raw_sampleField;
        
        private bool bits_per_raw_sampleFieldSpecified;
        
        private int nb_framesField;
        
        private bool nb_framesFieldSpecified;
        
        private int nb_read_framesField;
        
        private bool nb_read_framesFieldSpecified;
        
        private int nb_read_packetsField;
        
        private bool nb_read_packetsFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StreamDispositionType disposition
        {
            get
            {
                return this.dispositionField;
            }
            set
            {
                this.dispositionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TagType[] tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("side_data", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public PacketSideDataType[] side_data_list
        {
            get
            {
                return this.side_data_listField;
            }
            set
            {
                this.side_data_listField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec_name
        {
            get
            {
                return this.codec_nameField;
            }
            set
            {
                this.codec_nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec_long_name
        {
            get
            {
                return this.codec_long_nameField;
            }
            set
            {
                this.codec_long_nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string profile
        {
            get
            {
                return this.profileField;
            }
            set
            {
                this.profileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec_type
        {
            get
            {
                return this.codec_typeField;
            }
            set
            {
                this.codec_typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec_tag
        {
            get
            {
                return this.codec_tagField;
            }
            set
            {
                this.codec_tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec_tag_string
        {
            get
            {
                return this.codec_tag_stringField;
            }
            set
            {
                this.codec_tag_stringField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string extradata
        {
            get
            {
                return this.extradataField;
            }
            set
            {
                this.extradataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="extradata_size")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _extradata_size
        {
            get
            {
                return this.extradata_sizeField;
            }
            set
            {
                this.extradata_sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _extradata_sizeSpecified
        {
            get
            {
                return this.extradata_sizeFieldSpecified;
            }
            set
            {
                this.extradata_sizeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string extradata_hash
        {
            get
            {
                return this.extradata_hashField;
            }
            set
            {
                this.extradata_hashField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="width")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _widthSpecified
        {
            get
            {
                return this.widthFieldSpecified;
            }
            set
            {
                this.widthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="height")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _heightSpecified
        {
            get
            {
                return this.heightFieldSpecified;
            }
            set
            {
                this.heightFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="coded_width")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _coded_width
        {
            get
            {
                return this.coded_widthField;
            }
            set
            {
                this.coded_widthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _coded_widthSpecified
        {
            get
            {
                return this.coded_widthFieldSpecified;
            }
            set
            {
                this.coded_widthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="coded_height")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _coded_height
        {
            get
            {
                return this.coded_heightField;
            }
            set
            {
                this.coded_heightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _coded_heightSpecified
        {
            get
            {
                return this.coded_heightFieldSpecified;
            }
            set
            {
                this.coded_heightFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="closed_captions")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _closed_captions
        {
            get
            {
                return this.closed_captionsField;
            }
            set
            {
                this.closed_captionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _closed_captionsSpecified
        {
            get
            {
                return this.closed_captionsFieldSpecified;
            }
            set
            {
                this.closed_captionsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="film_grain")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _film_grain
        {
            get
            {
                return this.film_grainField;
            }
            set
            {
                this.film_grainField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _film_grainSpecified
        {
            get
            {
                return this.film_grainFieldSpecified;
            }
            set
            {
                this.film_grainFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="has_b_frames")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _has_b_frames
        {
            get
            {
                return this.has_b_framesField;
            }
            set
            {
                this.has_b_framesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _has_b_framesSpecified
        {
            get
            {
                return this.has_b_framesFieldSpecified;
            }
            set
            {
                this.has_b_framesFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sample_aspect_ratio
        {
            get
            {
                return this.sample_aspect_ratioField;
            }
            set
            {
                this.sample_aspect_ratioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string display_aspect_ratio
        {
            get
            {
                return this.display_aspect_ratioField;
            }
            set
            {
                this.display_aspect_ratioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pix_fmt
        {
            get
            {
                return this.pix_fmtField;
            }
            set
            {
                this.pix_fmtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="level")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _levelSpecified
        {
            get
            {
                return this.levelFieldSpecified;
            }
            set
            {
                this.levelFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_range
        {
            get
            {
                return this.color_rangeField;
            }
            set
            {
                this.color_rangeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_space
        {
            get
            {
                return this.color_spaceField;
            }
            set
            {
                this.color_spaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_transfer
        {
            get
            {
                return this.color_transferField;
            }
            set
            {
                this.color_transferField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color_primaries
        {
            get
            {
                return this.color_primariesField;
            }
            set
            {
                this.color_primariesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string chroma_location
        {
            get
            {
                return this.chroma_locationField;
            }
            set
            {
                this.chroma_locationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string field_order
        {
            get
            {
                return this.field_orderField;
            }
            set
            {
                this.field_orderField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="refs")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _refs
        {
            get
            {
                return this.refsField;
            }
            set
            {
                this.refsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _refsSpecified
        {
            get
            {
                return this.refsFieldSpecified;
            }
            set
            {
                this.refsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sample_fmt
        {
            get
            {
                return this.sample_fmtField;
            }
            set
            {
                this.sample_fmtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="sample_rate")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _sample_rate
        {
            get
            {
                return this.sample_rateField;
            }
            set
            {
                this.sample_rateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _sample_rateSpecified
        {
            get
            {
                return this.sample_rateFieldSpecified;
            }
            set
            {
                this.sample_rateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="channels")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _channels
        {
            get
            {
                return this.channelsField;
            }
            set
            {
                this.channelsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _channelsSpecified
        {
            get
            {
                return this.channelsFieldSpecified;
            }
            set
            {
                this.channelsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string channel_layout
        {
            get
            {
                return this.channel_layoutField;
            }
            set
            {
                this.channel_layoutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="bits_per_sample")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _bits_per_sample
        {
            get
            {
                return this.bits_per_sampleField;
            }
            set
            {
                this.bits_per_sampleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _bits_per_sampleSpecified
        {
            get
            {
                return this.bits_per_sampleFieldSpecified;
            }
            set
            {
                this.bits_per_sampleFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string r_frame_rate
        {
            get
            {
                return this.r_frame_rateField;
            }
            set
            {
                this.r_frame_rateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string avg_frame_rate
        {
            get
            {
                return this.avg_frame_rateField;
            }
            set
            {
                this.avg_frame_rateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time_base
        {
            get
            {
                return this.time_baseField;
            }
            set
            {
                this.time_baseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="start_pts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _start_pts
        {
            get
            {
                return this.start_ptsField;
            }
            set
            {
                this.start_ptsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _start_ptsSpecified
        {
            get
            {
                return this.start_ptsFieldSpecified;
            }
            set
            {
                this.start_ptsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="start_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _start_time
        {
            get
            {
                return this.start_timeField;
            }
            set
            {
                this.start_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _start_timeSpecified
        {
            get
            {
                return this.start_timeFieldSpecified;
            }
            set
            {
                this.start_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="duration_ts")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _duration_ts
        {
            get
            {
                return this.duration_tsField;
            }
            set
            {
                this.duration_tsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _duration_tsSpecified
        {
            get
            {
                return this.duration_tsFieldSpecified;
            }
            set
            {
                this.duration_tsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="duration")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _durationSpecified
        {
            get
            {
                return this.durationFieldSpecified;
            }
            set
            {
                this.durationFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="bit_rate")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _bit_rate
        {
            get
            {
                return this.bit_rateField;
            }
            set
            {
                this.bit_rateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _bit_rateSpecified
        {
            get
            {
                return this.bit_rateFieldSpecified;
            }
            set
            {
                this.bit_rateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="max_bit_rate")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _max_bit_rate
        {
            get
            {
                return this.max_bit_rateField;
            }
            set
            {
                this.max_bit_rateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _max_bit_rateSpecified
        {
            get
            {
                return this.max_bit_rateFieldSpecified;
            }
            set
            {
                this.max_bit_rateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="bits_per_raw_sample")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _bits_per_raw_sample
        {
            get
            {
                return this.bits_per_raw_sampleField;
            }
            set
            {
                this.bits_per_raw_sampleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _bits_per_raw_sampleSpecified
        {
            get
            {
                return this.bits_per_raw_sampleFieldSpecified;
            }
            set
            {
                this.bits_per_raw_sampleFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="nb_frames")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _nb_frames
        {
            get
            {
                return this.nb_framesField;
            }
            set
            {
                this.nb_framesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _nb_framesSpecified
        {
            get
            {
                return this.nb_framesFieldSpecified;
            }
            set
            {
                this.nb_framesFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="nb_read_frames")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _nb_read_frames
        {
            get
            {
                return this.nb_read_framesField;
            }
            set
            {
                this.nb_read_framesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _nb_read_framesSpecified
        {
            get
            {
                return this.nb_read_framesFieldSpecified;
            }
            set
            {
                this.nb_read_framesFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="nb_read_packets")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _nb_read_packets
        {
            get
            {
                return this.nb_read_packetsField;
            }
            set
            {
                this.nb_read_packetsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _nb_read_packetsSpecified
        {
            get
            {
                return this.nb_read_packetsFieldSpecified;
            }
            set
            {
                this.nb_read_packetsFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> extradata_size
        {
            get
            {
                if (extradata_sizeFieldSpecified)
                {
                    return extradata_sizeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    extradata_sizeFieldSpecified = true;
                    extradata_sizeField = value.Value;
                }
                else
                {
                    extradata_sizeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> width
        {
            get
            {
                if (widthFieldSpecified)
                {
                    return widthField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    widthFieldSpecified = true;
                    widthField = value.Value;
                }
                else
                {
                    widthFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> height
        {
            get
            {
                if (heightFieldSpecified)
                {
                    return heightField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    heightFieldSpecified = true;
                    heightField = value.Value;
                }
                else
                {
                    heightFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> coded_width
        {
            get
            {
                if (coded_widthFieldSpecified)
                {
                    return coded_widthField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    coded_widthFieldSpecified = true;
                    coded_widthField = value.Value;
                }
                else
                {
                    coded_widthFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> coded_height
        {
            get
            {
                if (coded_heightFieldSpecified)
                {
                    return coded_heightField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    coded_heightFieldSpecified = true;
                    coded_heightField = value.Value;
                }
                else
                {
                    coded_heightFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<bool> closed_captions
        {
            get
            {
                if (closed_captionsFieldSpecified)
                {
                    return closed_captionsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    closed_captionsFieldSpecified = true;
                    closed_captionsField = value.Value;
                }
                else
                {
                    closed_captionsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<bool> film_grain
        {
            get
            {
                if (film_grainFieldSpecified)
                {
                    return film_grainField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    film_grainFieldSpecified = true;
                    film_grainField = value.Value;
                }
                else
                {
                    film_grainFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> has_b_frames
        {
            get
            {
                if (has_b_framesFieldSpecified)
                {
                    return has_b_framesField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    has_b_framesFieldSpecified = true;
                    has_b_framesField = value.Value;
                }
                else
                {
                    has_b_framesFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> level
        {
            get
            {
                if (levelFieldSpecified)
                {
                    return levelField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    levelFieldSpecified = true;
                    levelField = value.Value;
                }
                else
                {
                    levelFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> refs
        {
            get
            {
                if (refsFieldSpecified)
                {
                    return refsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    refsFieldSpecified = true;
                    refsField = value.Value;
                }
                else
                {
                    refsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> sample_rate
        {
            get
            {
                if (sample_rateFieldSpecified)
                {
                    return sample_rateField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    sample_rateFieldSpecified = true;
                    sample_rateField = value.Value;
                }
                else
                {
                    sample_rateFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> channels
        {
            get
            {
                if (channelsFieldSpecified)
                {
                    return channelsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    channelsFieldSpecified = true;
                    channelsField = value.Value;
                }
                else
                {
                    channelsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> bits_per_sample
        {
            get
            {
                if (bits_per_sampleFieldSpecified)
                {
                    return bits_per_sampleField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    bits_per_sampleFieldSpecified = true;
                    bits_per_sampleField = value.Value;
                }
                else
                {
                    bits_per_sampleFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> start_pts
        {
            get
            {
                if (start_ptsFieldSpecified)
                {
                    return start_ptsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    start_ptsFieldSpecified = true;
                    start_ptsField = value.Value;
                }
                else
                {
                    start_ptsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> start_time
        {
            get
            {
                if (start_timeFieldSpecified)
                {
                    return start_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    start_timeFieldSpecified = true;
                    start_timeField = value.Value;
                }
                else
                {
                    start_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> duration_ts
        {
            get
            {
                if (duration_tsFieldSpecified)
                {
                    return duration_tsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    duration_tsFieldSpecified = true;
                    duration_tsField = value.Value;
                }
                else
                {
                    duration_tsFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> duration
        {
            get
            {
                if (durationFieldSpecified)
                {
                    return durationField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    durationFieldSpecified = true;
                    durationField = value.Value;
                }
                else
                {
                    durationFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> bit_rate
        {
            get
            {
                if (bit_rateFieldSpecified)
                {
                    return bit_rateField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    bit_rateFieldSpecified = true;
                    bit_rateField = value.Value;
                }
                else
                {
                    bit_rateFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> max_bit_rate
        {
            get
            {
                if (max_bit_rateFieldSpecified)
                {
                    return max_bit_rateField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    max_bit_rateFieldSpecified = true;
                    max_bit_rateField = value.Value;
                }
                else
                {
                    max_bit_rateFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> bits_per_raw_sample
        {
            get
            {
                if (bits_per_raw_sampleFieldSpecified)
                {
                    return bits_per_raw_sampleField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    bits_per_raw_sampleFieldSpecified = true;
                    bits_per_raw_sampleField = value.Value;
                }
                else
                {
                    bits_per_raw_sampleFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> nb_frames
        {
            get
            {
                if (nb_framesFieldSpecified)
                {
                    return nb_framesField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    nb_framesFieldSpecified = true;
                    nb_framesField = value.Value;
                }
                else
                {
                    nb_framesFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> nb_read_frames
        {
            get
            {
                if (nb_read_framesFieldSpecified)
                {
                    return nb_read_framesField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    nb_read_framesFieldSpecified = true;
                    nb_read_framesField = value.Value;
                }
                else
                {
                    nb_read_framesFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> nb_read_packets
        {
            get
            {
                if (nb_read_packetsFieldSpecified)
                {
                    return nb_read_packetsField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    nb_read_packetsFieldSpecified = true;
                    nb_read_packetsField = value.Value;
                }
                else
                {
                    nb_read_packetsFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("streamDispositionType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class StreamDispositionType
    {
        
        private int defaultField;
        
        private int dubField;
        
        private int originalField;
        
        private int commentField;
        
        private int lyricsField;
        
        private int karaokeField;
        
        private int forcedField;
        
        private int hearing_impairedField;
        
        private int visual_impairedField;
        
        private int clean_effectsField;
        
        private int attached_picField;
        
        private int timed_thumbnailsField;
        
        private int captionsField;
        
        private int descriptionsField;
        
        private int metadataField;
        
        private int dependentField;
        
        private int still_imageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int @default
        {
            get
            {
                return this.defaultField;
            }
            set
            {
                this.defaultField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int dub
        {
            get
            {
                return this.dubField;
            }
            set
            {
                this.dubField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int original
        {
            get
            {
                return this.originalField;
            }
            set
            {
                this.originalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int lyrics
        {
            get
            {
                return this.lyricsField;
            }
            set
            {
                this.lyricsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int karaoke
        {
            get
            {
                return this.karaokeField;
            }
            set
            {
                this.karaokeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int forced
        {
            get
            {
                return this.forcedField;
            }
            set
            {
                this.forcedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int hearing_impaired
        {
            get
            {
                return this.hearing_impairedField;
            }
            set
            {
                this.hearing_impairedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int visual_impaired
        {
            get
            {
                return this.visual_impairedField;
            }
            set
            {
                this.visual_impairedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int clean_effects
        {
            get
            {
                return this.clean_effectsField;
            }
            set
            {
                this.clean_effectsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int attached_pic
        {
            get
            {
                return this.attached_picField;
            }
            set
            {
                this.attached_picField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int timed_thumbnails
        {
            get
            {
                return this.timed_thumbnailsField;
            }
            set
            {
                this.timed_thumbnailsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int captions
        {
            get
            {
                return this.captionsField;
            }
            set
            {
                this.captionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int metadata
        {
            get
            {
                return this.metadataField;
            }
            set
            {
                this.metadataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int dependent
        {
            get
            {
                return this.dependentField;
            }
            set
            {
                this.dependentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int still_image
        {
            get
            {
                return this.still_imageField;
            }
            set
            {
                this.still_imageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("chapterType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class ChapterType
    {
        
        private TagType[] tagField;
        
        private int idField;
        
        private string time_baseField;
        
        private int startField;
        
        private float start_timeField;
        
        private bool start_timeFieldSpecified;
        
        private int endField;
        
        private float end_timeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TagType[] tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time_base
        {
            get
            {
                return this.time_baseField;
            }
            set
            {
                this.time_baseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="start_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _start_time
        {
            get
            {
                return this.start_timeField;
            }
            set
            {
                this.start_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _start_timeSpecified
        {
            get
            {
                return this.start_timeFieldSpecified;
            }
            set
            {
                this.start_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int end
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float end_time
        {
            get
            {
                return this.end_timeField;
            }
            set
            {
                this.end_timeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> start_time
        {
            get
            {
                if (start_timeFieldSpecified)
                {
                    return start_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    start_timeFieldSpecified = true;
                    start_timeField = value.Value;
                }
                else
                {
                    start_timeFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("formatType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FormatType
    {
        
        private TagType[] tagField;
        
        private string filenameField;
        
        private int nb_streamsField;
        
        private int nb_programsField;
        
        private string format_nameField;
        
        private string format_long_nameField;
        
        private float start_timeField;
        
        private bool start_timeFieldSpecified;
        
        private float durationField;
        
        private bool durationFieldSpecified;
        
        private long sizeField;
        
        private bool sizeFieldSpecified;
        
        private long bit_rateField;
        
        private bool bit_rateFieldSpecified;
        
        private int probe_scoreField;
        
        private bool probe_scoreFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TagType[] tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string filename
        {
            get
            {
                return this.filenameField;
            }
            set
            {
                this.filenameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int nb_streams
        {
            get
            {
                return this.nb_streamsField;
            }
            set
            {
                this.nb_streamsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int nb_programs
        {
            get
            {
                return this.nb_programsField;
            }
            set
            {
                this.nb_programsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string format_name
        {
            get
            {
                return this.format_nameField;
            }
            set
            {
                this.format_nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string format_long_name
        {
            get
            {
                return this.format_long_nameField;
            }
            set
            {
                this.format_long_nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="start_time")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _start_time
        {
            get
            {
                return this.start_timeField;
            }
            set
            {
                this.start_timeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _start_timeSpecified
        {
            get
            {
                return this.start_timeFieldSpecified;
            }
            set
            {
                this.start_timeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="duration")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public float _duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _durationSpecified
        {
            get
            {
                return this.durationFieldSpecified;
            }
            set
            {
                this.durationFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="size")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _sizeSpecified
        {
            get
            {
                return this.sizeFieldSpecified;
            }
            set
            {
                this.sizeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="bit_rate")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long _bit_rate
        {
            get
            {
                return this.bit_rateField;
            }
            set
            {
                this.bit_rateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _bit_rateSpecified
        {
            get
            {
                return this.bit_rateFieldSpecified;
            }
            set
            {
                this.bit_rateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="probe_score")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int _probe_score
        {
            get
            {
                return this.probe_scoreField;
            }
            set
            {
                this.probe_scoreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool _probe_scoreSpecified
        {
            get
            {
                return this.probe_scoreFieldSpecified;
            }
            set
            {
                this.probe_scoreFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> start_time
        {
            get
            {
                if (start_timeFieldSpecified)
                {
                    return start_timeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    start_timeFieldSpecified = true;
                    start_timeField = value.Value;
                }
                else
                {
                    start_timeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<float> duration
        {
            get
            {
                if (durationFieldSpecified)
                {
                    return durationField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    durationFieldSpecified = true;
                    durationField = value.Value;
                }
                else
                {
                    durationFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> size
        {
            get
            {
                if (sizeFieldSpecified)
                {
                    return sizeField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    sizeFieldSpecified = true;
                    sizeField = value.Value;
                }
                else
                {
                    sizeFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<long> bit_rate
        {
            get
            {
                if (bit_rateFieldSpecified)
                {
                    return bit_rateField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    bit_rateFieldSpecified = true;
                    bit_rateField = value.Value;
                }
                else
                {
                    bit_rateFieldSpecified = false;
                }
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> probe_score
        {
            get
            {
                if (probe_scoreFieldSpecified)
                {
                    return probe_scoreField;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if ((value != null))
                {
                    probe_scoreFieldSpecified = true;
                    probe_scoreField = value.Value;
                }
                else
                {
                    probe_scoreFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("errorType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class ErrorType
    {
        
        private int codeField;
        
        private string stringField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @string
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("packetsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PacketsType
    {
        
        private PacketType[] packetField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("packet", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PacketType[] packet
        {
            get
            {
                return this.packetField;
            }
            set
            {
                this.packetField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("framesType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FramesType
    {
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("frame", typeof(FrameType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("subtitle", typeof(SubtitleType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("packetsAndFramesType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PacketsAndFramesType
    {
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("frame", typeof(FrameType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("packet", typeof(PacketType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("subtitle", typeof(SubtitleType), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("packetSideDataListType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PacketSideDataListType
    {
        
        private PacketSideDataType[] side_dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("side_data", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PacketSideDataType[] side_data
        {
            get
            {
                return this.side_dataField;
            }
            set
            {
                this.side_dataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("logsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class LogsType
    {
        
        private LogType[] logField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("log", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LogType[] log
        {
            get
            {
                return this.logField;
            }
            set
            {
                this.logField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("frameSideDataListType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FrameSideDataListType
    {
        
        private FrameSideDataType[] side_dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("side_data", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrameSideDataType[] side_data
        {
            get
            {
                return this.side_dataField;
            }
            set
            {
                this.side_dataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("frameSideDataTimecodeList", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class FrameSideDataTimecodeList
    {
        
        private FrameSideDataTimecodeType[] timecodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("timecode", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrameSideDataTimecodeType[] timecode
        {
            get
            {
                return this.timecodeField;
            }
            set
            {
                this.timecodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("streamsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class StreamsType
    {
        
        private StreamType[] streamField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("stream", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public StreamType[] stream
        {
            get
            {
                return this.streamField;
            }
            set
            {
                this.streamField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("programsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class ProgramsType
    {
        
        private ProgramType[] programField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("program", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ProgramType[] program
        {
            get
            {
                return this.programField;
            }
            set
            {
                this.programField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("chaptersType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class ChaptersType
    {
        
        private ChapterType[] chapterField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("chapter", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ChapterType[] chapter
        {
            get
            {
                return this.chapterField;
            }
            set
            {
                this.chapterField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("libraryVersionsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class LibraryVersionsType
    {
        
        private LibraryVersionType[] library_versionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("library_version", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LibraryVersionType[] library_version
        {
            get
            {
                return this.library_versionField;
            }
            set
            {
                this.library_versionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("pixelFormatComponentsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PixelFormatComponentsType
    {
        
        private PixelFormatComponentType[] componentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("component", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PixelFormatComponentType[] component
        {
            get
            {
                return this.componentField;
            }
            set
            {
                this.componentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("pixelFormatsType", Namespace="http://www.ffmpeg.org/schema/ffprobe")]
    public partial class PixelFormatsType
    {
        
        private PixelFormatType[] pixel_formatField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("pixel_format", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PixelFormatType[] pixel_format
        {
            get
            {
                return this.pixel_formatField;
            }
            set
            {
                this.pixel_formatField = value;
            }
        }
    }
}
